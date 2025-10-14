using Alchemy;
using Havok;

namespace NST
{
    public abstract class NSTObject
    {
        public IgArchiveFile ArchiveFile { get; protected set; }
        public string FileNamespace => ArchiveFile.GetName(false);
        public HashSet<NSTObject> Children { get; protected set; } = [];
        public THREE.Object3D? Object3D { get; set; }
        public bool IsSelected { get; set; } = false;

        public abstract igObject GetObject();
        public abstract THREE.Object3D CreateObject3D(bool selected = false);
        public NamedReference ToReference() => GetObject().ToNamedReference(FileNamespace);
    }

    public abstract class NSTObject<T> : NSTObject where T : igObject
    {
        public T Object { get; protected set; }
        public override igObject GetObject() => Object;
    }

    public class NSTEntity : NSTObject<igEntity>
    {
        public NSTModel? Model { get; set; } = null;

        public THREE.Layers layers = new THREE.Layers();

        public int CollisionShapeIndex { get; set; } = -1;
        public THREE.Vector3 Position => Object._parentSpacePosition.ToVector3();

        public InstanceManager? InstanceManager;

        // Prefab parent
        public bool IsPrefabInstance { get; private set; } = false; // Instance of a prefab (contains a group of prefab child)

        // Prefab child instance
        public bool IsPrefabChild => ParentPrefabInstance != null; // Child instance of a prefab instance
        public NSTEntity? ParentPrefabInstance { get; private set; } = null; // (Prefab child) Parent prefab instance
        public NSTEntity? PrefabTemplate { get; private set; } = null; // (Prefab child) Original prefab template

        // Prefab child template
        public bool IsPrefabTemplate { get; private set; } = false; // Original template of a child instance (not instanciated in the scene)
        public List<NSTEntity> PrefabTemplateInstances { get; private set; } = []; // (Prefab template) List of instances of this template

