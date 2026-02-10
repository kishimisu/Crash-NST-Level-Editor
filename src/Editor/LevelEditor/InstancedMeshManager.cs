using Alchemy;
using ImGuiNET;
using System.Text.RegularExpressions;

namespace NST
{
    public class InstanceManager
    {
        public List<NSTEntity> Entities { get; } = [];

        private NSTModel? _model = null;
        private THREE.Object3D group = new THREE.Group();

        public InstanceManager(NSTModel? model = null) => _model = model;

        public void Add(NSTEntity entity)
        {
            entity.InstanceManager = this;
            Entities.Add(entity);
        }

        public void Remove(NSTEntity entity)
        {
            entity.InstanceManager = null;
            Entities.Remove(entity);
        }

        public void ConvertToInstanced(THREE.Object3D scene, LevelExplorer.DebugMode debugMode)
        {
            // Console.WriteLine($"Converting {_model?.Name} to instanced: {entities.Where(e => !e.IsSelected).Count()}/{entities.Count}");

            scene.Remove(group);

            if (Entities.Count == 0) return;

            group = CreateInstancedGroup(debugMode);

            group.UserData["instance"] = this;
            
            group.Traverse(e => 
            {
                e.UserData["instance"] = this;

                if (debugMode != LevelExplorer.DebugMode.None && e.Material != null)
                {
                    e.Material = new THREE.MeshPhongMaterial() { Shininess = NSTMaterial.DefaultShininess };
                }
            });

            scene.Add(group);

            SetLayer();

            Entities.ForEach(e => 
            {
                if (e.IsSelected) return;

                foreach (THREE.Object3D child in e.CreateChildrenObject3D())
                {
                    group.Add(child);
                }
            });
        }

        private THREE.Group CreateInstancedGroup(LevelExplorer.DebugMode debugMode)
        {
            var instances = Entities.Where(e => !e.IsSelected);

            THREE.Color highlightColor = new THREE.Color(0xff5141);
            THREE.Color defaultColor = new THREE.Color(0xb6b6b6);

            List<THREE.Matrix4> matrices = instances.Select(e => e.ObjectToWorld(true)).ToList();

            List<THREE.Color> colors = (debugMode switch
            {   
                LevelExplorer.DebugMode.Prefabs => instances.Select(e => e.IsPrefabChild ? highlightColor : defaultColor),
                LevelExplorer.DebugMode.Collisions => instances.Select(e => e.CollisionShapeIndex != -1 ? highlightColor : defaultColor),
                LevelExplorer.DebugMode.GameObjects => instances.Select(e => e.Object.GetType() != typeof(igEntity) ? highlightColor : defaultColor),
                LevelExplorer.DebugMode.Instanced => instances.Select(e => highlightColor),

                _ => _model == null 
                    ? instances.Select(e => e.Color)
                    : instances.Select(e => new THREE.Color(1, 1, 1)) 
            }
            ).ToList();

            if (_model == null)
            {
                return NSTModel.CreateInstancedCubes(matrices, colors);
            }
            else
            {
                return _model.CreateInstancedMeshes(matrices, colors);
            }
        }

        private void SetLayer()
        {
            string? modelName = _model?.Name.ToLower();

            if (Entities.Count > 0 && Entities[0].Object is CScriptTriggerEntity)
            {
                group.Layers.Set((int)LevelExplorer.CameraLayer.Triggers);
                group.Traverse(o => o.Layers.Set((int)LevelExplorer.CameraLayer.Triggers));
            }
            else if (modelName == null)
            {
                group.Layers.Set((int)LevelExplorer.CameraLayer.AllEntities);
                group.Traverse(o => o.Layers.Set((int)LevelExplorer.CameraLayer.AllEntities));
            }
            else if (modelName.Contains("cloud"))
            {
                group.Layers.Set((int)LevelExplorer.CameraLayer.Clouds);
                group.Traverse(o => o.Layers.Set((int)LevelExplorer.CameraLayer.Clouds));
            }
            else if (modelName.Contains("shadow"))
            {
                group.Layers.Set((int)LevelExplorer.CameraLayer.Shadows);
                group.Traverse(o => o.Layers.Set((int)LevelExplorer.CameraLayer.Shadows));
            }
        }
    }

