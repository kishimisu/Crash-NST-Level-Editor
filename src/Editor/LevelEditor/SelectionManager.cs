using Alchemy;
using Havok;

namespace NST
{
    public class SelectionManager
    {
        static List<NSTObject> _copyPaste = [];
        static LevelExplorer _copyExplorer;

        public List<NSTObject> _selection = [];
        public THREE.Group _selectionContainer = new THREE.Group();
        public LevelExplorer _explorer;

        private readonly THREE.Silk.TransformControls _gizmos;
        private readonly THREE.OutlinePass _outlinePass;
        private bool _revertGizmos = false;

        public SelectionManager(THREE.Object3D rootObject, THREE.Silk.TransformControls gizmos, THREE.OutlinePass outlinePass, LevelExplorer explorer)
        {
            _gizmos = gizmos;
            _outlinePass = outlinePass;
            _explorer = explorer;

            rootObject.Add(_selectionContainer);

            _gizmos.Attach(_selectionContainer);
            _gizmos.Visible = false;
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

                obj.IsSelected = false;
            }
        }

        public void ApplyChanges(ActiveFileManager fileManager, IgArchiveRenderer archiveRenderer)
        {
            HashSet<NSTSpline> refreshSplines = [];

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

                Console.WriteLine($"Apply changes for {entity.ObjectName}");

                entity._parentSpacePosition._x = worldPos.X;
                entity._parentSpacePosition._y = worldPos.Y;
                entity._parentSpacePosition._z = worldPos.Z;

                if (entity._transform == null && (worldEuler.ToVector3().LengthSq() > 1e-3f || (worldScale - THREE.Vector3.One()).LengthSq() > 1e-3f))
                {
                    entity._transform = new igEntityTransform();
                    entity._transform.MemoryPool = entity.MemoryPool;
                }

                if (entity._transform != null)
                {
                    entity._transform._parentSpaceRotation._x = worldEuler.X;
                    entity._transform._parentSpaceRotation._y = worldEuler.Y;
                    entity._transform._parentSpaceRotation._z = worldEuler.Z;

                    entity._transform._nonUniformPersistentParentSpaceScale._x = worldScale.X;
                    entity._transform._nonUniformPersistentParentSpaceScale._y = worldScale.Y;
                    entity._transform._nonUniformPersistentParentSpaceScale._z = worldScale.Z;
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
            }

            foreach (NSTSpline spline in refreshSplines)
            {
                spline.RefreshDistances(_explorer);
                spline.ComputeDistances();
                spline.RefreshSpline();
            }
        }

        public bool Copy(LevelExplorer explorer)
        {
            _copyPaste = _selection.Where(e => e is NSTEntity || e is NSTCamera || e is NSTCameraBox).ToList();
            _copyExplorer = explorer;
            return _copyPaste.Count > 0;
        }

