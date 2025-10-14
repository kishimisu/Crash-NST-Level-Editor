using Alchemy;
using Havok;

namespace NST
{
    public class SelectionManager
    {
        static List<NSTEntity> _copyPaste = [];
        static LevelExplorer _copyExplorer;

        THREE.Silk.TransformControls _gizmos;
        THREE.OutlinePass _outlinePass;

        public List<NSTObject> _selection = [];
        public THREE.Group _selectionContainer = new THREE.Group();
        public LevelExplorer _explorer;

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

            if (_selection.Count == 0)
            {
                _selectionContainer.Position.Copy(object3D.Position);
                _selectionContainer.Quaternion.Copy(THREE.Quaternion.Identity());
                _selectionContainer.Scale.Copy(THREE.Vector3.One());
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
            
            _explorer.InstanceManager.ConvertToInstanced([obj]);

            _selectionContainer.Remove(obj.Object3D!);
            _selection.Remove(obj);
            _outlinePass.selectedObjects.Remove(obj.Object3D!);
        }

        public void ClearSelection(bool refreshInstances = false)
        {
            _explorer.InstanceManager.ConvertToInstanced(_selection);

            if (refreshInstances)
            {
                _explorer.InstanceManager.RefreshInstances(_selection);
            }

            _selection.Clear();
            _outlinePass.selectedObjects.Clear();
        }

        public void ApplyChanges(ActiveFileManager fileManager, IgArchiveRenderer archiveRenderer)
        {
            foreach (NSTObject obj in _selection)
            {
                if (obj is NSTSplineControlPoint controlPoint)
                {
                    THREE.Vector3 wp = controlPoint.Object3D!.GetWorldPosition(new THREE.Vector3());
                    THREE.Vector3 localPos = wp - controlPoint._parent._parent.Position;
                    controlPoint.Object._position._x = localPos.X;
                    controlPoint.Object._position._y = localPos.Y;
                    controlPoint.Object._position._z = localPos.Z;
                    _explorer.InstanceManager.RefreshInstances([controlPoint._parent._parent]);
                    fileManager.GetOrCreateRenderer(controlPoint.ArchiveFile, archiveRenderer).SetUpdated(controlPoint.Object);
                    continue;
                }

                if (obj is not NSTEntity entity3D) continue;

                if (entity3D.IsPrefabChild) // Skip prefab children
                {
                    var entities = _selection.OfType<NSTEntity>();

                    if (entities.Any(e => e == entity3D.ParentPrefabInstance)) 
                        continue; // Root prefab found in selection
                    if (entities.Where(e => e.Object == entity3D.Object).ToList().IndexOf(entity3D) > 0) 
                        continue; // Other instances of this prefab found in selection (only update the first one)
                }

                igEntity entity = entity3D.Object;

                // Get world transform
                THREE.Vector3 worldPos = entity3D.Object3D!.GetWorldPosition(new THREE.Vector3());
                THREE.Quaternion worldQuaternion = entity3D.Object3D.GetWorldQuaternion(new THREE.Quaternion());
                THREE.Vector3 worldScale = entity3D.Object3D.GetWorldScale();

                // If prefab child, the transform needs to be converted to local space
                if (entity3D.IsPrefabChild && entity3D.ParentPrefabInstance != null)
                {
                    THREE.Matrix4 parentMatrixInverse = entity3D.ParentPrefabInstance.ObjectToWorld().Invert();
                    THREE.Matrix4 worldMatrix = new THREE.Matrix4().Compose(worldPos, worldQuaternion, worldScale);
                    THREE.Matrix4 localMatrix = parentMatrixInverse * worldMatrix;

                    localMatrix.Decompose(worldPos, worldQuaternion, worldScale);
                }

                THREE.Euler worldEuler = new THREE.Euler().SetFromQuaternion(worldQuaternion, THREE.RotationOrder.ZYX);

                Console.WriteLine($"Apply changes for {entity.ObjectName}: {entity._parentSpacePosition._x}, {entity._parentSpacePosition._y}, {entity._parentSpacePosition._z} => {worldPos.X}, {worldPos.Y}, {worldPos.Z}");

                entity._parentSpacePosition._x = worldPos.X;
                entity._parentSpacePosition._y = worldPos.Y;
                entity._parentSpacePosition._z = worldPos.Z;

                if (entity._transform == null && (worldEuler != new THREE.Euler(0, 0, 0) || worldScale != THREE.Vector3.One()))
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

                archiveRenderer.SetEntityUpdated(entity3D.ArchiveFile, entity, entity3D.CollisionShapeIndex);

                if (entity3D.IsPrefabInstance)
                {
                    _explorer.InstanceManager.RefreshInstances(entity3D.Children.Where(e => e is NSTEntity entity && entity.IsPrefabChild).ToList());
                }
            }
        }

        public void Copy(LevelExplorer explorer)
        {
            _copyPaste = _selection.OfType<NSTEntity>().ToList();
            _copyExplorer = explorer;
        }

