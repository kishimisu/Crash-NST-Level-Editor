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

        public THREE.Matrix4 ObjectToWorld()
        {
            THREE.Matrix4 modelMatrix = Object.GetTransformMatrix();

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
                CollisionShapeIndex = IsPrefabChild ? -1 : CollisionShapeIndex,
                CollisionPrefabHash = CollisionPrefabHash,
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

        public void RefreshModel(LevelExplorer explorer, NSTModel model)
        {
            if (explorer.Archive.FindFile(model.FilePath, FileSearchType.Path) == null)
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

            explorer.InstanceManager.RefreshModel(this, model);
        }

        public override void Render(LevelExplorer explorer)
        {
            base.Render(explorer);

            // Render transform header

            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Transform");
            ImGui.PopStyleColor();

            ImGui.Spacing();

            igEntityTransform transform = Object._transform ?? new igEntityTransform() { MemoryPool = Object.MemoryPool };
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
            if (RenderVector3("Rotation", ref rotationDegrees, 0.01f))
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

            if (RenderVector3("Scale   ", ref transform._nonUniformPersistentParentSpaceScale, 0.01f))
            {
                if (Object._transform == null)
                {
                    Object._transform = transform;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                }
                explorer.ArchiveRenderer.SetEntityUpdated(this);

                Object3D?.Scale.Set(transform._nonUniformPersistentParentSpaceScale._x, transform._nonUniformPersistentParentSpaceScale._y, transform._nonUniformPersistentParentSpaceScale._z);
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

                string displayName = Model?.Name ?? Path.GetFileNameWithoutExtension(entityData._modelName ?? entityData._skinName!);

                ImGuiUtils.RenderComboWithSearch("##model", displayName, LevelExplorer.CachedModelNames, true, (_, name) =>
                {
                    MakeUnique(explorer);

                    NSTModel model = LevelExplorer.CachedModels[name];
                    
                    if (entityData._modelName != null)
                    {
                        entityData._modelName = model.OriginalPath;
                    }
                    else
                    {
                        entityData._skinName = model.OriginalPath;
                    }

                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object);

                    if (IsSpawned)
                    {
                        RefreshModel(explorer, model);
                    }
                    else
                    {
                        foreach (NSTEntity p in Parents.OfType<NSTEntity>())
                        {
                            if (p.Object.TryGetComponent(out common_Spawner_TemplateData? s) && s._EntityToSpawn.Reference?.objectName == Object.ObjectName)
                            {
                                p.RefreshModel(explorer, model);
                            }
                        }
                    }
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