    public class InstancedMeshManager
    {
        public THREE.Group RootObject { get; } = new THREE.Group();

        public List<NSTEntity> AllEntities { get; } = [];
        public List<NSTObject> AllObjects { get; } = [];
        public Dictionary<NamedReference, NSTObject> AllReferences { get; } = [];
        public Dictionary<igEntity, NSTEntity> PrefabTemplates { get; } = [];
        public HashSet<NSTEntity> FakePrefabChilds { get; } = [];

        private LevelExplorer _explorer;
        private Dictionary<NSTModel, InstanceManager> _instances = [];
        private InstanceManager _entitiesWithoutModel = new InstanceManager();

        public InstancedMeshManager(LevelExplorer explorer, THREE.Scene scene)
        {
            _explorer = explorer;
            scene.Add(RootObject);
        }

        public void Register(List<NSTObject> objects)
        {
            foreach (NSTObject obj in objects)
            {
                Register(obj);
            }

            List<NSTEntity> fakeTemplates = RegisterFakePrefabs();

            foreach (NSTEntity entity in AllEntities.ToList())
            {
                entity.InitPrefabChildren(this);
            }

            foreach (NSTObject obj in AllObjects)
            {
                if (obj is NSTEntity entity)
                {
                    if (entity.IsPrefabChild && fakeTemplates.Contains(entity.PrefabTemplate!))
                    {
                        FakePrefabChilds.Add(entity);
                    }

                    entity.InitChildren(_explorer, AllObjects);
                }
                else if (obj is NSTCamera camera)
                {
                    camera.Setup(AllEntities);
                }
                else if (obj is NSTCameraBox cameraBox)
                {
                    cameraBox.Setup(AllObjects);
                }
            }

            RefreshInstances(AllObjects);
        }

        public void RegisterNew(List<NSTObject> objects)
        {
            foreach (NSTObject obj in objects)
            {
                Register(obj);
            }

            foreach (NSTEntity entity in objects.OfType<NSTEntity>())
            {
                entity.InitPrefabChildren(this);
            }

            foreach (NSTObject obj in objects)
            {
                if (obj is NSTEntity entity)
                {
                    entity.InitChildren(_explorer, AllObjects);
                }
                else if (obj is NSTCamera camera)
                {
                    camera.Setup(AllEntities);
                }
                else if (obj is NSTCameraBox cameraBox)
                {
                    cameraBox.Setup(AllObjects);
                }
            }
        }

        private List<NSTEntity> RegisterFakePrefabs()
        {
            var regex = new Regex(@"^_FakePrefab_(.+?)___(.+)$");
            List<NSTEntity> fakeTemplates = [];

            foreach (NSTEntity template in AllEntities.ToList())
            {
                var match = regex.Match(template.Object.ObjectName!);
                if (!match.Success) continue;

                string parentName = match.Groups[1].Value;
                string childName = match.Groups[2].Value;

                NSTEntity? parent = AllEntities.Find(e => e.Object.ObjectName == parentName);
                if (parent == null) continue;

                template.Object.ObjectName = childName;
                parent.Object.GetComponent<igPrefabComponentData>()?._prefabEntities?._data.Add(template.Object);

                THREE.Matrix4 parentTransform = parent.Object.GetTransformMatrix().Inverted();
                THREE.Vector3 localPos = parentTransform * template.Position;
                template.Object._parentSpacePosition = localPos.ToVec3MetaField();
                fakeTemplates.Add(template);
                // Console.WriteLine($"Added fake child to prefab: {template.Object.ObjectName}, {parentName}, {childName}");
            }

            return fakeTemplates;
        }