        public bool IsTemplate { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public bool IsSpawned => !IsPrefabTemplate && !IsTemplate && !IsHidden;

        public NSTEntity(igEntity obj, IgArchiveFile archiveFile)
        {
            Object = obj;
            ArchiveFile = archiveFile;

            InitSpline();
            
            if (obj._transform?._parentSpaceTransform is igMatrix44fMetaField igParentTransform)
            {
                if (!igParentTransform.ToMatrix4().Equals(THREE.Matrix4.Identity()))
                {
                    Console.WriteLine($"Warning: Entity {obj.ObjectName} has a non-identity parent space transform!");
                }
            }
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            THREE.Object3D group = Model?.CreateObject() ?? new THREE.Object3D();

            if (IsTemplate) layers.Set((int)LevelExplorer.CameraLayer.Templates);
            else if (IsHidden) layers.Set((int)LevelExplorer.CameraLayer.Hidden);
            else if (Model == null) layers.Set((int)LevelExplorer.CameraLayer.AllEntities);

            if (Model == null)
            {
                var geo = new THREE.BoxGeometry(20, 20, 20);
                var mat = new THREE.MeshPhongMaterial() { Color = THREE.Color.Hex((int)Object.GetType().GetUniqueColor()) };
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
            
            if (selected) layers.Mask = int.MaxValue;

            group.Layers.Mask = layers.Mask;
            group.Traverse(e => e.Layers.Mask = layers.Mask);

            if (Object3D != null)
            {
                Object3D.Parent.Remove(Object3D);
            }

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
                if (child is NSTEntity entity && entity.IsPrefabChild) continue;
                if (child.GetObject() is CScriptTriggerEntity) continue;

                group.Add(child.CreateObject3D(selected));
            }

            return group;
        }

        private THREE.Mesh? CreateSpecialObject3D(bool focused = false)
        {
            if (Object is CEntity entity && (Object is CScriptTriggerEntity || Object is CDynamicClipEntity))
            {
                THREE.Vector3 size = entity._max.ToVector3() - entity._min.ToVector3();
                THREE.Color color = new THREE.Color(Object is CScriptTriggerEntity ? 0xFFA500 : 0xFF0000);
                THREE.Mesh mesh = CreateBoxHelper(size, color, focused);
                return mesh;
            }

            return null;
        }

        private THREE.Mesh CreateBoxHelper(THREE.Vector3 size, THREE.Color color, bool focused)
        {
            THREE.Mesh mesh = new THREE.Mesh(new THREE.BoxGeometry(1, 1, 1), new THREE.MeshBasicMaterial() {
                Color = color,
                Wireframe = true
            });

            mesh.Position.Z += size.Z / 2;
            mesh.Scale.Copy(size);
            mesh.ApplyMatrix4(ObjectToWorld());

            mesh.UserData["entity"] = this;

            if (!focused)
            {
                layers.Set((int)LevelExplorer.CameraLayer.Triggers);
                mesh.Layers.Set((int)LevelExplorer.CameraLayer.Triggers);
            }

            return mesh;
        }

        public List<igEntity> GetPrefabChildren()
        {
            igPrefabComponentData? prefabComponent = Object.GetComponent<igPrefabComponentData>();

            if (prefabComponent?._prefabEntities == null) return [];

            return prefabComponent._prefabEntities._data.ToList();
        }

        public NSTSpline? InitSpline()
        {
            CSplineComponentData? splineComponent = Object.GetComponent<CSplineComponentData>();

            if (splineComponent?._spline is igSpline2 igSpline)
            {
                if (igSpline._data != null && igSpline._data._data.Count > 0)
                {
                    NSTSpline nstSpline = new NSTSpline(this, igSpline);
                    Children.Add(nstSpline);
                    return nstSpline;
                }
            }

            return null;
        }

        public void InitScriptTriggerEntity(IgArchive archive, List<NSTEntity> entities)
        {
            if (Object is CScriptTriggerEntity trigger)
            {
                Spawner_Trigger_LogicData? spawner = trigger.GetComponent<Spawner_Trigger_LogicData>();
                NamedReference? reference = spawner?._SpawnerActivationList.Reference;

                if (reference != null)
                {
                    CEntityHandleList? handleList = (CEntityHandleList?)AlchemyUtils.FindObjectInArchives(reference, archive);

                    if (handleList != null)
                    {
                        foreach (var handleMetaField in handleList._data)
                        {
                            NamedReference? handle = handleMetaField?.Reference;

                            NSTEntity? spawnedEntity = entities.FirstOrDefault(e => 
                                e.Object.ObjectName == handle?.objectName &&
                                e.FileNamespace == handle?.namespaceName
                            );

                            if (spawnedEntity == null)
                            {
                                Console.WriteLine($"WARNING: Could not find spawned entity {handle?.objectName} for {Object.ObjectName}");
                                continue;
                            }

                            spawnedEntity.Children.Add(this);
                        }
                    }
                }
            }
            else
            {
                foreach (igComponentData component in Object.GetComponents())
                {
                    foreach (NamedReference handle in component.GetHandles())
                    {
                        NSTEntity? spawnedEntity = entities.FirstOrDefault(e => 
                            e.Object.ObjectName == handle.objectName &&
                            e.FileNamespace == handle.namespaceName
                        );

                        if (spawnedEntity == null)
                        {
                            // Console.WriteLine($"WARNING: Could not find spawned entity {handle.objectName} for {Object.ObjectName}");
                            continue;
                        }

                        if (spawnedEntity.Object is CScriptTriggerEntity)
                        {
                            Console.WriteLine($"Add script trigger entity {spawnedEntity.Object.ObjectName} as child of {Object.ObjectName}");
                            Children.Add(spawnedEntity);
                        }
                    }
                }
            }
        }

        public THREE.Matrix4 ObjectToWorld()
        {
            THREE.Vector3 position = Object._parentSpacePosition.ToVector3();

            THREE.Matrix4 modelMatrix = THREE.Matrix4.CreateTranslation(position.X, position.Y, position.Z);

            if (Object._transform != null)
            {
                THREE.Vector3 scale = Object._transform._nonUniformPersistentParentSpaceScale.ToVector3();
                THREE.Euler rotation = Object._transform._parentSpaceRotation.ToEuler();
                THREE.Quaternion quaternion = new THREE.Quaternion().SetFromEuler(rotation);

                modelMatrix = new THREE.Matrix4().Compose(position, quaternion, scale);
            }

            // model = Matrix4.CreateRotationZ(_previewRotation) * model;
            // if (_model.GetName().StartsWith("Collectible_") || _model.GetName() == "crash_wumpafruit_no_sparkles") 
            //     _previewRotation += 0.01f;

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
                layers = layers, 
                CollisionShapeIndex = CollisionShapeIndex, 
                IsTemplate = IsTemplate,
                IsHidden = IsHidden
            };
        }