        public void Paste(IgArchiveRenderer renderer, ActiveFileManager fileManager, THREE.Vector3 spawnPoint, Action<NSTObject?>? callback = null)
        {
            if (_copyPaste.Count == 0) return;

            bool copyToSameFile = (_explorer == _copyExplorer);

            Dictionary<IgArchiveFile, List<NSTObject>> instances = _copyPaste
                    .GroupBy(x => x.ArchiveFile)
                    .ToDictionary(x => x.Key, x => x.ToList());

            List<NSTObject> newObjects = new List<NSTObject>();
            Dictionary<NSTEntity, NSTEntity> newEntities = new Dictionary<NSTEntity, NSTEntity>();
            Dictionary<NSTEntity, NSTEntity> newCollisionEntities = new Dictionary<NSTEntity, NSTEntity>();

            ClearSelection(true);

            ModalRenderer.ShowLoadingModal("Pasting selection...");

            Task.Run(() =>
            {
                foreach ((IgArchiveFile file, List<NSTObject> objects) in instances)
                {
                    List<NSTEntity> entities = objects.OfType<NSTEntity>().ToList();
                    IgzFile srcIgz = copyToSameFile ? fileManager.GetIgz(file)! : _copyExplorer.FileManager.GetIgz(file)!;
                    
                    IgzFile? dstIgz = null;
                    IgArchiveFile? dstFile = null;

                    if (copyToSameFile)
                    {
                        dstFile = file;
                        dstIgz = srcIgz;
                    }
                    else
                    {
                        string path = _explorer.Archive.FindMainMapFile()?.GetPath().Replace(".igz", $"_{file.GetName()}")
                                      ?? "maps/Custom/" + file.GetName();

                        dstFile = renderer.Archive.FindFile(path, FileSearchType.Path);

                        if (dstFile == null)
                        {
                            dstIgz = new IgzFile(path);
                            dstFile = new IgArchiveFile(path);
                            
                            renderer.AddFile(dstFile);

                            fileManager.Add(dstFile, dstIgz, true);
                        }
                        else
                        {
                            dstIgz = fileManager.GetIgz(dstFile)!;
                        }
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

                        if (copyToSameFile)
                        {
                            igEntity entityClone = srcIgz.AddClone(entity.Object, null, clones, CloneMode.Deep | CloneMode.SkipComponents);

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
                            renderer.Clone(entity.Object, _copyExplorer.Archive, srcIgz, dstIgz, clones);
                        }
                    }

                    foreach ((igObject src, igObject dst) in clones)
                    {
                        renderer.SetObjectUpdated(dstFile, dst);

                        if (src is CCamera srcCam && dst is CCamera dstCam)
                        {
                            NSTCamera? originalCam = (NSTCamera?)_copyExplorer.InstanceManager.AllObjects.Find(e => e is NSTCamera c && c.Object == srcCam);
                            newObjects.Add(new NSTCamera(dstCam, dstFile));
                            continue;
                        }
                        if (src is CCameraBox srcCamBox && dst is CCameraBox dstCamBox)
                        {
                            NSTCameraBox? originalCam = (NSTCameraBox?)_copyExplorer.InstanceManager.AllObjects.Find(e => e is NSTCameraBox c && c.Object == srcCamBox);
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
                foreach ((NSTEntity original, NSTEntity clone) in newEntities)
                {
                    List<NSTEntity> prefabChildren = clone.InitPrefabChildren(_explorer.InstanceManager);

                    if (prefabChildren.Count > 0)
                    {
                        List<NSTEntity> originalPrefabChildren = original.Children.OfType<NSTEntity>().Where(e => e.ParentPrefabInstance == original).ToList();

                        for (int i = 0; i < prefabChildren.Count; i++)
                        {
                            if (originalPrefabChildren[i].CollisionPrefabHash > 0)
                            {
                                Console.WriteLine("Add prefab child collision: " + prefabChildren[i].Object.ObjectName + " (" + original.Object.ObjectName + "), template: " + prefabChildren[i].IsPrefabTemplate);
                                newCollisionEntities.Add(originalPrefabChildren[i], prefabChildren[i]);
                            }

                            newObjects.Add(prefabChildren[i]);
                        }
                    }
                }
                foreach (NSTEntity clone in newEntities.Values)
                {
                    clone.InitChildren(_explorer, _explorer.InstanceManager.AllObjects);
                    clone.InitScriptTriggerEntity(_explorer, _explorer.InstanceManager.AllEntities);
                }

                // Register new collisions
                foreach ((NSTEntity original, NSTEntity clone) in newCollisionEntities)
                {
                    if (copyToSameFile)
                    {
                        if (_copyExplorer.FileManager.GetInfos(original.ArchiveFile)!.updatedCollisions.TryGetValue(original.Object, out CollisionUpdateInfos? infos) && infos.shapeInstance != null)
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

                        // if (clone.IsPrefabTemplate)
                        // {
                        //     Console.WriteLine("Paste prefab collision shape to another level, parent: " + clone.PrefabTemplateInstances[0].ParentPrefabInstance?.Object);
                        //     renderer.SetEntityUpdated(clone.PrefabTemplateInstances[0], shape);
                        // }
                        
                        // Console.WriteLine($"IsPrefabInstance: {clone.IsPrefabInstance}, IsPrefabTemplate: {clone.IsPrefabTemplate}, IsPrefabChild: {clone.IsPrefabChild}, CollisionPrefabHash: {clone.CollisionPrefabHash}, CollisionShapeIndex: {clone.CollisionShapeIndex}");
                        
                        if (clone.IsPrefabChild)
                        {
                            Console.WriteLine($"Paste prefab collision shape to another level ({clone.ParentPrefabInstance?.Object.ObjectName} -> {clone.Object.ObjectName}), hash: {original.CollisionPrefabHash}");
                            clone.CollisionPrefabHash = original.CollisionPrefabHash;
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
                else
                {
                    _selectionContainer.Position.Copy(spawnPoint);
                }

                ApplyChanges(fileManager, renderer);

                ModalRenderer.CloseLoadingModal();
                
                callback?.Invoke(newObjects[0]);
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
    }
}