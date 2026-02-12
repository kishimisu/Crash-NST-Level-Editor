using Alchemy;
using Havok;

namespace NST
{
    public class SelectionManager
    {
        private static List<NSTObject> _copyPaste = [];
        private static LevelExplorer _copyExplorer;

        public List<NSTObject> _selection = [];
        public THREE.Group _selectionContainer = new THREE.Group();
        public LevelExplorer _explorer;

        private readonly THREE.Silk.TransformControls _gizmos;
        private readonly THREE.OutlinePass _outlinePass;
        private bool _revertGizmos = false;
        private int _scaleMode = 0;

        public SelectionManager(THREE.Object3D rootObject, THREE.Silk.TransformControls gizmos, THREE.OutlinePass outlinePass, LevelExplorer explorer)
        {
            _gizmos = gizmos;
            _outlinePass = outlinePass;

            _explorer = explorer;
            _explorer.KeyDown += OnKeyDown;

            rootObject.Add(_selectionContainer);
            _gizmos.Attach(_selectionContainer);
            
            _gizmos.Visible = false;

            _gizmos._mouseUpEvent += (_) =>
            {
                ApplyChanges(_explorer.ArchiveRenderer);
            };

            _gizmos._changeEvent += (_) =>
            {
                if (_scaleMode != 0) return;

                _scaleMode = -1;

                if (_gizmos.mode == "scale")
                {
                    foreach (NSTEntity entity in _selection.OfType<NSTEntity>())
                    {
                        if (entity.Spline?.Object3D != null && entity.Object3D?.Children.Contains(entity.Spline.Object3D) == true)
                        {
                            entity.Object3D.Remove(entity.Spline.Object3D);
                            entity.Spline.Object3D = null;
                            _scaleMode = 1;
                        }
                    }
                }
            };
        }

        public void UpdateSelection(List<NSTObject> objects, bool newSelection = true)
        {
            List<NSTObject> previousSelection = _selection.ToList();

            if (newSelection && _selection.Count > 0)
            {
                ClearSelection();
            }

            for (int i = 0; i < objects.Count; i++)
            {
                SelectObject(objects[i]);
            }

            var newObjects = _selection.Except(previousSelection);
            var removedObjects = previousSelection.Except(_selection);

            _explorer.InstanceManager.RefreshInstances(newObjects.Union(removedObjects).ToList());
            _explorer.RenderNextFrame = true;

            if (_selection.Count == 0) _gizmos.Visible = false;
        }

        private void SelectObject(NSTObject obj)
        {
            if (!_selection.Contains(obj))
            {
                AddToSelection(obj);
            }
            else
            {
                RemoveFromSelection(obj);
            }
        }

        private void AddToSelection(NSTObject obj)
        {
            THREE.Object3D object3D = obj.CreateObject3D(true);

            if (_revertGizmos)
            {
                _gizmos.mode = "translate";
                _revertGizmos = false;
            }

            if (_selection.Count == 0)
            {
                _selectionContainer.Position.Copy(object3D.Position);
                _selectionContainer.Quaternion.Copy(THREE.Quaternion.Identity());
                _selectionContainer.Scale.Copy(THREE.Vector3.One());

                if (obj is NSTSplineRotationKeyFrame && _gizmos.mode != "rotate")
                {
                    _gizmos.mode = "rotate";
                    _revertGizmos = true;
                }
            }

            obj.IsSelected = true;

            _selection.Add(obj);
            _outlinePass.selectedObjects.Add(object3D);
            _selectionContainer.Attach(object3D);
        }

        private void RemoveFromSelection(NSTObject obj)
        {
            if (_selection.Count == 1)
            {
                ClearSelection();
                return;
            }
            
            RemoveObjectsFromScene([obj]);

            _selectionContainer.Remove(obj.Object3D!);
            _selection.Remove(obj);
            _outlinePass.selectedObjects.Remove(obj.Object3D!);
        }

        public void ClearSelection(bool refreshInstances = false)
        {
            RemoveObjectsFromScene(_selection);

            if (refreshInstances)
            {
                _explorer.InstanceManager.RefreshInstances(_selection);
            }

            _selection.Clear();
            _outlinePass.selectedObjects.Clear();
        }

        private static void RemoveObjectsFromScene(List<NSTObject> objects)
        {
            foreach (NSTObject obj in objects)
            {
                if (obj.Object3D != null)
                {
                    obj.Object3D.Parent.Remove(obj.Object3D);
                    obj.Object3D = null;
                }

                foreach (NSTEntity parent in obj.Parents.OfType<NSTEntity>().Where(p => p.Object is CScriptTriggerEntity))
                {
                    if (parent.IsSelected || parent.Children.Any(c => c != obj && c.IsSelected)) continue;
                    parent.Object3D?.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.Triggers));
                }

