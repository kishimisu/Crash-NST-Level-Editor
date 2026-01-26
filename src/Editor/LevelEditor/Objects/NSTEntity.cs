using Alchemy;
using ImGuiNET;

namespace NST
{
    public class NSTEntity : NSTObject<igEntity>
    {
        public NSTModel? Model { get; set; } = null;

        public int CollisionShapeIndex { get; set; } = -1;
        public uint CollisionPrefabHash { get; set; } = 0;
        public THREE.Vector3 Position => Object._parentSpacePosition.ToVector3();

        public InstanceManager? InstanceManager;
        public ComponentManager? Components;

        // Prefab parent
        public bool IsPrefabInstance { get; private set; } = false; // Instance of a prefab (contains a group of prefab child)

        // Prefab child instance
        public bool IsPrefabChild => ParentPrefabInstance != null; // Child instance of a prefab instance
        public NSTEntity? ParentPrefabInstance { get; set; } = null; // (Prefab child) Parent prefab instance
        public NSTEntity? PrefabTemplate { get; private set; } = null; // (Prefab child) Original prefab template

        // Prefab child template
        public bool IsPrefabTemplate { get; private set; } = false; // Original template of a child instance (not instanciated in the scene)
        public List<NSTEntity> PrefabTemplateInstances { get; private set; } = []; // (Prefab template) List of instances of this template

        public bool IsTemplate { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public bool IsSpawned => !IsPrefabTemplate && !IsTemplate && !IsHidden;

        public NSTSpline? Spline { get; private set; }
        public THREE.Object3D? TriggerVolumeBox { get; private set; }
        private Dictionary<CWaypoint, NSTWaypoint> _waypoints = [];

        public NSTEntity(igEntity obj, IgArchiveFile archiveFile)
        {
            Object = obj;
            ArchiveFile = archiveFile;

            InitSpline();

            if (!Object._bitfield._canSpawn || Object._bitfield._isArchetype)
            {
                if (Object.GetType() != typeof(igEntity) || Object.GetComponent<CModelComponentData>() == null)
                {
                    IsTemplate = true;
                }
                else
                {
                    IsHidden = true;
                }
            }
            else if (Object.GetComponent<CStaticComponentData>()?._flagsBitfield._disableVisual == true)
            {
                IsHidden = true;
            }
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            THREE.Object3D group = Model?.CreateObject() ?? new THREE.Object3D();

            if (Model == null)
            {
                var geo = new THREE.BoxGeometry(20, 20, 20);
                var mat = new THREE.MeshPhongMaterial() { Color = MathUtils.FromImGuiColor(Object.GetType().GetUniqueColor()) };
                group.Add(new THREE.Mesh(geo, mat));
            }

            group.ApplyMatrix4(ObjectToWorld());

            group.Traverse(e => e.UserData["entity"] = this);

            if (IsTemplate || IsHidden)
            {
                THREE.Color color = new THREE.Color(IsTemplate ? 0xffff00 : 0xff00ff);
                group.Traverse(e =>
                {
                    if (e.Material != null)
                        e.Material = new THREE.MeshPhongMaterial() { Shininess = NSTMaterial.DefaultShininess, Color = color };
                });
            }

            foreach (THREE.Object3D child in CreateChildrenObject3D(selected))
            {
                group.Attach(child);
            }

            if (!selected)
            {
                LevelExplorer.CameraLayer layer = LevelExplorer.CameraLayer.Default;

                if (IsTemplate) layer = LevelExplorer.CameraLayer.Templates;
                else if (IsHidden) layer = LevelExplorer.CameraLayer.Hidden;
                else if (Model == null) layer = LevelExplorer.CameraLayer.AllEntities;

                group.Traverse(e => e.Layers.Set((int)layer));
            }
            else if (IsPrefabChild && ParentPrefabInstance?.IsSelected == true && Model?.Name.Contains("cloud", StringComparison.InvariantCultureIgnoreCase) == true)
            {
                group.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.Clouds));
            }

