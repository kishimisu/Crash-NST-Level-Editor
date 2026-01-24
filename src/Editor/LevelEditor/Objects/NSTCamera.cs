using Alchemy;
using ImGuiNET;

namespace NST
{
    public class NSTCameraBox : NSTObject<CCameraBox>
    {
        public NSTCameraBox(CCameraBox cameraBox, IgArchiveFile archiveFile)
        {
            Object = cameraBox;
            ArchiveFile = archiveFile;
        }

        public void Setup(List<NSTObject> objects)
        {
            NSTObject? cam = objects.Find(e => e.GetObject() == Object._camera);
            NSTObject? prevCam = objects.Find(e => e.GetObject() == Object._explicitlyDefinedPreviousCamera);

            if (cam != null)
            {
                Children.Add(cam);
                cam.Parents.Add(this);
            }
            if (prevCam != null)
            {
                Children.Add(prevCam);
                prevCam.Parents.Add(this);
            }
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            THREE.Group group = new THREE.Group();
            THREE.Color color = MathUtils.FromImGuiColor(Object.GetType().GetUniqueColor());

            var geo = new THREE.BoxGeometry(20, 20, 20);
            var mat = new THREE.MeshPhongMaterial() { Color = color };
            group.Add(new THREE.Mesh(geo, mat));

            group.Position.Copy(Object._position.ToVector3());
            group.Rotation.SetFromVector3(Object._rotation.ToVector3().MultiplyScalar(THREE.MathUtils.DEG2RAD), THREE.RotationOrder.ZYX);

            var min = Object._min.ToVector3();
            var max = Object._max.ToVector3();
            group.Add(CreateBoxHelper(min, max, color, selected, LevelExplorer.CameraLayer.CameraBox));
            
            if (selected)
            {
                var arrow = CreateArrow(color);
                arrow.RotateZ(-MathF.PI * 0.5f);
                arrow.TranslateZ((min.Z + max.Z) * 0.5f);
                group.Add(arrow);
            }
            else
            {
                group.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.CameraBox));
            }

            group.Traverse(e => e.UserData["entity"] = this);

            if (Object3D != null)
            {
                Object3D.Parent?.Remove(Object3D);
            }

            Object3D = group;