        public NSTEntity CloneAsPrefabChild(NSTEntity parentPrefabInstance)
        {
            NSTEntity childInstance = Clone(Object);

            childInstance.PrefabTemplate = this;
            childInstance.ParentPrefabInstance = parentPrefabInstance;

            if (Object._bitfield._canSpawn)
            {
                childInstance.IsTemplate = false;
                childInstance.IsHidden = false;
            }

            IsPrefabTemplate = true;
            PrefabTemplateInstances.Add(childInstance);

            parentPrefabInstance.IsPrefabInstance = true;
            parentPrefabInstance.Children.Add(childInstance);

            return childInstance;
        }
    }

    public class NSTSpline : NSTObject<igSpline2>
    {
        public NSTEntity _parent;
        List<NSTSplineControlPoint> _controlPoints = [];
        public THREE.Color Color;

        public NSTSpline(NSTEntity parent, igSpline2 spline)
        {
            _parent = parent;
            Object = spline;

            ArchiveFile = parent.ArchiveFile;

            uint hash = NamespaceUtils.ComputeHash(spline.ObjectName ?? spline.GetType().Name);
            Color = new THREE.Color((int)hash);
            Color.R = Color.R * 0.5f + 0.5f;
            Color.G = Color.G * 0.5f + 0.5f;
            Color.B = Color.B * 0.5f + 0.5f;

            if (spline._data == null) return;

            foreach (igSplineControlPoint2 point in spline._data._data)
            {
                var controlPoint = new NSTSplineControlPoint(this, point);
                _controlPoints.Add(controlPoint);
                Children.Add(controlPoint);
            }
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            List<THREE.Vector3> controlPoints = _controlPoints.Select(p => p.Object._position.ToVector3()).ToList();

            if (Object._looping)
            {
                controlPoints.Add(controlPoints[0]);
            }

            var lineMesh = CreateLineMesh(controlPoints);
            var pointMesh = CreateControlPointsMesh(controlPoints);

            lineMesh.Add(pointMesh);

            lineMesh.ApplyMatrix4(_parent.ObjectToWorld());

            if (!selected && !_controlPoints.Any(e => e.Object3D != null))
            {
                lineMesh.Layers.Set((int)LevelExplorer.CameraLayer.Splines);
                lineMesh.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.Splines));
            }

            lineMesh.UserData["spline"] = this;
            lineMesh.Traverse(e => e.UserData["spline"] = this);

            Object3D = lineMesh;

            return lineMesh;
        }

        private THREE.Line CreateLineMesh(List<THREE.Vector3> points)
        {
            var lineGeometry = new THREE.BufferGeometry();
            var lineMaterial = new THREE.LineBasicMaterial() { Color = Color, LineWidth = 2 };

            float[] positions = points.SelectMany(p => new float[] { p.X, p.Y, p.Z }).ToArray();

            lineGeometry.SetAttribute("position", new THREE.BufferAttribute<float>(positions, 3));
            lineGeometry.ComputeBoundingSphere();

            return new THREE.Line(lineGeometry, lineMaterial);
        }

        private THREE.InstancedMesh CreateControlPointsMesh(List<THREE.Vector3> points)
        {
            var sphereGeo = new THREE.SphereGeometry(8, 10, 10);
            var controlPointsMat = new THREE.MeshBasicMaterial() { Color = Color };

            var instancedMesh = new THREE.InstancedMesh(sphereGeo, controlPointsMat, points.Count) { FrustumCulled = false };

            for (int i = 0; i < points.Count; i++)
            {
                instancedMesh.SetMatrixAt(i, new THREE.Matrix4().SetPosition(points[i]));
            }

            return instancedMesh;
        }
    }

    public class NSTSplineControlPoint : NSTObject<igSplineControlPoint2>
    {
        public NSTSpline _parent;

        public NSTSplineControlPoint(NSTSpline parent, igSplineControlPoint2 point)
        {
            _parent = parent;
            Object = point;

            ArchiveFile = parent.ArchiveFile;
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            var sphereGeo = new THREE.SphereGeometry(8, 10, 10);
            var sphereMat = new THREE.MeshBasicMaterial() { Color = _parent.Color };
            var sphereMesh = new THREE.Mesh(sphereGeo, sphereMat);

            sphereMesh.Position.Set(Object._position._x, Object._position._y, Object._position._z);
            sphereMesh.ApplyMatrix4(_parent._parent.ObjectToWorld());

            Object3D = sphereMesh;

            return sphereMesh;
        }
    }
}