                obj.IsSelected = false;
            }
        }

        public void ApplyChanges(IgArchiveRenderer archiveRenderer)
        {
            HashSet<NSTSpline> refreshSplines = [];
            HashSet<NSTObject> refreshedObjects = [];

            foreach (NSTObject obj in _selection)
            {
                // Get world transform
                THREE.Vector3 worldPos = obj.Object3D!.GetWorldPosition(new THREE.Vector3());
                THREE.Quaternion worldQuaternion = obj.Object3D.GetWorldQuaternion(new THREE.Quaternion());
                THREE.Vector3 worldScale = obj.Object3D.GetWorldScale();
                THREE.Euler worldEuler = new THREE.Euler().SetFromQuaternion(worldQuaternion, THREE.RotationOrder.ZYX);
                THREE.Vector3 worldEulerDegrees = worldEuler.ToVector3() * THREE.MathUtils.RAD2DEG;

                if (obj is NSTSplineControlPoint controlPoint)
                {
                    THREE.Vector3 wp = controlPoint.Object3D!.GetWorldPosition(new THREE.Vector3());
                    THREE.Vector3 localPos = wp.ApplyMatrix4(controlPoint.Parent.Parent.ObjectToWorld().Inverted());
                    controlPoint.Object._position = new igVec3fMetaField(localPos.X, localPos.Y, localPos.Z);
                    refreshSplines.Add(controlPoint.Parent);
                    archiveRenderer.SetObjectUpdated(controlPoint.ArchiveFile, controlPoint.Object);
                    continue;
                }
                if (obj is NSTSplineRotationKeyFrame keyframe)
                {
                    THREE.Quaternion quaternion = keyframe.Object3D!.GetWorldQuaternion(new THREE.Quaternion());
                    THREE.Euler euler = new THREE.Euler().SetFromQuaternion(quaternion, THREE.RotationOrder.ZYX);
                    THREE.Vector3 rotation = euler.ToVector3() * THREE.MathUtils.RAD2DEG;
                    keyframe.Object._value = new igVec3fMetaField(rotation.X, rotation.Y, rotation.Z - 90);
                    archiveRenderer.SetObjectUpdated(keyframe.ArchiveFile, keyframe.Object);
                    continue;
                }
                if (obj is NSTCameraBox cameraBox)
                {
                    cameraBox.Object._position = worldPos.ToVec3MetaField();
                    cameraBox.Object._rotation = worldEulerDegrees.ToVec3MetaField();
                    archiveRenderer.SetObjectUpdated(cameraBox.ArchiveFile, cameraBox.Object);
                    continue;
                }
                if (obj is NSTCamera camera)
                {
                    camera.Object._position = worldPos.ToVec3MetaField();
                    camera.Object._rotation = worldEulerDegrees.ToVec3MetaField();
                    archiveRenderer.SetObjectUpdated(camera.ArchiveFile, camera.Object);
                    continue;
                }
                if (obj is NSTWaypoint waypoint)
                {
                    waypoint.Object._position = worldPos.ToVec3MetaField();
                    waypoint.Object._rotation = worldEulerDegrees.ToVec3MetaField();
                    archiveRenderer.SetObjectUpdated(waypoint.ArchiveFile, waypoint.Object);
                    continue;
                }

                if (obj is not NSTEntity entity3D)
                {
                    Console.WriteLine("[ApplyChanges] Warning: Unknown object type: " + obj.GetObject());
                    continue;
                }

                if (entity3D.IsPrefabChild) // Skip prefab children
                {
                    var entities = _selection.OfType<NSTEntity>();

                    if (entities.Any(e => e == entity3D.ParentPrefabInstance)) 
                        continue; // Root prefab found in selection
                    if (entities.Where(e => e.Object == entity3D.Object).ToList().IndexOf(entity3D) > 0) 
                        continue; // Other instances of this prefab found in selection (only update the first one)
                }

                igEntity entity = entity3D.Object;

                // If prefab child, the transform needs to be converted to local space
                if (entity3D.IsPrefabChild && entity3D.ParentPrefabInstance != null)
                {
                    THREE.Matrix4 parentMatrixInverse = entity3D.ParentPrefabInstance.ObjectToWorld().Invert();
                    THREE.Matrix4 worldMatrix = new THREE.Matrix4().Compose(worldPos, worldQuaternion, worldScale);
                    THREE.Matrix4 localMatrix = parentMatrixInverse * worldMatrix;

                    localMatrix.Decompose(worldPos, worldQuaternion, worldScale);

                    worldEuler = new THREE.Euler().SetFromQuaternion(worldQuaternion, THREE.RotationOrder.ZYX);
                }

                bool hasRotation = worldEuler.ToVector3().LengthSq() > 1e-3f;
                bool hasScale = (worldScale - THREE.Vector3.One()).LengthSq() > 1e-3f;

                // Child template scale overrides parent spawner scale
                NSTEntity? childTemplate = null;
                if (hasScale)
                {
                    childTemplate = entity3D.GetChildTemplate();
                    
                    if (childTemplate != null)
                    {
                        childTemplate = entity3D.MakeChildTemplateUnique(_explorer, childTemplate);

                        if (childTemplate.Object._transform == null)
                        {
                            childTemplate.Object._transform = new igEntityTransform();
                            childTemplate.Object._transform.MemoryPool = childTemplate.Object.MemoryPool.WithAlignment(16);
                        }
                        childTemplate.Object._transform._nonUniformPersistentParentSpaceScale = worldScale.ToVec3MetaField();
                    }
                }

                THREE.Matrix4 previousMatrix = entity3D.ObjectToWorld();

                // Update position
                entity._parentSpacePosition = worldPos.ToVec3MetaField();

                // Create transform object if necessary
                if (entity._transform == null && (hasRotation || (hasScale && childTemplate == null)))
                {
                    entity._transform = new igEntityTransform();
                    entity._transform.MemoryPool = entity.MemoryPool.WithAlignment(16);
                }

                if (entity._transform != null)
                {   
                    // Update rotation
                    entity._transform._parentSpaceRotation = worldEuler.ToVec3MetaField();

                    if (childTemplate == null)
                    {
                        // Update scale
                        entity._transform._nonUniformPersistentParentSpaceScale = worldScale.ToVec3MetaField();
                    }
                }

                archiveRenderer.SetEntityUpdated(entity3D);

                if (entity3D.IsPrefabInstance)
                {
                    List<NSTObject> prefabChildren = entity3D.Children.Where(e => e is NSTEntity entity && entity.ParentPrefabInstance == entity3D).ToList();

                    foreach (NSTObject child in prefabChildren)
                    {
                        if (child is NSTEntity childEntity && childEntity.CollisionShapeIndex != -1)
                        {
                            archiveRenderer.SetEntityUpdated(childEntity);
                        }
                    }

                    _explorer.InstanceManager.RefreshInstances(prefabChildren);
                }

                THREE.Matrix4 deltaMatrix = new THREE.Matrix4().Copy(entity3D.ObjectToWorld()).Multiply(previousMatrix.Inverted());

                // Update child templates position
                var childTemplates = entity3D.GetUniqueChildTemplates();
                foreach (var child in childTemplates)
                {
                    if (refreshedObjects.Contains(child)) continue;
                    refreshedObjects.Add(child);
                    
                    THREE.Matrix4 newChildMatrix = deltaMatrix * child.ObjectToWorld();
                    THREE.Vector3 p = new THREE.Vector3();
                    newChildMatrix.Decompose(p, new THREE.Quaternion(), new THREE.Vector3());
                    child.Object._parentSpacePosition = p.ToVec3MetaField();
                }
                if (childTemplates.Any())
                {
                    _explorer.InstanceManager.RefreshInstances(childTemplates.Cast<NSTObject>().ToList());
                }
                // Update child waypoints position
                if (_explorer.FileManager.GetIgz(entity3D.ArchiveFile) is IgzFile igz)
                {
                    foreach (var wp in entity3D.GetComponentsWaypoints(igz).SelectMany(e => e.Value))
                    {
                        THREE.Matrix4 newMat = deltaMatrix * THREE.Matrix4.CreateTranslation(wp._position._x, wp._position._y, wp._position._z);
                        THREE.Vector3 p = new THREE.Vector3();
                        newMat.Decompose(p, new THREE.Quaternion(), new THREE.Vector3());
                        wp._position = p.ToVec3MetaField();
                    }
                }
            }

            foreach (NSTSpline spline in refreshSplines)
            {
                spline.RefreshDistances(_explorer);
                spline.ComputeDistances();
                spline.RefreshSpline();
            }

            if (_scaleMode == 1)
            {
                UpdateSelection(_selection.ToList());
            }
            _scaleMode = 0;
        }

        public bool Copy(LevelExplorer explorer)
        {
            _copyPaste = _selection.Where(e => e is NSTEntity || e is NSTCamera || e is NSTCameraBox).ToList();
            _copyExplorer = explorer;
            return _copyPaste.Count > 0;
        }

        /* Disclaimer: the following (500+ lines) method has to be one of the most convoluted thing I've ever written. 
           It started out as a clean, simple function to paste objects into another level editor, but I had to manage  
           so many edge cases that it slowly turned into a mess that is becoming harder to maintain with every new case. 
           It'll need to be improved in the future, but as long as it works... For your own sanity, I'd recommend not spending too much time on it. */
        public void Paste(IgArchiveRenderer renderer, ActiveFileManager fileManager, THREE.Vector3? spawnPoint = null, Action<NSTObject?>? callback = null)
        {
            if (_copyPaste.Count == 0) return;

            bool copyToSameFile = (_explorer == _copyExplorer);

            HashSet<NSTObject> toCopyPaste = _copyPaste.ToHashSet();

            foreach (var obj in _copyPaste)
            {
                // Add parent triggers when copying to external archive
                foreach (var parent in obj.Parents.OfType<NSTEntity>().Where(e => e.Object is CScriptTriggerEntity))
                {
                    if (!copyToSameFile || parent.Object.GetComponent<common_Chase_BacktrackTriggerData>() != null)
                    {
                        toCopyPaste.Add(parent);
                    }
                }

                // Add child triggers & templates when copying to external archive
                if (!copyToSameFile)
                {
                    foreach (var child in obj.Children.OfType<NSTEntity>())
                    {
                        if (child.Object is CScriptTriggerEntity)
                        {
                            toCopyPaste.Add(child);
                        }

                        if (child.IsTemplate)
                        {   
                            toCopyPaste.Add(child);

                            // Fix crash with CSplineLaneMoverComponentData components referencing missing spline
                            if (child.Object.TryGetComponent(out CSplineLaneMoverComponentData? splineMover) && splineMover._splineEntity.Reference != null && 
                                child.Children.FirstOrDefault(c => NamedReference.Compare(c.ToReference(), splineMover._splineEntity.Reference)) is NSTEntity spline)
                            {
                                toCopyPaste.Add(spline);
                            }
                        }
                    }

                    if (obj is NSTEntity e)
                    {
                        foreach (var child in obj.Children)
                        {
                            if (child is NSTEntity || child is NSTCamera)
                            {
                                toCopyPaste.Add(child);
                            }
                        }

                        // Special case for L303_OrientExpress: remove child spline if it already exists
                        NamedReference? reference = null;

                        if (e.Object.TryGetComponent(out Enemy_PlayAnimation_OnSplineDistance_BehaviorData? l303a) && l303a._Entity.Reference != null)
                        {
                            reference = l303a._Entity.Reference;
                        }
                        else if (e.Object.TryGetComponent(out GreatWall_Enemy_Ramp_LabAssistant_BehaviorData? l303b) && l303b._Entity.Reference != null)
                        {
                            reference = l303b._Entity.Reference;
                        }
                        else if (e.Object.TryGetComponent(out GreatWall_Enemy_Basket_LabAssistant_BehaviorData? l310a) && l310a._Entity.Reference != null)
                        {
                            reference = l310a._Entity.Reference;
                        }

                        if (reference != null && _explorer.InstanceManager.AllEntities.Any(c => NamedReference.Compare(c.ToReference(), reference)))
                        {
                            if (toCopyPaste.FirstOrDefault(c => NamedReference.Compare(c.ToReference(), reference)) is NSTObject toRemove)
                            {
                                toCopyPaste.Remove(toRemove);
                            }
                        }
                    }
                }
            }

            Dictionary<IgArchiveFile, List<NSTObject>> instances = toCopyPaste
                    .GroupBy(x => x.ArchiveFile)
                    .ToDictionary(x => x.Key, x => x.ToList());

            List<igObject> newClones = [];
            List<NSTObject> newObjects = [];
            Dictionary<NSTEntity, NSTEntity> newEntities = new Dictionary<NSTEntity, NSTEntity>();
            Dictionary<NSTEntity, NSTEntity> newCollisionEntities = new Dictionary<NSTEntity, NSTEntity>();

            ClearSelection(true);

            ModalRenderer.ShowLoadingModal("Pasting selection...");

            Task.Run(() =>
            {
                string cameraNamespace = _explorer.GetFileNameFromIdentifier("Camera");

                foreach ((IgArchiveFile file, List<NSTObject> objects) in instances)
                {
                    List<NSTEntity> entities = objects.OfType<NSTEntity>().ToList();
                    IgzFile srcIgz = copyToSameFile ? fileManager.GetIgz(file)! : _copyExplorer.FileManager.GetIgz(file)!;
                    
                    IgArchiveFile? dstFile = file;
                    IgzFile dstIgz = srcIgz;

                    if (!copyToSameFile)
                    {
                        _explorer.GetOrCreateExternalIgzFile(file.GetPath(), out dstFile, out dstIgz);
                    }
                    
                    // Console.WriteLine($"Pasting ({entities.Count}) into {dstIgz.GetName()}: ({(copyToSameFile ? "same file" : "external file")})\n- " + string.Join("\n- ", _copyPaste.Select(x => x.Object)));

                    Dictionary<igObject, igObject> clones = [];

                    foreach (NSTObject obj in objects)
                    {
                        if (obj is not NSTEntity entity)
                        {
                            if (copyToSameFile)
                            {
                                srcIgz.AddClone(obj.GetObject(), null, clones, CloneMode.Deep | CloneMode.SkipComponents);
                            }
                            else
                            {
                                renderer.Clone(obj.GetObject(), _copyExplorer.Archive, srcIgz, dstIgz, clones);
                            }
                            continue;
                        }

                        if (entity.IsPrefabChild)
                        {
                            if (entities.Any(e => e == entity.ParentPrefabInstance)) continue;
                            if (entities.Where(e => e.Object == entity.Object).ToList().IndexOf(entity) > 0) continue;
                        }

                        // Update Spawner_Trigger_LogicData children before copying to only include currently selected objects
                        CEntityHandleList? triggerHandleList = null;
                        List<igHandleMetaField>? triggerData = null;
                        if (entity.Object is CScriptTriggerEntity && entity.Object.TryGetComponent(out Spawner_Trigger_LogicData? triggerComponent) && triggerComponent._SpawnerActivationList.Reference != null)
                        {
                            var entityListRef = triggerComponent._SpawnerActivationList.Reference;
                            triggerHandleList = (CEntityHandleList)srcIgz.FindObject(entityListRef)!;

                            triggerData = triggerHandleList._data.ToList();

                            var children = triggerData.Where(d => d.Reference != null && toCopyPaste.Any(c => NamedReference.Compare(c.ToReference(), d.Reference)));
                            triggerHandleList._data.Set(children.ToList());
                        }

                        if (copyToSameFile)
                        {
                            HashSet<igObject> forceClone = [];

                            // Clone child templates
                            if (entity.IsSpawned && entity.Object.GetComponent<common_Crate_StackCheckerData>() == null)
                            {
                                forceClone = entity.Object
                                    .GetComponents()
                                    .Where(c => c is not common_CameraDistanceFadeEntityData && c is not igPrefabComponentData && c is not DDA_CheckpointData)
                                    .Cast<igObject>().ToHashSet();
                            }
                            
                            // Clone child waypoints
                            var waypoints = entity.GetComponentsWaypoints(srcIgz);
                            foreach (var wp in waypoints) forceClone.Add(wp.Key);

                            // Clone entity
                            igEntity entityClone = srcIgz.AddClone(entity.Object, null, clones, CloneMode.Deep | CloneMode.SkipComponents, forceClone.Count == 0 ? null : forceClone);

                            // Special case: paste prefab child
                            if (entity.IsPrefabChild)
                            {
                                NSTEntity template = entity.Clone(entityClone);

                                _explorer.InstanceManager.PrefabTemplates[entityClone] = template;

                                foreach (NSTEntity prefabChild in entity.PrefabTemplate!.PrefabTemplateInstances.ToList())
                                {
                                    NSTEntity newPrefabChild = template.CloneAsPrefabChild(prefabChild.ParentPrefabInstance!);

                                    if (entity != prefabChild) newObjects.Add(newPrefabChild);
                                    else newObjects.Insert(0, newPrefabChild);

                                    var data = entity.ParentPrefabInstance!.Object.GetComponent<igPrefabComponentData>()!._prefabEntities?._data;
                                    if (data?.Contains(entityClone) == false) data.Add(entityClone);
                                }

                                clones.Clear();
                                break;
                            }
                        }
                        // Paste to external archive
                        else
                        {
                            renderer.Clone(entity.Object, _copyExplorer.Archive, srcIgz, dstIgz, clones, true);
                        }

                        if (triggerHandleList != null && triggerData != null)
                        {
                            triggerHandleList._data.Set(triggerData);
                        }
                    }

                    foreach ((igObject src, igObject dst) in clones)
                    {
                        newClones.Add(dst);
                        renderer.SetObjectUpdated(dstFile, dst);

                        foreach (NamedReference handle in dst.GetHandles())
                        {
                            if (handle.namespaceName.EndsWith("_Camera"))
                            {
                                handle.namespaceName = cameraNamespace;
                            }
                        }

                        if (src is CCamera srcCam && dst is CCamera dstCam)
                        {
                            newObjects.Add(new NSTCamera(dstCam, dstFile));
                            continue;
                        }
                        if (src is CCameraBox srcCamBox && dst is CCameraBox dstCamBox)
                        {
                            newObjects.Add(new NSTCameraBox(dstCamBox, dstFile));
                            continue;
                        }

                        if (src is not igEntity srcEntity || dst is not igEntity dstEntity)
                        {
                            continue;
                        }

                        NSTEntity original = _copyExplorer.InstanceManager.AllEntities.First(e => e.Object == srcEntity);
                        NSTEntity clone = original.Clone(dstEntity, dstFile);
                        
                        if (copyToSameFile)
                        {
                            original.Components?.RefreshComponents(_explorer);
                        }

                        if (original.CollisionShapeIndex != -1 && !original.IsPrefabChild)
                        {
                            Console.WriteLine("Add collision: " + clone.Object.ObjectName + " (" + original.Object.ObjectName + "), template: " + clone.IsPrefabTemplate);
                            newCollisionEntities.Add(original, clone);
                        }

                        newObjects.Add(clone);
                        newEntities.Add(original, clone);
                    }
                }

                // Refresh handles pointing to original entities
                foreach (igObject clone in newClones)
                {
                    foreach (var handle in clone.GetHandles())
                    {
                        NSTEntity? cloneObject = newEntities.FirstOrDefault(e => e.Key.FileNamespace == handle.namespaceName && e.Key.Object.ObjectName == handle.objectName).Value;
                        if (cloneObject == null) continue;
                        // Console.WriteLine($"Replace handle: {handle} => {cloneObject.FileNamespace}::{cloneObject.Object.ObjectName}");
                        handle.SetNamespace(cloneObject.FileNamespace);
                        handle.SetObject(cloneObject.Object.ObjectName!);
                    }
                }

                if (newObjects.Count == 0)
                {
                    ModalRenderer.CloseLoadingModal();
                    callback?.Invoke(null);
                    return;
                }

                // Register new entities
                foreach (NSTObject clone in newObjects)
                {
                    _explorer.InstanceManager.Register(clone);
                }

                // Update CScriptTriggerEntity parent/child references
                if (copyToSameFile)
                {
                    foreach ((NSTEntity original, NSTEntity clone) in newEntities)
                    {
                        if (clone.Object is CScriptTriggerEntity)
                        {
                            // Update new Spawner_Trigger_LogicData so it references new clones
                            if (clone.Object.TryGetComponent(out Spawner_Trigger_LogicData? triggerComponent) && triggerComponent._SpawnerActivationList.Reference != null)
                            {
                                IgzFile dstIgz = _explorer.FileManager.GetIgz(clone.ArchiveFile)!;

                                var entityListReference = triggerComponent._SpawnerActivationList.Reference;
                                var entityList = (CEntityHandleList)dstIgz.FindObject(entityListReference)!;

                                clone.Components ??= new ComponentManager(clone);
                                clone.Components.SetupComponents(_explorer);
                                clone.Components.MakeUnique(clone.Components.GetComponent<Spawner_Trigger_LogicData>()!);
                                triggerComponent = clone.Object.GetComponent<Spawner_Trigger_LogicData>()!;

                                var entityListClone = dstIgz.AddClone(entityList, mode: CloneMode.Shallow);
                                entityListClone._data.Clear();

                                foreach (var child in toCopyPaste.OfType<NSTEntity>().Where(c => c.Parents.Contains(original)))
                                {
                                    // Console.WriteLine("Add new child entity to new trigger " + original.Object + " -> " + child.GetObject() + " => " + newEntities[child].Object);
                                    entityListClone._data.Add(new igHandleMetaField() { Reference = newEntities[child].ToReference() });
                                }

                                triggerComponent._SpawnerActivationList.Reference = entityListClone.ToNamedReference(dstIgz.GetName(false));
                            }
                        }
                        else
                        {
                            var parentTriggers = original.Parents.OfType<NSTEntity>().Where(p => p.Object is CScriptTriggerEntity);

                            foreach (var parent in parentTriggers)
                            {
                                if (!parent.Object.TryGetComponent(out common_Chase_BacktrackTriggerData? backtrackComponent)) continue;
                                newEntities[parent].Object.GetComponent<common_Chase_BacktrackTriggerData>()!._Entity.Reference = clone.ToReference();
                            }

                            // Update existing Spawner_Trigger_LogicData so it references new clones
                            if (!parentTriggers.Any(p => toCopyPaste.Contains(p)))
                            {
                                foreach (NSTEntity parent in parentTriggers)
                                {
                                    if (!parent.Object.TryGetComponent(out Spawner_Trigger_LogicData? triggerComponent) || triggerComponent._SpawnerActivationList.Reference == null) continue;

                                    var parentIgz = _copyExplorer.FileManager.GetIgz(parent.ArchiveFile)!;
                                    var entityListRef = triggerComponent._SpawnerActivationList.Reference;
                                    var entityList = (CEntityHandleList)parentIgz.FindObject(entityListRef)!;
                                    entityList._data.Add(new igHandleMetaField() { Reference = clone.ToReference() });
                                    parent.Children.Add(clone);
                                    clone.Parents.Add(parent);
                                    // Console.WriteLine("Add new child entity to existing trigger " + parent.Object + " => " + clone.Object);
                                }
                            }

                            // Update spawner template so it references the original trigger volume
                            if (clone.Object.TryGetComponent(out common_Spawner_TemplateData? spawnerComponent) && spawnerComponent._TriggerVolume.Reference != null)
                            {
                                NSTEntity? originalChildTrigger = original.Children.OfType<NSTEntity>().FirstOrDefault(e => e.Object is CScriptTriggerEntity);
                                NSTEntity? newChildTrigger = newEntities.Values.FirstOrDefault(e => NamedReference.Compare(e.ToReference(), spawnerComponent._TriggerVolume.Reference));

                                if (originalChildTrigger != null && !toCopyPaste.Contains(originalChildTrigger))
                                {
                                    // Console.WriteLine("Replace trigger volume " + spawnerComponent._TriggerVolume.Reference + " => " + originalChildTrigger.ToReference());

                                    spawnerComponent._TriggerVolume.Reference = originalChildTrigger.ToReference();

                                    if (newChildTrigger != null)
                                    {
                                        var srcIgz = _explorer.FileManager.GetIgz(newChildTrigger.ArchiveFile);
                                        srcIgz?.Remove(newChildTrigger.Object);
                                        newObjects.Remove(newChildTrigger);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach ((NSTEntity original, NSTEntity clone) in newEntities)
                {
                    List<NSTEntity> prefabChildren = clone.InitPrefabChildren(_explorer.InstanceManager);

                    if (prefabChildren.Count > 0)
                    {
                        List<NSTEntity> originalPrefabChildren = original.Children.OfType<NSTEntity>().Where(e => e.ParentPrefabInstance == original).ToList();

                        for (int i = 0; i < prefabChildren.Count; i++)
                        {
                            if (originalPrefabChildren[i].CollisionShapeIndex != -1)
                            {
                                Console.WriteLine("Add prefab child collision: " + prefabChildren[i].Object.ObjectName + " (" + original.Object.ObjectName + "), template: " + prefabChildren[i].IsPrefabTemplate);
                                newCollisionEntities.Add(originalPrefabChildren[i], prefabChildren[i]);
                            }

                            newObjects.Add(prefabChildren[i]);
                        }
                    }
                }

                // Initialize children references
                foreach ((NSTEntity original, NSTEntity clone) in newEntities)
                {
                    clone.InitChildren(_explorer, _explorer.InstanceManager.AllObjects);

                    // If the object is no longer part of a prefab, update _isArchetype otherwise it won't spawn
                    if (original.IsPrefabChild && !clone.IsPrefabChild && !clone.IsPrefabTemplate && clone.Object._bitfield._isArchetype)
                    {
                        clone.Object._bitfield._isArchetype = false;
                    }
                }

                // Register new collisions
                foreach ((NSTEntity original, NSTEntity clone) in newCollisionEntities)
                {
                    if (copyToSameFile)
                    {
                        // Special case: clone prefab child with collision
                        if (original.IsPrefabChild)
                        {
                            // Make igPrefabComponentData unique
                            NSTEntity parentPrefabInstance = clone.ParentPrefabInstance!;
                            parentPrefabInstance.Components ??= new ComponentManager(parentPrefabInstance);
                            parentPrefabInstance.Components.SetupComponents(_explorer);
                            parentPrefabInstance.Components!.MakeUnique(parentPrefabInstance.Components.GetComponent<igPrefabComponentData>()!);
                            
                            // Remove clone from parent instance and template
                            parentPrefabInstance.Children.Remove(clone);
                            clone.PrefabTemplate!.PrefabTemplateInstances.Remove(clone);

                            // Clone the object
                            IgzFile igz = _explorer.FileManager.GetIgz(clone.ArchiveFile)!;
                            igEntity cloneObj = igz.AddClone(clone.Object);
                            cloneObj._bitfield._isArchetype = false;

                            // Clone the template & prefab child entities
                            NSTEntity cloneTemplate = clone.Clone(cloneObj);
                            NSTEntity newPrefabChild = cloneTemplate.CloneAsPrefabChild(parentPrefabInstance);
                            
                            newPrefabChild.CollisionShapeIndex = original.CollisionShapeIndex;
                            
                            // Register new clone
                            _explorer.InstanceManager.PrefabTemplates[cloneObj] = cloneTemplate;
                            _explorer.InstanceManager.Unregister(clone);
                            _explorer.InstanceManager.Register(newPrefabChild);
                            _explorer.InstanceManager.FakePrefabChilds.Add(newPrefabChild);

                            var prefabComponentData = parentPrefabInstance.Object.GetComponent<igPrefabComponentData>()!._prefabEntities!._data;

                            // Update igPrefabComponentData
                            int idx = prefabComponentData.IndexOf(clone.Object);
                            prefabComponentData.Remove(clone.Object);
                            prefabComponentData.Insert(idx, newPrefabChild.Object);

                            // Update new objects
                            newObjects.Remove(clone);
                            newObjects.Add(newPrefabChild);

                            // If an updated collision shape is found for the original object, it means the collision index comes from another archive. Reuse this collision shape
                            if (_explorer.FileManager.GetInfos(original.ArchiveFile)?.updatedCollisions.TryGetValue(original, out var infos) == true)
                            {
                                renderer.SetEntityUpdated(newPrefabChild, infos.shapeInstance);
                            }
                            // No update collision shape found, the collision index points to a valid collision in this archive
                            else
                            {
                                renderer.SetEntityUpdated(newPrefabChild);
                            }
                        }
                        else if (_explorer.FileManager.GetInfos(original.ArchiveFile)!.updatedCollisions.TryGetValue(original, out CollisionUpdateInfos? infos) && infos.shapeInstance != null)
                        {
                            Console.WriteLine("Paste external collision shape to same file: " + clone.Object.ObjectName);
                            renderer.SetEntityUpdated(clone, infos.shapeInstance);
                        }
                        else
                        {
                            Console.WriteLine("Paste collision index to same file: " + clone.Object.ObjectName);
                            renderer.SetEntityUpdated(clone);
                        }
                    }
                    else
                    {
                        hknpShapeInstance? shape = _copyExplorer.FindHavokShape(original);
                        
                        // Console.WriteLine($"IsPrefabInstance: {clone.IsPrefabInstance}, IsPrefabTemplate: {clone.IsPrefabTemplate}, IsPrefabChild: {clone.IsPrefabChild}, CollisionPrefabHash: {clone.CollisionPrefabHash}, CollisionShapeIndex: {clone.CollisionShapeIndex}");
                        
                        if (clone.IsPrefabChild)
                        {
                            Console.WriteLine($"Paste prefab collision shape to another level ({clone.ParentPrefabInstance?.Object.ObjectName} -> {clone.Object.ObjectName}), hash: {original.CollisionPrefabHash}");
                            clone.Object._bitfield._isArchetype = false;
                            _explorer.InstanceManager.FakePrefabChilds.Add(clone);
                            renderer.SetEntityUpdated(clone, shape);
                        }
                        else
                        {
                            Console.WriteLine("Paste collision shape to another level: " + clone.Object.ObjectName);
                            renderer.SetEntityUpdated(clone, shape);
                        }
                    }
                }

                UpdateSelection(newObjects.Where(e => e is not NSTEntity entity || entity.IsSpawned).ToList());

                if (_copyPaste.All(e => e is NSTEntity entity && entity.IsPrefabChild))
                {
                    _selectionContainer.Position.Z += 200;
                }
                else if (spawnPoint != null)
                {
                    _selectionContainer.Position.Copy(spawnPoint);
                }

                ApplyChanges(renderer);
                
                if (!copyToSameFile)
                {
                    var prev = _copyPaste.ToList();

                    Copy(_explorer); // Fake a "Ctrl+C" right after pasting to another archive
                    
                    foreach (var obj in _copyPaste.ToList())
                    {
                        if (obj.GetObject() is CCutsceneCamera ||
                            obj is NSTEntity e && (
                                e.Object is CScriptTriggerEntity && !prev.Contains(newEntities.FirstOrDefault(e => e.Value == obj).Key) ||
                                e.Object.GetComponents().Count == 1 && e.Object.GetComponents()[0] is CCameraProxyComponentData
                            ))
                        {
                            _copyPaste.Remove(obj);
                        }
                    }
                }

                ModalRenderer.CloseLoadingModal();
                
                callback?.Invoke(newObjects[0]); // phew, we're done...
            })
            .ContinueWith(t =>
            {
                if (t.IsFaulted && t.Exception != null)
                {
                    foreach (var ex in t.Exception.InnerExceptions)
                    {
                        CrashHandler.Log($"Error pasting objects: {ex.Message}\n{ex.StackTrace}");
                    }
                    string logPath = CrashHandler.WriteLogsToFile();
                    ModalRenderer.ShowMessageModal("Error", $"An error occured while pasting the objects. Log saved to:\n\n{logPath}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }

        private void OnKeyDown(object? sender, THREE.Silk.KeyboardKeyEventArgs e)
        {
            if (e.Key != Silk.NET.Input.Key.AltLeft) return;
            if (_selection.Count == 0 || _selection[0] is not NSTEntity entity) return;
            if (entity.Model == null || entity.Object3D == null || entity.Object.ObjectName?.StartsWith("Crate_") != true) return;

            THREE.Vector3 worldPos = entity.Object3D.GetWorldPosition(new THREE.Vector3());
            float crateSize = entity.Model.Name.Contains("Iron") || entity.Model.Name.Contains("Switch") ? 76.5f : 80.0f;

            NSTEntity? closestCrate = null;
            float closest = float.PositiveInfinity;

            foreach (NSTEntity otherEntity in _explorer.InstanceManager.AllEntities)
            {
                if (otherEntity.IsSelected || !otherEntity.IsSpawned) continue;
                if (otherEntity.Object is not CEntity || otherEntity.Object.ObjectName?.StartsWith("Crate_") != true) continue;

                float distance = worldPos.DistanceTo(otherEntity.Position);

                if ((closestCrate == null || distance < closest) && distance < crateSize * 3.0f)
                {
                    closestCrate = otherEntity;
                    closest = distance;
                }
            }

            if (closestCrate == null) return;
            
            THREE.Vector3 snappedPosition = BlockSnap(worldPos, closestCrate.Position, crateSize);

            _selectionContainer.Position.Add(snappedPosition - worldPos);

            ApplyChanges(_explorer.ArchiveRenderer);

            _gizmos.StopDragging();
        }

        private static THREE.Vector3 BlockSnap(THREE.Vector3 a, THREE.Vector3 b, float size)
        {
            THREE.Vector3 delta = a - b;
            float absX = MathF.Abs(delta.X);
            float absY = MathF.Abs(delta.Y);
            float absZ = MathF.Abs(delta.Z);

            if (absX >= absY && absX >= absZ) 
                return b + new THREE.Vector3(MathF.Sign(delta.X) * size, 0f, 0f);
            else if (absY >= absX && absY >= absZ) 
                return b + new THREE.Vector3(0f, MathF.Sign(delta.Y) * size, 0f);
            else
                return b + new THREE.Vector3(0f, 0f, MathF.Sign(delta.Z) * size);
        }
    }
}