            return group;
        }

        private THREE.Object3D CreateArrow(THREE.Color color)
        {
            const float baseLength = 1000;
            const float arrowLength = 180;
            const float baseRadius = 14;
            const float arrowRadius = 80;

            THREE.CylinderGeometry baseGeo = new THREE.CylinderGeometry(baseRadius, baseRadius, baseLength);
            THREE.ConeGeometry coneGeo = new THREE.ConeGeometry(arrowRadius, arrowLength, 8);
            THREE.Material mat = new THREE.MeshPhongMaterial() { Color = color, Shininess = NSTMaterial.DefaultShininess };

            THREE.Mesh baseMesh = new THREE.Mesh(baseGeo, mat);
            THREE.Mesh coneMesh = new THREE.Mesh(coneGeo, mat);

            coneMesh.TranslateY(baseLength * 0.5f);

            return new THREE.Group() { baseMesh, coneMesh };
        }

        public override void Render(LevelExplorer explorer)
        {
            base.Render(explorer);

            RenderTransform(ref Object._position, ref Object._rotation, explorer);

            RenderBounds(ref Object._min, ref Object._max, explorer);

            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Properties");
            ImGui.PopStyleColor();

            RenderEntityData(explorer);
        }

        public override void RenderEntityData(LevelExplorer explorer)
        {
            ComponentRenderer.RenderObject("Camera:", Object._camera, FileNamespace, typeof(CCameraBase), explorer, (value) => 
            {
                Object._camera = (CCameraBase?)value;
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
            });

            ComponentRenderer.RenderObject("Prev. camera:", Object._explicitlyDefinedPreviousCamera, FileNamespace, typeof(CCameraBase), explorer, (value) => 
            {
                Object._explicitlyDefinedPreviousCamera = (CCameraBase?)value;
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
            });
        }
    }

    public class NSTCamera : NSTObject<CCamera>
    {
        public NSTCamera(CCamera camera, IgArchiveFile archiveFile)
        {
            Object = camera;
            ArchiveFile = archiveFile;
        }

        public void Setup(List<NSTEntity> entities)
        {
            if (Object is not CSplineCamera spline || spline._splineEntity.Reference == null) return;

            NSTEntity? entity = entities.Find(e => e.FileNamespace == spline._splineEntity.Reference.namespaceName && e.Object.ObjectName == spline._splineEntity.Reference.objectName);

            if (entity == null)
            {
                Console.WriteLine($"Warning: Could not find spline entity {spline._splineEntity.Reference} for {Object}");
                return;
            }

            Children.Add(entity);
            entity.Parents.Add(this);
        }

        public override THREE.Object3D CreateObject3D(bool selected = false)
        {
            THREE.Group group = new THREE.Group();
            THREE.Color color = MathUtils.FromImGuiColor(Object.GetType().GetUniqueColor());

            var geo = new THREE.BoxGeometry(20, 20, 20);
            var mat = new THREE.MeshPhongMaterial() { Color = color };
            group.Add(new THREE.Mesh(geo, mat));

            group.Position.Copy(Object._position.ToVector3());
            group.Rotation.SetFromVector3(Object._rotation.ToVector3().MultiplyScalar(THREE.MathUtils.DEG2RAD), THREE.RotationOrder.ZYX);

            if (!selected)
            {
                group.Traverse(e => e.Layers.Set((int)LevelExplorer.CameraLayer.Camera));
            }

            group.Traverse(e => e.UserData["entity"] = this);

            if (Object3D != null)
            {
                Object3D.Parent?.Remove(Object3D);
            }

            Object3D = group;

            return group;
        }

        public override void Render(LevelExplorer explorer)
        {
            base.Render(explorer);

            RenderTransform(ref Object._position, ref Object._rotation, explorer);

            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Properties");
            ImGui.PopStyleColor();

            RenderEntityData(explorer);
        }

        public override void RenderEntityData(LevelExplorer explorer)
        {
            ImGui.SeparatorText("General");
            ComponentRenderer.RenderFloat("Damping:", ref Object._dampingFactor, this, explorer);
            ComponentRenderer.RenderFloat("FOV:", ref Object._fovStorage, this, explorer);
            ComponentRenderer.RenderFloat("Max zoom out distance:", ref Object._maxZoomOutDistance, this, explorer);

            ImGui.SeparatorText("Depth of field");
            ComponentRenderer.RenderCheckbox("Depth of field:", ref Object._depthOfFieldEnabled, this, explorer);
            ComponentRenderer.RenderFloat4("Focus planes:", ref Object._focusPlanes, this, explorer);
            ComponentRenderer.RenderFloat("Depth tether distance:", ref Object._depthTetherDistance, this, explorer);

            ImGui.SeparatorText("Shadow");
            ComponentRenderer.RenderFloat("Shadow range:", ref Object._shadowRange, this, explorer);
            ComponentRenderer.RenderFloat4("Shadow bias:", ref Object._shadowBias, this, explorer);

            if (Object is CConstrainedCamera constrainedCamera && constrainedCamera._screenSafeArea != null)
            {
                ImGui.SeparatorText("Safe area");
                ComponentRenderer.RenderFloat2("Safe area min:", ref constrainedCamera._screenSafeArea._min, this, explorer);
                ComponentRenderer.RenderFloat2("Safe area max:", ref constrainedCamera._screenSafeArea._max, this, explorer);
                ComponentRenderer.RenderFloat("Target radius min:", ref constrainedCamera._targetRadiusMin, this, explorer);
                ComponentRenderer.RenderFloat("Target radius max:", ref constrainedCamera._targetRadiusMax, this, explorer);
            }

            if (Object is CSplineCamera splineCam)
            {
                ImGui.SeparatorText("Spline camera");

                ComponentRenderer.RenderObjectReference("Spline entity:", splineCam._splineEntity.Reference, typeof(igEntity), explorer, (value) =>
                {
                    splineCam._splineEntity.Reference = value;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                });

                if (splineCam._data != null)
                {
                    ComponentRenderer.RenderFloat("Move forward distance :", ref splineCam._data._minDistanceDuringForwardMovement, this, explorer);
                    ComponentRenderer.RenderFloat("Move backward distance:", ref splineCam._data._minDistanceDuringBackwardMovement, this, explorer);
                    ComponentRenderer.RenderFloat("Move vertical distance:", ref splineCam._data._minDistanceDuringVerticalMovement, this, explorer);
                    ComponentRenderer.RenderFloat("Angle for direction change:", ref splineCam._data._directionChangeMinAngle, this, explorer);
                    ComponentRenderer.RenderFloat("Position damping:", ref splineCam._data._positionDamping, this, explorer);
                    ComponentRenderer.RenderFloat("Rotation damping:", ref splineCam._data._rotationDamping, this, explorer);
                    ComponentRenderer.RenderFloat("Distance damping:", ref splineCam._data._distanceDamping, this, explorer);
                }
            }

            if (Object is CCutsceneCamera cutsceneCamera)
            {
                ImGui.SeparatorText("Cutscene camera");

                ComponentRenderer.RenderObjectReference("Attach to entity:", cutsceneCamera._attachToEntity.Reference, typeof(igEntity), explorer, (value) =>
                {
                    cutsceneCamera._attachToEntity.Reference = value;
                    explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, Object, true);
                });

                ComponentRenderer.RenderFloat("Move speed:", ref cutsceneCamera._splineMoveSpeed, this, explorer);
            }
        }
    }
}