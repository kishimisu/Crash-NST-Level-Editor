using Alchemy;
using ImGuiNET;

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

            List<THREE.Matrix4> matrices = instances.Select(e => e.ObjectToWorld()).ToList();

            List<THREE.Color> colors = (debugMode switch
            {   
                LevelExplorer.DebugMode.Prefabs => instances.Select(e => e.IsPrefabChild ? highlightColor : defaultColor),
                LevelExplorer.DebugMode.Collisions => instances.Select(e => e.CollisionShapeIndex != -1 ? highlightColor : defaultColor),
                LevelExplorer.DebugMode.GameObjects => instances.Select(e => e.Object.GetType() != typeof(igEntity) ? highlightColor : defaultColor),
                LevelExplorer.DebugMode.Instanced => instances.Select(e => highlightColor),

                _ => _model == null 
                    ? instances.Select(e => new THREE.Color((int)e.Object.GetType().GetUniqueColor()))
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
        public List<NSTEntity> AllEntities { get; } = [];
        public THREE.Group RootObject { get; } = new THREE.Group();

        private LevelExplorer _explorer;
        private Dictionary<NSTModel, InstanceManager> _instances = [];
        private InstanceManager _entitiesWithoutModel = new InstanceManager();
        private InstanceManager _scriptTriggers = new InstanceManager();

        public InstancedMeshManager(LevelExplorer explorer, THREE.Scene scene)
        {
            _explorer = explorer;
            scene.Add(RootObject);
        }

        public void Register(NSTEntity entity, List<NSTEntity>? entities = null)
        {            
            AllEntities.Add(entity);

            if (!entity.IsSpawned) return;

            if (entity.Object is CScriptTriggerEntity)
            {
                _scriptTriggers.Add(entity);
            }
            else if (entity.Model == null)
            {
                _entitiesWithoutModel.Add(entity);
            }
            else if (!_instances.ContainsKey(entity.Model))
            {
                _instances[entity.Model] = new InstanceManager(entity.Model);
                _instances[entity.Model].Add(entity);
            }
            else
            {
                _instances[entity.Model].Add(entity);
            }

            foreach (igEntity child in entity.GetPrefabChildren())
            {
                NSTEntity? prefabEntity = entities == null 
                    ? AllEntities.Find(e => e.Object == child && !e.IsPrefabChild)
                    : AllEntities.Union(entities).FirstOrDefault(e => e.Object == child && !e.IsPrefabChild);

                if (prefabEntity == null)
                {
                    // Console.WriteLine("[Prefab] Missing original prefab child: " + child);
                    continue;
                }
                else if (prefabEntity.InstanceManager != null)
                {
                    Console.WriteLine("[Prefab] Remove original prefab child template: " + child);
                    prefabEntity.InstanceManager.Entities.Remove(prefabEntity);
                    prefabEntity.InstanceManager = null;
                }

                NSTEntity childInstance = prefabEntity.CloneAsPrefabChild(entity);
                Register(childInstance, entities);

                // Console.WriteLine("[Prefab] Register prefab child instance: " + child.ObjectName + " for instance: " + entity.Object);
            }
        }

        public void Register(IgArchive archive, List<NSTEntity> entities)
        {
            // Find templates and hidden entities
            foreach (NSTEntity entity in entities)
            {
                if (!entity.Object._bitfield._canSpawn || entity.Object._bitfield._isArchetype)
                {
                    if (entity.Object.GetType() != typeof(igEntity) || entity.Object.GetComponent<CModelComponentData>() == null)
                    {
                        entity.IsTemplate = true;
                    }
                    else
                    {
                        entity.IsHidden = true;
                    }
                }
                else if (entity.Object.GetComponent<CStaticComponentData>()?._flagsBitfield._disableVisual == true)
                {
                    entity.IsHidden = true;
                }
            }

            foreach (NSTEntity entity in entities)
            {
                entity.InitScriptTriggerEntity(archive, entities);
            }

            foreach (NSTEntity entity in entities)
            {
                Register(entity, entities);
            }

            RefreshInstances(AllEntities.Cast<NSTObject>().ToList());
        }

        public List<NSTObject> SelectFromRaycast(THREE.Intersection hit)
        {
            if (hit.object3D.UserData.ContainsKey("entity"))
            {
                NSTEntity entity = (NSTEntity)hit.object3D.UserData["entity"];

                Console.WriteLine("Hit entity: " + entity.Object.ObjectName);
                return Select(entity);
            }
            else if (hit.object3D.UserData.ContainsKey("instance"))
            {
                InstanceManager instance = (InstanceManager)hit.object3D.UserData["instance"];
                NSTEntity entity = instance.Entities.Where(e => !e.IsSelected).ElementAt(hit.instanceId);

                Console.WriteLine("Hit instance: " + entity.Object.ObjectName);
                return Select(entity);
            }
            else if (hit.object3D.UserData.ContainsKey("spline"))
            {
                NSTSpline spline = (NSTSpline)hit.object3D.UserData["spline"];
                NSTSplineControlPoint controlPoint = spline.Children.OfType<NSTSplineControlPoint>().ElementAt(hit.instanceId);

                Console.WriteLine("Hit spline: " + spline.Object.ObjectName +  " #" + hit.instanceId);
                return Select(controlPoint);
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

                if (entity.Object is CScriptTriggerEntity && alreadySelected)
                {
                    return [];
                }

                if (entity.IsPrefabChild && (entity.PrefabTemplate!.PrefabTemplateInstances.Count > 1 || entity.ParentPrefabInstance!.Children.Where(e => e is NSTEntity entity && entity.IsPrefabChild).Count() < 8))
                {
                    bool triggerPassThrough = !selectionEmpty && selection.All(e => e.Object is CScriptTriggerEntity && e.IsPrefabChild);

                    if (fromTree || (shiftPressed && selectionEmpty) || (!shiftPressed && (entity.ParentPrefabInstance!.IsSelected || triggerPassThrough)))
                    {
                        Console.WriteLine("Select prefab child instances");
                        return SelectChildInstances(entity).Cast<NSTObject>().ToList();
                    }
                    else
                    {
                        Console.WriteLine("Select prefab group");
                        return SelectPrefabGroup(entity.ParentPrefabInstance!).Cast<NSTObject>().ToList();
                    }
                }

                if (entity.IsSelected && selection.Count != 1) return [ entity ];

                List<NSTObject> selected = [ entity ];
                selected.AddRange(entity.Children.OfType<NSTEntity>().Where(e => e.IsSpawned));

                Console.WriteLine("Select " + selected.Count + " entities");
                return selected;
            }
            else if (obj is NSTSplineControlPoint controlPoint)
            {
                if (shiftPressed || controlPoint._parent._parent.IsSelected || controlPoint._parent.Children.Any(e => e.IsSelected))
                {
                    Console.WriteLine("Select control point");
                    return [ controlPoint ];
                }
                else
                {
                    Console.WriteLine("Select spline (from control point)");
                    return [ controlPoint._parent._parent ];
                }
            }
            else if (obj is NSTSpline spline)
            {
                Console.WriteLine("Select spline");
                return [ spline._parent ];
            }

            return [ obj ];
        }

        private List<NSTEntity> SelectPrefabGroup(NSTEntity prefabInstance)
        {
            List<NSTEntity> prefabs = [ prefabInstance ];

            foreach (NSTEntity entity in AllEntities)
            {
                if (entity.IsPrefabChild && entity.ParentPrefabInstance == prefabInstance && entity.IsSpawned)
                {
                    prefabs.Add(entity);
                }
            }

            return prefabs;
        }

        private List<NSTEntity> SelectChildInstances(NSTEntity prefabChild)
        {
            List<NSTEntity> prefabs = [ prefabChild ];

            foreach (NSTEntity entity in AllEntities)
            {
                if (entity != prefabChild && entity.IsPrefabChild && entity.Object == prefabChild.Object)
                {
                    prefabs.Add(entity);
                }
            }

            return prefabs;
        }

        public void ConvertToInstanced(List<NSTObject> objects)
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

        public void RefreshInstances(List<NSTObject> entities)
        {
            if (entities.Count == 0) return;

            HashSet<InstanceManager> instances = [];

            // Console.WriteLine($"Refresh {entities.OfType<NSTEntity>().Count()} entities");
            
            foreach (NSTObject obj in entities)
            {
                if (obj is not NSTEntity entity || entity.IsPrefabTemplate) continue;

                // Console.WriteLine($"Refresh {entity.Object.ObjectName}, InstanceManager: {entity.InstanceManager}, IsInstanced: {entity.IsInstanced}, Object3D: {entity.Object3D}, IsSelected: {entity.IsSelected}");
                
                if (entity.InstanceManager != null)
                {
                    instances.Add(entity.InstanceManager);
                }
                else if (!entity.IsSelected)
                {
                    RootObject.Add(entity.CreateObject3D());
                }
            }

            foreach (InstanceManager instance in instances)
            {
                instance.ConvertToInstanced(RootObject, _explorer.DebugRenderMode);
            }
        }

        public NSTObject? Find(igObject obj) => FindRecursive(obj, AllEntities.Cast<NSTObject>().ToHashSet());
        private NSTObject? FindRecursive(igObject obj, HashSet<NSTObject> objects)
        {
            foreach (NSTObject entity in objects)
            {
                if (entity.GetObject() == obj) return entity;

                foreach (NSTObject child in entity.Children)
                {
                    NSTObject? result = FindRecursive(obj, child.Children);
                    if (result != null) return result;
                }
            }
            
            return null;
        }
    }
}