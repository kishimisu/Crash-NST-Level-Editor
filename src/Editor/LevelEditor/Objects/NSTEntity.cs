using Alchemy;
using ImGuiNET;

namespace NST
{
    public class NSTEntity : NSTObject<igEntity>
    {
        public NSTModel? Model { get; set; } = null;

        public int CollisionShapeIndex { get; set; } = -1;
        public uint CollisionPrefabHash { get; set; } = 0;
        public THREE.Object3D? CollisionObject { get; set; } = null;
        public THREE.Vector3 Position => Object._parentSpacePosition.ToVector3();

        public InstanceManager? InstanceManager;
        public InstanceManager? PreviousInstanceManager;
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

        public bool IsLight { get; set; } = false;
        public bool IsVFX { get; set; } = false;
        public bool IsSFX { get; set; } = false;

        // Parent CScriptTriggerEntity focus
        public bool ClickedAgain { get; set; } = false;
        public bool OutlineTrigger { get; set; } = false;

        public NSTSpline? Spline { get; private set; }
        private Dictionary<CWaypoint, NSTWaypoint> _waypoints = [];

        public THREE.Color Color { get; }
        
        public static readonly THREE.Color ColorLighting = new THREE.Color(1, 0.9f, 0.3f);
        public static readonly THREE.Color ColorVFX = new THREE.Color(0, 1, 1);
        public static readonly THREE.Color ColorSFX = new THREE.Color(0, 1, 0.35f);

        public override THREE.Matrix4 ObjectToWorld() => ObjectToWorld(true);
        public override THREE.Vector3 GetPosition()
        {
            if (ParentPrefabInstance == null) return Position;
            THREE.Vector3 worldPos = new THREE.Vector3();
            ObjectToWorld(true).Decompose(worldPos, new THREE.Quaternion(), new THREE.Vector3());
            return worldPos;
        }

        public NSTEntity(igEntity obj, IgArchiveFile archiveFile)
        {
            Object = obj;
            ArchiveFile = archiveFile;

            InitType();
            InitSpline();

            if (IsLight) Color = ColorLighting;
            else if (IsVFX) Color = ColorVFX;
            else if (IsSFX) Color = ColorSFX;
            else Color = MathUtils.FromImGuiColor(Object.GetType().GetUniqueColor());
        }

        private void InitType()
        {
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

            if (Model == null)
            {
                int lightCount = 0;
                int vfxCount = 0;
                int sfxCount = 0;
                int otherCount = 0;

                if (Object.ObjectName == "Main_OutdoorLightEntity") lightCount++;

                foreach (var c in Object.GetComponents())
                {
                    if      (c is CTintSphereComponentData)    lightCount++;
                    else if (c is CPointLightComponentData)    lightCount++;
                    else if (c is CBoxLightComponentData)      lightCount++;
                    else if (c is CVisualDataBoxComponentData) lightCount++;
                    else if (c is CStaticVfxComponentData)     vfxCount++;
                    else if (c is CLoopingVfxComponentData)    vfxCount++;
                    else if (c is CDSPOverrideComponentData)   sfxCount++;
                    else if (c is CAmbientAudioComponentData)  sfxCount++;
                    else if (c is common_OnStartMusicData)     sfxCount++;
                    else otherCount++;
                }

                if (otherCount == 0)
                {
                    if (lightCount > 0) IsLight = true;
                    else if (vfxCount > 0) IsVFX = true;
                    else if (sfxCount > 0) IsSFX = true;
                }
            }
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            THREE.Object3D group = Model?.CreateObject() ?? new THREE.Object3D();

            THREE.Matrix4 objectToWorld = ObjectToWorld(true);

            if (Model == null && !IsPrefabInstance && Object is not CScriptTriggerEntity && Object is not CDynamicClipEntity)
            {
                var geo = new THREE.BoxGeometry(20, 20, 20);

                if (IsLight)
                {
                    THREE.Vector3 scale = objectToWorld.GetScale();
                    geo.Scale(1.0f / scale.X, 1.0f / scale.Y, 1.0f / scale.Z);
                }

                var mat = new THREE.MeshPhongMaterial() { Color = Color };
                group.Add(new THREE.Mesh(geo, mat));
            }

            group.ApplyMatrix4(objectToWorld);

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

            if (Model != null) group.Traverse(e => { if (e.Material != null) e.Material.Visible = true; });

            SetLayer(group, selected);

            foreach (THREE.Object3D child in CreateChildrenObject3D(selected))
            {
                group.Attach(child);
            }

            if (!selected && !IsSpawned)
            {
                SetLayer(group, selected);
            }

            Object3D?.Parent?.Remove(Object3D);

            Object3D = group;

            _waypoints.Clear();

            return group;
        }