            if (Object3D != null)
            {
                Object3D.Parent?.Remove(Object3D);
            }

            _waypoints.Clear();

            Object3D = group;

            return group;
        }

        public List<THREE.Object3D> CreateChildrenObject3D(bool selected = false)
        {
            List<THREE.Object3D> group = [];

            THREE.Mesh? special = CreateSpecialObject3D(selected);
            if (special != null) group.Add(special);

            foreach (NSTObject child in Children)
            {
                if (child.IsSelected) continue;
                if (child is NSTEntity) continue;
                if (child.GetObject() is CScriptTriggerEntity) continue;

                group.Add(child.CreateObject3D(selected));
            }

            return group;
        }

        private THREE.Mesh? CreateSpecialObject3D(bool focused = false)
        {
            if (Object is CEntity entity && (Object is CScriptTriggerEntity || Object is CDynamicClipEntity))
            {
                THREE.Color color = new THREE.Color(Object is CScriptTriggerEntity ? 0xFFA500 : 0xFF0000);
                var layer = Object is CDynamicClipEntity ? LevelExplorer.CameraLayer.ClipEntities : LevelExplorer.CameraLayer.Triggers;
                THREE.Mesh mesh = CreateBoxHelper(entity._min.ToVector3(), entity._max.ToVector3(), color, focused, layer);

                mesh.ApplyMatrix4(ObjectToWorld());

                return mesh;
            }

            if (Object.TryGetComponent(out CTriggerVolumeBoxComponentData? box))
            {
                THREE.Vector3 position = box._offset.ToVector3();
                THREE.Euler rotation = box._rotation.Mul(THREE.MathUtils.DEG2RAD).ToEuler();
                THREE.Vector3 scale = box._dimensions.ToVector3();
                THREE.Matrix4 localMatrix = new THREE.Matrix4().Compose(position, new THREE.Quaternion().SetFromEuler(rotation), scale);

                THREE.Color color =  MathUtils.FromImGuiColor(box.GetType().GetUniqueColor());
                THREE.Vector3 min = THREE.Vector3.One() * -0.5f;
                THREE.Vector3 max = THREE.Vector3.One() * 0.5f;

                TriggerVolumeBox = CreateBoxHelper(min, max, color, focused);
                TriggerVolumeBox.ApplyMatrix4(localMatrix);
            }

            return null;
        }

        public NSTWaypoint AddWaypoint(CWaypoint waypoint, LevelExplorer explorer)
        {
            if (_waypoints.TryGetValue(waypoint, out NSTWaypoint? wpOut))
            {
                return wpOut;
            }
            
            _waypoints[waypoint] = new NSTWaypoint(this, waypoint);

            Object3D?.Add(_waypoints[waypoint].CreateObject3D());

            explorer.RenderNextFrame = true;

            return _waypoints[waypoint];
        }

        public NSTSpline? InitSpline()
        {
            CSplineComponentData? splineComponent = Object.GetComponent<CSplineComponentData>();

            if (splineComponent?._spline?._data?._data.Count > 0)
            {
                Spline = new NSTSpline(this, splineComponent._spline);
                Children.Add(Spline);
                return Spline;
            }

            return null;
        }

        public void InitChildren(LevelExplorer explorer, List<NSTObject> objects)
        {
            var components = Object.GetComponents();
            var handles = components.SelectMany(c => c.GetHandles()).ToList();

            if (Object.TryGetComponent(out CMovementControllerComponentData? movementController) && movementController._controllerList?._data.Count > 0)
            {
                handles.AddRange(movementController._controllerList._data.SelectMany(c => c.GetHandles()));
            }

            foreach (NamedReference reference in handles)
            {
                NSTObject? link = objects.Find(o => o.GetObject().ObjectName == reference.objectName && o.FileNamespace == reference.namespaceName);

                if (link != null)
                {
                    link.Parents.Add(this);
                    Children.Add(link);
                }
                else if (explorer.FileManager.FindObjectInOpenFiles(reference, out _) is CEntityHandleList handleList)
                {
                    foreach (var handleMetaField in handleList._data)
                    {
                        if (handleMetaField.Reference == null) continue;

                        link = objects.Find(o => o.GetObject().ObjectName ==  handleMetaField.Reference.objectName && o.FileNamespace == handleMetaField.Reference.namespaceName);

                        if (link != null)
                        {
                            link.Parents.Add(this);
                            Children.Add(link);
                        }
                    }
                }
            }
        }