        public void Register(NSTObject obj)
        {            
            AllObjects.Add(obj);
            AllReferences.TryAdd(obj.ToReference(), obj);

            if (obj is not NSTEntity entity) return;

            AllEntities.Add(entity);

            if (!entity.IsSpawned) return;

            if (entity.Model != null)
            {
                if (!_instances.TryGetValue(entity.Model, out InstanceManager? value))
                {
                    value = new InstanceManager(entity.Model);
                    _instances[entity.Model] = value;
                }

                value.Add(entity);
            }
            else if (entity.Object is not CScriptTriggerEntity && entity.Object is not CDynamicClipEntity && 
                     entity.Object.GetComponent<CTriggerVolumeBoxComponentData>() == null && 
                     entity.Object.GetComponent<igPrefabComponentData>() == null)
            {
                _entitiesWithoutModel.Add(entity);
            }
        }

        public void Unregister(NSTObject obj)
        {
            AllObjects.Remove(obj);
            AllReferences.Remove(obj.ToReference());

            foreach (NSTObject parent in obj.Parents)
            {
                parent.Children.Remove(obj);
            }

            foreach (NSTObject child in obj.Children)
            {
                child.Parents.Remove(obj);
            }
            
            if (obj is NSTEntity entity)
            {
                AllEntities.Remove(entity);
                entity.InstanceManager?.Remove(entity);
            }

            if (obj.Object3D != null)
            {
                obj.Object3D.Parent.Remove(obj.Object3D);
                obj.Object3D = null;
            }
        }

        public List<NSTObject> SelectFromRaycast(THREE.Intersection hit)
        {
            if (hit.object3D.UserData.TryGetValue("entity", out object? entityObj))
            {
                return Select((NSTObject)entityObj);
            }
            else if (hit.object3D.UserData.TryGetValue("instance", out object? instanceObj))
            {
                InstanceManager instance = (InstanceManager)instanceObj;
                NSTEntity entity = instance.Entities.Where(e => !e.IsSelected).ElementAt(hit.instanceId);
                return Select(entity);
            }
            else if (hit.object3D.UserData.TryGetValue("spline", out object? splineObj))
            {
                NSTSpline spline = (NSTSpline)splineObj;
                NSTSplineControlPoint controlPoint = spline._controlPoints[hit.instanceId];
                return Select(controlPoint);
            }
            else if (hit.object3D.UserData.TryGetValue("splineRotation", out object? splineRotationObj))
            {
                return Select((NSTSplineRotationKeyFrame)splineRotationObj);
            }
            else if (hit.object3D.UserData.TryGetValue("splineMarker", out object? splineMarkerObj))
            {
                return Select((NSTSplineMarker)splineMarkerObj);
            }
            else if (hit.object3D.UserData.TryGetValue("waypoint", out object? waypointObj))
            {
                return Select((NSTWaypoint)waypointObj);
            }

            return [];
        }