        private void SetLayer(THREE.Object3D group, bool selected)
        {
            LevelExplorer.CameraLayer? layer = null;

            if (Object is not CScriptTriggerEntity)
            {
                foreach (NSTEntity parent in Parents.OfType<NSTEntity>().Where(p => p.Object is CScriptTriggerEntity))
                {
                    parent.Object3D?.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.TriggersOn));
                }
            }

            if (!selected && IsTemplate)
            {
                layer = LevelExplorer.CameraLayer.Templates;
            }
            else if (!selected && IsHidden)
            {
                layer = LevelExplorer.CameraLayer.Hidden;
            }
            else if (!selected)
            {
                if (Object is CDynamicClipEntity) layer = LevelExplorer.CameraLayer.ClipEntities;
                else if (Model == null) layer = LevelExplorer.CameraLayer.AllEntities;
            }
            else if (IsPrefabChild && ParentPrefabInstance?.IsSelected == true && Model?.Name.Contains("cloud", StringComparison.InvariantCultureIgnoreCase) == true)
            {
                layer = LevelExplorer.CameraLayer.Clouds;
            }

            if (layer != null)
            {
                group.Traverse(e => e.Layers.Set((int)layer));
            }
        }

        public List<THREE.Object3D> CreateChildrenObject3D(bool selected = false)
        {
            List<THREE.Object3D> group = [];

            AddComponentsGizmos(group, selected);

            foreach (NSTObject child in Children)
            {
                if (child.IsSelected || child is NSTEntity || child is NSTCamera) continue;
                group.Add(child.CreateObject3D(selected));
            }

            return group;
        }

        private THREE.Object3D? AddComponentsGizmos(List<THREE.Object3D> group, bool focused = false)
        {
            if (Object is CEntity entity && (Object is CScriptTriggerEntity || Object is CDynamicClipEntity) && (!IsSFX || focused))
            {
                var layer = Object is CDynamicClipEntity ? LevelExplorer.CameraLayer.ClipEntities : LevelExplorer.CameraLayer.ScriptTrigger;

                THREE.Color color = IsSFX ? ColorSFX : new THREE.Color(Object is CScriptTriggerEntity ? 0xFFA500 : 0xFF0000);
                THREE.Mesh mesh = CreateBoxHelper(entity._min.ToVector3(), entity._max.ToVector3(), color, focused, layer);

                if (Object is CScriptTriggerEntity && !OutlineTrigger)
                {
                    mesh.UserData["excludeFromOutline"] = true;
                }

                mesh.ApplyMatrix4(ObjectToWorld());

                group.Add(mesh);

                return null;
            }

            foreach (var component in Object.GetComponents())
            {
                if (component is CTriggerVolumeBoxComponentData trigger)
                {
                    THREE.Vector3 position = trigger._offset.ToVector3();
                    THREE.Euler rotation = trigger._rotation.Mul(THREE.MathUtils.DEG2RAD).ToEuler();
                    THREE.Vector3 scale = trigger._dimensions.ToVector3();

                    SetupBoxGizmo(group, trigger, position, rotation, scale, focused, LevelExplorer.CameraLayer.TriggerVolume);
                }
                else if (component is CVisualDataBoxComponentData box)
                {
                    THREE.Vector3 parentScale = new THREE.Vector3(); 
                    ObjectToWorld().Decompose(new(), new(), parentScale);

                    THREE.Vector3 scale = parentScale * box._dimensions.ToVector3();

                    SetupBoxGizmo(group, box, new(), new(), scale, focused, LevelExplorer.CameraLayer.VisualBox);
                }
                else if (component is CBoxLightComponentData boxLight)
                {
                    THREE.Vector3 parentScale = new THREE.Vector3(); 
                    ObjectToWorld().Decompose(new(), new(), parentScale);

                    THREE.Color color = new THREE.Color(boxLight._color._x, boxLight._color._y, boxLight._color._z);
                    THREE.Vector3 scale = parentScale * boxLight._dimensions.ToVector3();

                    SetupBoxGizmo(group, boxLight, new(), new(), scale, true, LevelExplorer.CameraLayer.BoxLight, color);
                }
                else if (component is CTintSphereComponentData tintSphere)
                {
                    THREE.Color color = new THREE.Color(tintSphere._color._x, tintSphere._color._y, tintSphere._color._z);

                    SetupSphereGizmo(group, tintSphere, tintSphere._radius, LevelExplorer.CameraLayer.TintSphere, color);
                }
                else if (component is CPointLightComponentData pointLight)
                {
                    THREE.Color color = new THREE.Color(pointLight._color._x, pointLight._color._y, pointLight._color._z);

                    SetupSphereGizmo(group, pointLight, pointLight._radius, LevelExplorer.CameraLayer.PointLight, color);
                }
                else if (component is CAmbientAudioComponentData audio)
                {
                    if (Components?.DefaultSizes.TryGetValue(audio, out var scale) != true || scale == null)
                    {
                        scale = THREE.Vector3.One();
                    }
                    
                    SetupBoxGizmo(group, audio, new THREE.Vector3(), new THREE.Euler(), scale, focused, LevelExplorer.CameraLayer.AudioBox, ColorSFX);
                }
                else if (component is common_OnStartMusicData music)
                {
                    SetupBoxGizmo(group, music, new THREE.Vector3(), new THREE.Euler(), THREE.Vector3.One() * 1800, focused, LevelExplorer.CameraLayer.AudioBox, ColorSFX);
                }
            }

            return null;
        }

        private void SetupBoxGizmo(List<THREE.Object3D> group, igComponentData component, THREE.Vector3 position, THREE.Euler rotation, THREE.Vector3 scale, bool focused, LevelExplorer.CameraLayer layer, THREE.Color? color = null)
        {
            var localMatrix = new THREE.Matrix4().Compose(position, new THREE.Quaternion().SetFromEuler(rotation), scale);
            var min = THREE.Vector3.One() * -0.5f;
            var max = THREE.Vector3.One() * 0.5f;

            color ??= MathUtils.FromImGuiColor(component.GetType().GetUniqueColor());

            THREE.Object3D box3D = CreateBoxHelper(min, max, color.Value, focused);

            box3D.ApplyMatrix4(ObjectToWorld().ResetScale() * localMatrix);

            box3D.Traverse(e => 
            {
                e.Layers.Set((int)layer);
                e.UserData["component"] = component;
            });

            Components ??= new ComponentManager(this);
            Components.AddGizmo(component, box3D);

            if (IsSpawned) group.Add(box3D);
        }

        private void SetupSphereGizmo(List<THREE.Object3D> group, igComponentData component, float radius, LevelExplorer.CameraLayer layer, THREE.Color color)
        {
            var geo = new THREE.SphereGeometry(1, 16, 16);
            var geoWire = new THREE.SphereGeometry(1, 8, 8);
            var mat = new THREE.MeshBasicMaterial() { Transparent = true, Opacity = 0.35f, Color = color };
            var matWire = new THREE.MeshBasicMaterial() { Wireframe = true, Color = color };

            var mesh = new THREE.Mesh(geo, mat)
            {
                new THREE.Mesh(geoWire, matWire)
            };

            mesh.ApplyMatrix4(ObjectToWorld() * new THREE.Matrix4().MakeScale(radius, radius, radius));

            mesh.Traverse(e =>
            {
                e.Layers.Set((int)layer);
                e.UserData["entity"] = this;
                e.UserData["component"] = component;
            });

            Components ??= new ComponentManager(this);
            Components.AddGizmo(component, mesh);

            if (IsSpawned) group.Add(mesh);
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
            var handles = components.SelectMany(c => c.GetHandles(ArchiveFile.GameVersion)).ToList();

            if (Object is CPlayerStartEntity playerStart && playerStart._camera?.Reference is NamedReference camReference)
            {
                NSTObject? cam = objects.Find(o => o.GetObject().ObjectName == camReference.objectName && o.FileNamespace == camReference.namespaceName);
                if (cam != null)
                {
                    cam.Parents.Add(this);
                    Children.Add(cam);
                }
            }

            if (Object.TryGetComponent(out CMovementControllerComponentData? movementController) && movementController._controllerList?._data.Count > 0)
            {
                handles.AddRange(movementController._controllerList._data.SelectMany(c => c.GetHandles(ArchiveFile.GameVersion)));
            }

            foreach (NamedReference reference in handles)
            {
                NSTObject? link = objects.Find(o => o.GetObject().ObjectName == reference.objectName && o.FileNamespace == reference.namespaceName);

                if (link != null)
                {
                    link.Parents.Add(this);
                    Children.Add(link);
                }
                else if (explorer.FileManager.FindObjectInOpenFiles(reference, out _) is igSmartHandleList handleList)
                {
                    foreach (var handleMetaField in handleList._data)
                    {
                        if (handleMetaField.Reference == null) continue;

                        link = objects.Find(o => o.GetObject().ObjectName == handleMetaField.Reference.objectName && o.FileNamespace == handleMetaField.Reference.namespaceName);

                        if (link != null)
                        {
                            link.Parents.Add(this);
                            Children.Add(link);
                        }
                    }
                }
            }

            if (Object is CWorldEntity) // special case for boss levels
            {
                foreach (var c in Children.OfType<NSTEntity>())
                {
                    if (!c.Object._bitfield._isArchetype) c.IsTemplate = false;
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

        public NSTEntity? GetChildTemplate()
        {
            if (Object.GetType() == typeof(igEntity)) return null;
            
            string? name = Object.GetComponent<common_Spawner_TemplateData>()?._EntityToSpawn.Reference?.objectName;
            if (name == null) return null;

            return Children.OfType<NSTEntity>().FirstOrDefault(c => c.Object.ObjectName == name);
        }

        public IEnumerable<NSTEntity> GetParentSpawners()
        {
            if (IsSpawned || Object.GetType() == typeof(igEntity)) return [];

            return Parents
                .OfType<NSTEntity>()
                .Where(p => p.Object.GetComponent<common_Spawner_TemplateData>()?._EntityToSpawn.Reference?.objectName == Object.ObjectName);
        }

        public IEnumerable<NSTEntity> GetUniqueChildTemplates()
        {
            return Children
                .OfType<NSTEntity>()
                .Where(e => e.IsTemplate && e.Parents.Count == 1 &&
                           (e.Object._parentSpacePosition._x != 0 || e.Object._parentSpacePosition._y != 0 || e.Object._parentSpacePosition._z != 0));
        }

        public Dictionary<igComponentData, List<CWaypoint>> GetComponentsWaypoints(IgzFile parentIgz)
        {
            return Object.GetComponents().ToDictionary(c => c, c =>
            {
                List<CWaypoint> waypoints = [];

                foreach (var handle in c.GetHandles(ArchiveFile.GameVersion))
                {
                    igObject? obj = parentIgz.FindObject(handle);
                    if (obj == null) continue;

                    if (obj is CWaypoint wp)
                    {
                        waypoints.Add(wp);
                    }
                    else if (obj is CWaypointHandleList wpList)
                    {
                        foreach (var wpRef in wpList._data)
                        {
                            if (wpRef.Reference == null) continue;

                            obj = parentIgz.FindObject(wpRef.Reference);

                            if (obj == null) continue;
                            if (obj is CWaypoint childWp) waypoints.Add(childWp);
                        }
                    }
                }

                return waypoints;
            })
            .Where(e => e.Value.Count > 0)
            .ToDictionary();
        }

        public THREE.Matrix4 ObjectToWorld(bool useOverrideScale = false)
        {
            THREE.Vector3? overrideScale = useOverrideScale ? GetChildTemplate()?.Object._transform?._nonUniformPersistentParentSpaceScale.ToVector3() : null;
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
            if (childTemplate.GetParentSpawners().Count() <= 1) return childTemplate;
            if (!Object.TryGetComponent(out common_Spawner_TemplateData? _)) return childTemplate;

            Components ??= new ComponentManager(this);

            if (!Components.IsSetup)
            {
                Components.SetupComponents(explorer);
            }
            
            if (Components.GetComponent<common_Spawner_TemplateData>() is not NSTComponent component) return childTemplate;

            Components.MakeUnique(component);

            Children.Remove(childTemplate);
            childTemplate.Parents.Remove(this);

            IgzFile igz = explorer.FileManager.GetIgz(childTemplate.ArchiveFile)!;
            NSTEntity uniqueTemplate = (NSTEntity)explorer.Clone([childTemplate.Object], explorer.Archive, igz, childTemplate.ArchiveFile, igz, addToSelection: null)[0]!;
            
            Children.Add(uniqueTemplate);
            uniqueTemplate.Parents.Add(this);

            Object.GetComponent<common_Spawner_TemplateData>()!._EntityToSpawn.Reference!.objectName = uniqueTemplate.Object.ObjectName!;

            explorer.InstanceManager.RegisterNew([ uniqueTemplate ]);

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
                    Console.WriteLine("Model file found: " + modelFile.Path);
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

            igEntityTransform transform = new igEntityTransform() { MemoryPool = Object.MemoryPool.WithAlignment(16) };
            THREE.Vector3 previousPosition = Object._parentSpacePosition.ToVector3();
            THREE.Euler previousRotation = new THREE.Euler(0, 0, 0);
            THREE.Vector3 previousScale = new THREE.Vector3(1, 1, 1);

            if (Object._transform != null)
            {
                transform = Object._transform;
                previousRotation = transform._parentSpaceRotation.ToEuler();
                previousScale = transform._nonUniformPersistentParentSpaceScale.ToVector3();
            }

            // Render position input

            if (RenderVector3("Position", ref Object._parentSpacePosition, out bool onRelease))
            {
                explorer.ArchiveRenderer.SetEntityUpdated(this);
                explorer.SelectionManager.TranslateSelectionFromGUI(previousPosition, Object._parentSpacePosition.ToVector3());
            }

            if (onRelease)
            {
                explorer.SelectionManager.ApplyChanges("translate");
            }

            // Render rotation input

            igVec3fMetaField rotationDegrees = transform._parentSpaceRotation.Mul(THREE.MathUtils.RAD2DEG);
            if (RenderVector3("Rotation", ref rotationDegrees, out onRelease, 0.1f))
            {
                rotationDegrees._x = (float)(Math.Truncate((decimal)rotationDegrees._x * 10) / 10) % 360f;
                rotationDegrees._y = (float)(Math.Truncate((decimal)rotationDegrees._y * 10) / 10) % 360f;
                rotationDegrees._z = (float)(Math.Truncate((decimal)rotationDegrees._z * 10) / 10) % 360f;

                if (Object._transform == null)
                {
                    Object._transform = transform;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                }
                explorer.ArchiveRenderer.SetEntityUpdated(this);

                Object._transform._parentSpaceRotation = rotationDegrees.Mul(THREE.MathUtils.DEG2RAD);

                explorer.SelectionManager.RotateSelectionFromGUI(previousRotation, Object._transform._parentSpaceRotation.ToEuler());
            }

            if (onRelease)
            {
                explorer.SelectionManager.ApplyChanges("rotate");
            }

            // Render scale input

            if (GetChildTemplate() is NSTEntity childTemplate)
            {
                var scale = childTemplate.Object._transform?._nonUniformPersistentParentSpaceScale ?? new igVec3fMetaField(1, 1, 1);

                previousScale.Copy(scale.ToVector3());

                if (RenderVector3("Scale   ", ref scale, out onRelease, 0.01f))
                {
                    childTemplate = MakeChildTemplateUnique(explorer, childTemplate);

                    if (childTemplate.Object._transform == null)
                    {
                        childTemplate.Object._transform = new igEntityTransform() { MemoryPool = childTemplate.Object.MemoryPool.WithAlignment(16) };
                        explorer.ArchiveRenderer.SetObjectUpdated(childTemplate.ArchiveFile, childTemplate.Object, true);
                    }
                    explorer.ArchiveRenderer.SetEntityUpdated(childTemplate);

                    if (scale._x == 0) scale._x = 0.0001f;
                    if (scale._y == 0) scale._y = 0.0001f;
                    if (scale._z == 0) scale._z = 0.0001f;

                    childTemplate.Object._transform._nonUniformPersistentParentSpaceScale = scale;

                    explorer.SelectionManager.ScaleSelectionFromGUI(previousScale, scale.ToVector3(), this);
                }

                if (onRelease && childTemplate.Object._transform != null)
                {
                    THREE.Vector3 currentScale = childTemplate.Object._transform._nonUniformPersistentParentSpaceScale.ToVector3();
                    THREE.Vector3 newScale = MathUtils.SafeDivide(currentScale, explorer.SelectionManager.SelectionContainer.Scale);
                    childTemplate.Object._transform._nonUniformPersistentParentSpaceScale = newScale.ToVec3MetaField();
                    explorer.SelectionManager.ApplyChanges("scale");
                }
            }
            else
            {
                bool disableScale = Object is CScriptTriggerEntity || Object is CDynamicClipEntity;
                if (disableScale) ImGui.BeginDisabled();
                if (RenderVector3("Scale   ", ref transform._nonUniformPersistentParentSpaceScale, out onRelease, 0.01f))
                {
                    if (Object._transform == null)
                    {
                        Object._transform = transform;
                        explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                    }
                    explorer.ArchiveRenderer.SetEntityUpdated(this);

                    if (transform._nonUniformPersistentParentSpaceScale._x == 0) transform._nonUniformPersistentParentSpaceScale._x = 0.0001f;
                    if (transform._nonUniformPersistentParentSpaceScale._y == 0) transform._nonUniformPersistentParentSpaceScale._y = 0.0001f;
                    if (transform._nonUniformPersistentParentSpaceScale._z == 0) transform._nonUniformPersistentParentSpaceScale._z = 0.0001f;

                    explorer.SelectionManager.ScaleSelectionFromGUI(previousScale, transform._nonUniformPersistentParentSpaceScale.ToVector3(), this);
                }
                if (disableScale) ImGui.EndDisabled();

                if (onRelease)
                {
                    THREE.Vector3 currentScale = transform._nonUniformPersistentParentSpaceScale.ToVector3();
                    THREE.Vector3 newScale = MathUtils.SafeDivide(currentScale, explorer.SelectionManager.SelectionContainer.Scale);
                    transform._nonUniformPersistentParentSpaceScale = newScale.ToVec3MetaField();
                    explorer.SelectionManager.ApplyChanges("scale");
                }
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
                ComponentRenderer.RenderObjectReference("Camera:", playerStart._camera?.Reference, typeof(CCamera), explorer, (value) =>
                {
                    playerStart._camera ??= new CCamera();
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