        public List<NSTEntity> InitPrefabChildren(InstancedMeshManager instanceManager)
        {
            igPrefabComponentData? prefabComponent = Object.GetComponent<igPrefabComponentData>();

            if (prefabComponent?._prefabEntities == null) return [];

            List<igEntity> prefabEntities = prefabComponent._prefabEntities._data.ToList();
            List<NSTEntity> newEntities = [];

            foreach (igEntity entity in prefabEntities)
            {
                if (entity == null) continue;

                if (!instanceManager.PrefabTemplates.TryGetValue(entity, out NSTEntity? prefabTemplate))
                {
                    prefabTemplate = instanceManager.AllEntities.Find(e => e.Object == entity);

                    if (prefabTemplate == null)
                    {
                        Console.WriteLine("Warning: Could not find prefab template for " + entity);
                        continue;
                    }

                    instanceManager.PrefabTemplates[entity] = prefabTemplate;
                    instanceManager.Unregister(prefabTemplate);
                }

                NSTEntity prefabChild = prefabTemplate.CloneAsPrefabChild(this);

                newEntities.Add(prefabChild);
                instanceManager.Register(prefabChild);
            }

            return newEntities;
        }

        public void InitScriptTriggerEntity(LevelExplorer explorer, List<NSTEntity> entities)
        {
            if (Object is not CScriptTriggerEntity trigger) return;

            Spawner_Trigger_LogicData? spawner = trigger.GetComponent<Spawner_Trigger_LogicData>();
            NamedReference? reference = spawner?._SpawnerActivationList.Reference;

            if (reference == null) return;

            CEntityHandleList? handleList = (CEntityHandleList?)explorer.FileManager.FindObjectInOpenFiles(reference, out _);

            if (handleList == null) return;

            foreach (var handleMetaField in handleList._data)
            {
                NamedReference? handle = handleMetaField?.Reference;

                NSTEntity? entity = entities.FirstOrDefault(e =>
                    e.Object.ObjectName == handle?.objectName &&
                    e.FileNamespace == handle?.namespaceName
                );

                if (entity == null)
                {
                    Console.WriteLine($"WARNING: Could not find spawned entity {handle?.objectName} for trigger {Object.ObjectName}");
                    continue;
                }

                entity.Children.Add(this);
            }
        }

        public NSTEntity? GetChildTemplate()
        {
            if (Object.GetType() == typeof(igEntity)) return null;
            
            string? name = Object.GetComponent<common_Spawner_TemplateData>()?._EntityToSpawn.Reference?.objectName;
            if (name == null) return null;

            return Children.OfType<NSTEntity>().FirstOrDefault(c => c.Object.ObjectName == name);
        }

        private IEnumerable<NSTEntity> GetParentSpawners()
        {
            if (IsSpawned || Object.GetType() == typeof(igEntity)) return [];

            return Parents
                .OfType<NSTEntity>()
                .Where(p => p.Object.GetComponent<common_Spawner_TemplateData>()?._EntityToSpawn.Reference?.objectName == Object.ObjectName);
        }

        public THREE.Matrix4 ObjectToWorld()
        {
            THREE.Vector3? overrideScale = GetChildTemplate()?.Object._transform?._nonUniformPersistentParentSpaceScale.ToVector3();
            THREE.Matrix4 modelMatrix = Object.GetTransformMatrix(overrideScale);

            if (ParentPrefabInstance == null)
            {
                return modelMatrix;
            }
            else
            {
                return ParentPrefabInstance.ObjectToWorld() * modelMatrix;
            }
        }