        public List<NSTObject> Select(NSTObject obj, bool fromTree = false)
        {
            List<NSTEntity> selection = _explorer.SelectionManager._selection.OfType<NSTEntity>().ToList();
            
            bool shiftPressed = ImGui.IsKeyDown(ImGuiKey.LeftShift);
            bool selectionEmpty = selection.Count == 0;

            if (obj is NSTEntity entity)
            {
                bool alreadySelected = !selectionEmpty && selection.All(e => e.Object == entity.Object);

                if (entity.Object is CScriptTriggerEntity && (!entity.IsPrefabChild || (entity.IsSelected && entity.OutlineTrigger)))
                {
                    if (shiftPressed)
                    {
                        entity.OutlineTrigger = true;
                        return [ entity ];
                    }

                    List<NSTObject> children = entity.Children.Where(c => c is NSTEntity e && e.IsSpawned).ToList();

                    entity.OutlineTrigger = false;

                    if (children.Count > 1)
                    {
                        children.Insert(0, entity);

                        if (!entity.IsSelected && children.Any(e => !e.IsSelected))
                        {
                            return children;
                        }
                    }

                    if (alreadySelected) return [];

                    entity.OutlineTrigger = true;

                    return [ entity ];
                }

                if (alreadySelected && entity.Object is CDynamicClipEntity)
                {
                    return [];
                }

                if (entity.IsPrefabChild && entity.ParentPrefabInstance?.Children.Count(e => e is NSTEntity entity && entity.IsPrefabChild) < 45)
                {
                    bool triggerPassThrough = !selectionEmpty && selection.All(e => e.Object is CScriptTriggerEntity && e.IsPrefabChild);

                    if (fromTree || (shiftPressed && selectionEmpty) || (!shiftPressed && (entity.ParentPrefabInstance.IsSelected || triggerPassThrough)))
                    {
                        Console.WriteLine("Select prefab child instances");
                        return SelectChildInstances(entity).Cast<NSTObject>().ToList();
                    }
                    else
                    {
                        Console.WriteLine("Select prefab group");
                        return SelectPrefabGroup(entity.ParentPrefabInstance).Cast<NSTObject>().ToList();
                    }
                }
                else if (entity.IsPrefabInstance)
                {
                    return SelectPrefabGroup(entity).Cast<NSTObject>().ToList();
                }

                entity.ClickedAgain = entity.IsSelected && !entity.ClickedAgain && !entity.Parents.Any(p => p.IsSelected);

                List<NSTObject> outSelection = [ entity ];

                if (entity.ClickedAgain && !shiftPressed)
                {
                    foreach (NSTEntity parent in entity.Parents.OfType<NSTEntity>().Where(p => p.Object is CScriptTriggerEntity))
                    {
                        parent.OutlineTrigger = false;
                        outSelection.Add(parent);
                    }
                }

                return outSelection;
            }
            else if (obj is NSTSplineControlPoint controlPoint)
            {
                if (shiftPressed || controlPoint.Parent.Parent.IsSelected || controlPoint.Parent.Children.Any(e => e.IsSelected))
                {
                    Console.WriteLine("Select control point");
                    controlPoint.Parent.Parent.Components?.SelectComponent<CSplineComponentData>();
                    controlPoint.Parent.OpenControlPointList = true;
                    return [ controlPoint ];
                }
                else
                {
                    Console.WriteLine("Select spline (from control point)");
                    return [ controlPoint.Parent.Parent ];
                }
            }
            else if (obj is NSTSplineRotationKeyFrame keyframe)
            {
                Console.WriteLine("Select keyframe");
                keyframe.Parent.OpenRotationList = true;
                return [ keyframe ];
            }
            else if (obj is NSTSplineMarker marker)
            {
                Console.WriteLine("Select marker");
                marker.Parent.OpenMarkerList = true;
                return [ marker ];
            }
            else if (obj is NSTSpline spline)
            {
                Console.WriteLine("Select spline");
                return [ spline.Parent ];
            }
            else if (obj is NSTCamera cam)
            {
                if (obj.GetObject() is CSplineCamera splineCamera && cam.Children.FirstOrDefault() is NSTObject splineEntity && (!cam.IsSelected || !splineEntity.IsSelected))
                {
                    return [ cam, splineEntity ];
                }
            }

            return [ obj ];
        }

        private List<NSTEntity> SelectPrefabGroup(NSTEntity prefabInstance)
        {
            List<NSTEntity> prefabs = [ prefabInstance ];

            prefabs.AddRange(prefabInstance.Children.OfType<NSTEntity>().Where(e => e.ParentPrefabInstance == prefabInstance && e.IsSpawned));

            prefabs.ForEach(e => e.OutlineTrigger = false);

            return prefabs;
        }