        public NSTObject? Paste(IgArchiveRenderer renderer, ActiveFileManager fileManager, THREE.Vector3 spawnPoint)
        {
            if (_copyPaste.Count == 0) return null;

            bool copyToSameFile = (_explorer == _copyExplorer);

            Dictionary<IgArchiveFile, List<NSTEntity>> instances = _copyPaste
                    .GroupBy(x => x.ArchiveFile)
                    .ToDictionary(x => x.Key, x => x.ToList());

            Dictionary<NSTEntity, NSTEntity> newEntities = [];

            ClearSelection(true);

            foreach ((IgArchiveFile file, List<NSTEntity> entities) in instances)
            {
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
                    string path = "maps/Custom/" + file.GetName();
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
                
                Console.WriteLine($"Pasting ({entities.Count}) into {dstIgz.GetName()}: ({(copyToSameFile ? "same file" : "external file")})\n- " + string.Join("\n- ", _copyPaste.Select(x => x.Object)));

                Dictionary<igObject, igObject> clones = [];

                foreach (NSTEntity entity in entities)
                {
                    if (entity.IsPrefabChild)
                    {
                        if (entities.Any(e => e == entity.ParentPrefabInstance)) continue;
                        if (entities.Where(e => e.Object == entity.Object).ToList().IndexOf(entity) > 0) continue;
                    }

                    if (copyToSameFile)
                    {
                        igEntity entityClone = srcIgz.AddClone(entity.Object, null, clones, CloneMode.Deep | CloneMode.SkipComponents);
                        NSTEntity clone = entity.Clone(entityClone);

                        if (entity.IsPrefabChild)
                        {
                            entity.ParentPrefabInstance?.Object.GetComponent<igPrefabComponentData>()?._prefabEntities?._data.Add(entityClone);

                            foreach (NSTEntity prefabChild in entity.PrefabTemplate!.PrefabTemplateInstances)
                            {
                                NSTEntity newPrefabChild = clone.CloneAsPrefabChild(prefabChild.ParentPrefabInstance!);
                                _explorer.InstanceManager.Register(newPrefabChild);
                                newEntities.Add(prefabChild, newPrefabChild);
                            }
                        }
                        else
                        {
                            newEntities.Add(entity, clone);
                        }

                        _explorer.InstanceManager.Register(clone);

                        renderer.SetEntityUpdated(file, entityClone, clone.CollisionShapeIndex);

                        if (fileManager.GetRenderer(file) is IgzRenderer igzRenderer)
                        {
                            igzRenderer.TreeView.Add(entityClone);
                        }
                    }
                    else
                    {
                        hknpShapeInstance? shape = _copyExplorer.FindHavokShape(entity);

                        igEntity entityClone = renderer.Clone(entity.Object, _copyExplorer.Archive, srcIgz, dstIgz, clones);

                        NSTEntity clone = entity.Clone(entityClone, dstFile);

                        newEntities.Add(entity, clone);

                        _explorer.InstanceManager.Register(clone);

                        renderer.SetEntityUpdated(dstFile, entityClone, shapeInstance: shape);

                        if (fileManager.GetRenderer(dstFile) is IgzRenderer igzRenderer)
                        {
                            igzRenderer.TreeView.Add(entityClone);
                        }
                    }
                }
                
                dstFile.SetData(dstIgz.Save());
            }

            if (newEntities.Count == 0) return null;

            foreach ((NSTEntity original, NSTEntity clone) in newEntities)
            {
                clone.InitScriptTriggerEntity(renderer.Archive, newEntities.Values.ToList());

                SelectObject(clone);

                List<NSTEntity> originalPrefabChildren = original.Children.OfType<NSTEntity>().Where(e => e.IsPrefabChild).ToList();
                List<NSTEntity> newPrefabChildren = clone.Children.OfType<NSTEntity>().Where(e => e.IsPrefabChild).ToList();
                List<igEntity> clonePrefabChildren = clone.GetPrefabChildren();

                if (originalPrefabChildren.Count == newPrefabChildren.Count)
                {
                    Console.WriteLine("[Paste][Prefab] Skipping rebuilding prefab children for entity: " + clone.Object);
                    foreach (NSTEntity child in clone.Children.OfType<NSTEntity>().Where(e => e.IsSpawned)) SelectObject(child);
                    continue;
                }
                if (originalPrefabChildren.Count != clonePrefabChildren.Count)
                {
                    Console.WriteLine("Warning: Prefab child count mismatch: " + originalPrefabChildren.Count + " != " + clonePrefabChildren.Count);
                    foreach (NSTEntity child in clone.Children.OfType<NSTEntity>().Where(e => e.IsSpawned)) SelectObject(child);
                    continue;
                }

                foreach ((NSTEntity originalChild, igEntity cloneChild) in originalPrefabChildren.Zip(clonePrefabChildren))
                {
                    if (clone.Children.OfType<NSTEntity>().Any(e => e.Object == cloneChild))
                    {
                        Console.WriteLine("Warning? [Paste][Prefab] Skipping prefab child entity: " + cloneChild);
                        continue;
                    }

                    NSTEntity newPrefabChildTemplate = originalChild.Clone(cloneChild, clone.ArchiveFile);
                    NSTEntity childInstance = newPrefabChildTemplate.CloneAsPrefabChild(clone);

                    _explorer.InstanceManager.Register(newPrefabChildTemplate);
                    _explorer.InstanceManager.Register(childInstance);

                    Console.WriteLine("[Paste][Prefab] Created prefab child entity: " + childInstance.Object);
                }

                foreach (NSTEntity child in clone.Children.OfType<NSTEntity>().Where(e => e.IsSpawned))
                {
                    SelectObject(child);
                }
            }

            _selectionContainer.Position.Copy(spawnPoint);

            ApplyChanges(fileManager, renderer);

            return newEntities.Values.ToList()[0];
        }
    }
}