        public NSTEntity Clone(igEntity newObject, IgArchiveFile? newArchiveFile = null)
        {
            return new NSTEntity(newObject, newArchiveFile ?? ArchiveFile)
            {
                Model = Model,
                CollisionShapeIndex = CollisionShapeIndex,
                IsTemplate = IsTemplate,
                IsHidden = IsHidden
            };
        }

        public NSTEntity CloneAsPrefabChild(NSTEntity parentPrefabInstance)
        {
            NSTEntity childInstance = Clone(Object);

            childInstance.Parents = Parents;
            childInstance.PrefabTemplate = this;
            childInstance.ParentPrefabInstance = parentPrefabInstance;

            if (Object._bitfield._canSpawn)
            {
                childInstance.IsTemplate = false;
                childInstance.IsHidden = false;
            }

            Parents.Add(parentPrefabInstance);

            IsPrefabTemplate = true;
            PrefabTemplateInstances.Add(childInstance);

            parentPrefabInstance.IsPrefabInstance = true;
            parentPrefabInstance.Children.Add(childInstance);

            return childInstance;
        }

        /// <summary>
        /// Clone the object's entity data to make it unique if it is referenced by multiple entities
        /// </summary>
        public void MakeUnique(LevelExplorer explorer)
        {
            if (Object._entityData == null || !explorer.InstanceManager.AllEntities.Any(e => e.Object._entityData == Object._entityData && e != this)) return;

            Dictionary<igObject, igObject> clones = [];

            // Clone entity data
            IgzFile igz = explorer.FileManager.GetIgz(ArchiveFile)!;
            igEntityData clone = igz.AddClone(Object._entityData, clones: clones, mode: CloneMode.ShallowAndChildren);

            Object._entityData = clone;

            // Mark objects as updated
            foreach (igObject c in clones.Values)
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, c, true);
            }
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
            explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, clone, true);
        }

        /// <summary>
        /// Clone the template referenced by this object's common_Spawner_TemplateData component if it exists
        /// </summary>
        public NSTEntity MakeChildTemplateUnique(LevelExplorer explorer, NSTEntity childTemplate)
        {
            if (Components == null || childTemplate.GetParentSpawners().Count() <= 1) return childTemplate;
            if (Components.GetComponent<common_Spawner_TemplateData>() is not NSTComponent component) return childTemplate;

            Components.MakeUnique(component);

            Children.Remove(childTemplate);
            childTemplate.Parents.Remove(this);

            IgzFile igz = explorer.FileManager.GetIgz(childTemplate.ArchiveFile)!;
            NSTEntity uniqueTemplate = (NSTEntity)explorer.Clone([childTemplate.Object], explorer.Archive, igz, childTemplate.ArchiveFile, igz, addToSelection: null)[0]!;
            
            Children.Add(uniqueTemplate);
            uniqueTemplate.Parents.Add(this);

            Object.GetComponent<common_Spawner_TemplateData>()!._EntityToSpawn.Reference!.objectName = uniqueTemplate.Object.ObjectName!;

            return uniqueTemplate;
        }

        public void RefreshModel(LevelExplorer explorer, NSTModel? model, bool findMissingModel = true)
        {
            if (model != null && explorer.Archive.FindFile(model.FilePath, FileSearchType.Path) == null)
            {
                Console.WriteLine("Model not found in current explorer: " + model.Name);
                
                IgArchiveFile? modelFile = App.FindFile(model.FilePath, out IgArchive? parentArchive, FileSearchType.Path);

                if (modelFile != null && parentArchive != null)
                {
                    Console.WriteLine("Model file found: " + modelFile.GetPath());
                    explorer.ArchiveRenderer.AddFileWithDependencies(parentArchive, modelFile);
                }
                else
                {
                    Console.WriteLine("Error: Model not found in any explorer !");
                    return;
                }
            }

            explorer.InstanceManager.RefreshModel(this, model, findMissingModel);
        }

        public override void Render(LevelExplorer explorer)
        {
            base.Render(explorer);

            // Render transform header

            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Transform");
            ImGui.PopStyleColor();

            ImGui.Spacing();

            igEntityTransform transform = Object._transform ?? new igEntityTransform() { MemoryPool = Object.MemoryPool.WithAlignment(16) };
            THREE.Vector3 previousPosition = Object._parentSpacePosition.ToVector3();

            // Render position input

            if (RenderVector3("Position", ref Object._parentSpacePosition))
            {
                explorer.ArchiveRenderer.SetEntityUpdated(this);

                explorer.SelectionManager._selectionContainer.Position += Object._parentSpacePosition.ToVector3() - previousPosition;
                explorer.RenderNextFrame = true;
            }

            // Render rotation input

            igVec3fMetaField rotationDegrees = transform._parentSpaceRotation.Mul(THREE.MathUtils.RAD2DEG);
            if (RenderVector3("Rotation", ref rotationDegrees, 0.1f))
            {
                if (Object._transform == null)
                {
                    Object._transform = transform;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                }
                explorer.ArchiveRenderer.SetEntityUpdated(this);

                Object._transform._parentSpaceRotation = rotationDegrees.Mul(THREE.MathUtils.DEG2RAD);

                Object3D?.Quaternion.SetFromEuler(Object._transform._parentSpaceRotation.ToEuler());
                explorer.RenderNextFrame = true;
            }

            // Render scale input

            if (GetChildTemplate() is NSTEntity childTemplate)
            {
                var scale = childTemplate.Object._transform?._nonUniformPersistentParentSpaceScale ?? new igVec3fMetaField(1, 1, 1);

                if (RenderVector3("Scale   ", ref scale, 0.01f))
                {
                    childTemplate = MakeChildTemplateUnique(explorer, childTemplate);

                    if (childTemplate.Object._transform == null)
                    {
                        childTemplate.Object._transform = new igEntityTransform() { MemoryPool = childTemplate.Object.MemoryPool.WithAlignment(16) };
                        explorer.ArchiveRenderer.SetObjectUpdated(childTemplate.ArchiveFile, childTemplate.Object, true);
                    }
                    explorer.ArchiveRenderer.SetEntityUpdated(childTemplate);

                    childTemplate.Object._transform._nonUniformPersistentParentSpaceScale = scale;

                    Object3D?.Scale.Copy(childTemplate.Object._transform._nonUniformPersistentParentSpaceScale.ToVector3());
                    childTemplate.Object3D?.Scale.Copy(childTemplate.Object._transform._nonUniformPersistentParentSpaceScale.ToVector3());
                    explorer.RenderNextFrame = true;
                }
            }
            else if (RenderVector3("Scale   ", ref transform._nonUniformPersistentParentSpaceScale, 0.01f))
            {
                explorer.InstanceManager.RefreshInstances(GetParentSpawners().Cast<NSTObject>().ToList());

                if (Object._transform == null)
                {
                    Object._transform = transform;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                }
                explorer.ArchiveRenderer.SetEntityUpdated(this);

                Object3D?.Scale.Copy(transform._nonUniformPersistentParentSpaceScale.ToVector3());
                explorer.RenderNextFrame = true;
            }

            // Render bounds min/max

            if (Object is CScriptTriggerEntity cs)
            {
                RenderBounds(ref cs._min, ref cs._max, explorer);
            }
            else if (Object is CDynamicClipEntity cd)
            {
                RenderBounds(ref cd._min, ref cd._max, explorer);

                ImGui.SeparatorText("Clip Type");
                ComponentRenderer.RenderCheckbox("Players", ref cd._clipTypeStorage._clipPlayers, this, explorer, 120);
                ComponentRenderer.RenderCheckbox("Team Hero", ref cd._clipTypeStorage._clipTeamHero, this, explorer, 120);
                ComponentRenderer.RenderCheckbox("NPC Enemies", ref cd._clipTypeStorage._clipNPCEnemies, this, explorer, 120);
                ComponentRenderer.RenderCheckbox("NPC Alt Enemies", ref cd._clipTypeStorage._clipNPCAltEnemies, this, explorer, 120);
                ComponentRenderer.RenderCheckbox("World", ref cd._clipTypeStorage._clipWorld, this, explorer, 120);
                ImGui.Separator();
            }

            // ImGui.Text("Can Spawn");
            // ImGui.SameLine();
            // ImGui.Checkbox("##_canSpawn", ref Object._bitfield._canSpawn);

            RenderEntityData(explorer);
        }

        public override void RenderEntityData(LevelExplorer explorer)
        {
            if (Object._entityData == null) return;

            // Render model

            if (Object._entityData is CGameEntityData entityData && (entityData._modelName != null || entityData._skinName != null))
            {
                ImGui.Text("Model:");
                ImGui.SameLine();
                ImGui.SetNextItemWidth(-1);

                string displayName = Model?.Name ?? "(null)";

                ImGuiUtils.RenderComboWithSearch("##entityDataModel" + Object.ObjectName, displayName, LevelExplorer.CachedModelNames, true, firstOption: "(null)", callback: (i, name) =>
                {
                    MakeUnique(explorer);

                    NSTModel? model = null;
                    string modelPath = "";

                    if (i >= 0)
                    {
                        model = LevelExplorer.CachedModels[name.ToLowerInvariant()];
                        modelPath = model.OriginalPath;
                    }

                    if (entityData._modelName != null)
                    {
                        entityData._modelName = modelPath;
                    }
                    else
                    {
                        entityData._skinName = modelPath;
                    }

                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object);

                    RefreshModel(explorer, model, i >= 0);

                    GetParentSpawners().ToList().ForEach(p => p.RefreshModel(explorer, model, i >= 0));
                });
            }

            ImGui.PushID("EntityData" + Object.ObjectName);

            ImGui.BeginChild("EntityData", new System.Numerics.Vector2(0, 0), ImGuiChildFlags.AutoResizeY);

            var renderEntityDataSeparator = () =>
            {
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
                ImGui.SeparatorText("Properties");
                ImGui.PopStyleColor();
            };

            // Render tags

            // if (Object._entityData is CEntityData entityData && entityData._tags != null)
            // {
            //     ImGui.SeparatorText("Tags");

            //     foreach (var tag in entityData._tags.Dict)
            //     {
            //         string name = tag.Key.Reference?.ToString() ?? "<Error>";
            //         bool enabled = tag.Value;
            //         ImGui.Checkbox(name, ref enabled);
            //     }
            //     ImGui.Spacing();
            // }

            if (Object is CPlayerStartEntity playerStart)
            {
                renderEntityDataSeparator();
                ComponentRenderer.RenderObjectReference("Camera:", playerStart._camera?.Reference, typeof(CCameraBase), explorer, (value) =>
                {
                    if (playerStart._camera == null) playerStart._camera = new CCameraBase();
                    playerStart._camera.Reference = value;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, playerStart, true);
                });
            }
            else if (Object._entityData is CWorldEntityData worldEntityData)
            {
                renderEntityDataSeparator();
                ImGuiUtils.Prefix("Death plane height:");
                if (ImGui.InputFloat("##deathPlaneHeight", ref worldEntityData._killz))
                {
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, worldEntityData);
                }
            }

            if (Components == null)
            {
                Components = new ComponentManager(this);
            }

            // Render component list
            
            Components.RenderComponents(explorer);

            ImGui.EndChild();

            // Render selected component

            if (ImGui.BeginChild("SelectedComponent" + Components.GetID(), System.Numerics.Vector2.Zero, ImGuiChildFlags.AutoResizeY))
            {
                Components.RenderSelectedComponent(explorer);
            }
            ImGui.EndChild();

            ImGui.PopID();
        }
    }
}