        private List<NSTEntity> SelectChildInstances(NSTEntity prefabChild)
        {
            List<NSTEntity> instances = [ prefabChild ];

            foreach (NSTEntity child in prefabChild.PrefabTemplate!.PrefabTemplateInstances)
            {
                if (child == prefabChild) continue;

                instances.Add(child);
            }
            
            instances.ForEach(e => e.OutlineTrigger = true);

            return instances;
        }

        public void RefreshInstances(List<NSTObject> entities)
        {
            if (entities.Count == 0) return;

            HashSet<InstanceManager> instances = [];

            // Console.WriteLine($"Refresh {entities.OfType<NSTEntity>().Count()} entities");
            
            foreach (NSTObject obj in entities)
            {
                // Console.WriteLine($"Refresh {entity.Object.ObjectName}, InstanceManager: {entity.InstanceManager}, IsInstanced: {entity.IsInstanced}, Object3D: {entity.Object3D}, IsSelected: {entity.IsSelected}");
                
                if (obj is NSTEntity entity)
                {
                    if (entity.IsPrefabTemplate) continue;
                
                    if (entity.InstanceManager != null)
                    {
                        instances.Add(entity.InstanceManager);
                    }
                    else if (!entity.IsSelected)
                    {
                        RootObject.Add(entity.CreateObject3D());
                    }
                }
                else
                {
                    if (obj is NSTSplineControlPoint cp)
                    {
                        if (cp.Parent.Rotations3D != null && !cp.Parent.Parent.IsSelected && cp.Parent._controlPoints.All(c => !c.IsSelected) && cp.Parent._rotationKeyFrames.All(k => !k.IsSelected))
                        {
                            cp.Parent.Object3D!.Remove(cp.Parent.Rotations3D);
                            cp.Parent.Rotations3D = null;
                        }
                        continue;
                    }
                    if (obj is NSTSplineRotationKeyFrame kf)
                    {
                        if (kf.Parent.Rotations3D != null && !kf.Parent.Parent.IsSelected && kf.Parent._controlPoints.All(c => !c.IsSelected) && kf.Parent._rotationKeyFrames.All(k => !k.IsSelected))
                        {
                            kf.Parent.Object3D!.Remove(kf.Parent.Rotations3D);
                            kf.Parent.Rotations3D = null;
                        }
                        else if (kf.Parent.Rotations3D != null && kf.Object3D == null)
                        {
                            kf.Parent.Rotations3D.Add(kf.CreateObject3D());
                        }
                        continue;
                    }
                    if (obj is NSTWaypoint || obj is NSTSplineVelocityKeyFrame)
                    {
                        continue;
                    }
                    
                    if (!obj.IsSelected)
                    {
                        RootObject.Add(obj.CreateObject3D());
                    }
                }
            }

            foreach (InstanceManager instance in instances)
            {
                instance.ConvertToInstanced(RootObject, _explorer.DebugRenderMode);
            }
        }
        
        public void RefreshModel(NSTEntity entity, NSTModel? model = null, bool findMissingModel = true)
        {
            if (model == null && findMissingModel)
            {
                IgzFile? igz = _explorer.FileManager.GetIgz(entity.ArchiveFile);

                if (igz == null)
                {
                    Console.WriteLine($"[RefreshModel] Error: igz file not found for {entity.Object} (${entity.ArchiveFile})");
                    return;
                }

                string? modelName = entity.Object.GetModelName(igz, _explorer);

                if (modelName != null)
                {
                    modelName = Path.GetFileNameWithoutExtension(modelName).ToLower();

                    if (!LevelExplorer.CachedModels.TryGetValue(modelName, out model))
                    {
                        Console.WriteLine($"Warning: Model not found ({modelName})");
                    }
                }
            }

            Unregister(entity);

            entity.Model = model;

            Register([ entity ]);

            if (entity.IsSelected)
            {
                _explorer.SelectionManager.UpdateSelection([ entity ]);
            }
            else
            {
                RefreshInstances([ entity ]);
            }

            _explorer.RenderNextFrame = true;
        }
    }
}