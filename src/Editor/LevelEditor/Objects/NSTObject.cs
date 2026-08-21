using Alchemy;
using ImGuiNET;

namespace NST
{
    public abstract class NSTObject<T> : NSTObject where T : igObject
    {
        public T Object { get; protected set; }
        public override igObject GetObject() => Object;
    }

    public abstract class NSTObject
    {
        public IgArchiveFile ArchiveFile { get; protected set; }
        public string FileNamespace => ArchiveFile.GetName(false);
        public HashSet<NSTObject> Parents { get; protected set; } = [];
        public HashSet<NSTObject> Children { get; protected set; } = [];
        public THREE.Object3D? Object3D { get; set; }
        public bool IsSelected { get; set; } = false;

        protected static System.Numerics.Vector3? _copyVector;

        public abstract igObject GetObject();
        public abstract THREE.Object3D CreateObject3D(bool selected = false);
        public abstract THREE.Vector3 GetPosition();
        public abstract THREE.Matrix4 ObjectToWorld();

        public NamedReference ToReference() => GetObject().ToNamedReference(FileNamespace);

        public static THREE.Matrix4 ObjectToWorld(THREE.Vector3 position, THREE.Vector3 rotation)
        {
            rotation *= THREE.MathUtils.DEG2RAD;

            THREE.Euler euler = new THREE.Euler(rotation.X, rotation.Y, rotation.Z, THREE.RotationOrder.ZYX);
            THREE.Quaternion quaternion = new THREE.Quaternion().SetFromEuler(euler);

            THREE.Vector3 scale = new THREE.Vector3(1, 1, 1);

            return new THREE.Matrix4().Compose(position, quaternion, scale);
        }

        protected THREE.Mesh CreateBoxHelper(THREE.Vector3 min, THREE.Vector3 max, THREE.Color color, bool focused, LevelExplorer.CameraLayer? layer = null)
        {
            THREE.BoxGeometry geo = new THREE.BoxGeometry(1, 1, 1);

            THREE.Mesh mesh = new THREE.Mesh(geo, new THREE.MeshBasicMaterial() {
                Color = color,
                Wireframe = true
            });
            
            if (focused)
            {
                mesh.Add(new THREE.Mesh(geo, new THREE.MeshBasicMaterial() {
                    Color = color,
                    Side = THREE.Constants.DoubleSide,
                    Opacity = 0.35f,
                    Transparent = true,
                }));
            }

            mesh.Scale.Copy(max - min);
            mesh.Position.Add((max + min) / 2);

            mesh.UserData["entity"] = this;

            if (!focused && layer != null)
            {
                mesh.Layers.Set((int)layer);
            }

            return mesh;
        }

        public virtual void RenderEntityData(LevelExplorer explorer) { }

        public virtual void Render(LevelExplorer explorer)
        {
            // Render object name

            ImGui.PushID(GetObject().ObjectName);
            RenderName();
            ImGui.Separator();

            // Render parent file

            if (ImGui.Selectable("> " + ArchiveFile.GetName()))
            {
                explorer.FocusObjectInArchive(ToReference());
            }

            // Render object references
            var children = Children.Where(c => c is not NSTSpline && (c is not NSTEntity e || !e.IsTemplate)).ToList();

            if (Parents.Count > 0 || children.Count > 0) ImGui.Spacing();
            
            if (Parents.Count > 0 && ImGui.TreeNodeEx($"Show parents ({Parents.Count})"))
            {
                foreach (NSTObject obj in Parents)
                {
                    if (ImGui.Selectable("##" + obj.GetObject().ObjectName))
                    {
                        explorer.Focus(obj);
                    }
                    ImGui.SameLine();
                    ImGui.Bullet();
                    obj.RenderName();
                }
                ImGui.TreePop();
            }

            if (children.Count > 0 && ImGui.TreeNodeEx($"Show children ({children.Count})"))
            {
                foreach (NSTObject obj in children)
                {
                    if (ImGui.Selectable("##" + obj.GetObject().ObjectName))
                    {
                        explorer.Focus(obj);
                    }
                    ImGui.SameLine();
                    ImGui.Bullet();
                    obj.RenderName();
                }
                ImGui.TreePop();
            }

            ImGui.PopID();
            ImGui.Spacing();
        }

        public void RenderName(float maxW = 0)
        {
            float startX = ImGui.GetCursorPos().X;
            string objectName = GetObject().ObjectName ?? "";

            ImGui.PushStyleColor(ImGuiCol.Text, GetObject().GetType().GetUniqueColor());
            ImGui.Text(GetObject().GetType().Name + (maxW == 0 ? ":" : ": "));
            ImGui.PopStyleColor();
            ImGui.SameLine();

            if (maxW == 0)
            {
                ImGui.Text(objectName);
            }
            else
            {
                maxW -= ImGui.GetCursorPos().X - startX;

                string truncated = ImGuiUtils.TruncateTextToFit(objectName, maxW);
                ImGui.Text(truncated);

                if (truncated != objectName)
                {
                    ImGui.SetItemTooltip(objectName);
                }
            }
        }

        public void RenderTransform(ref igVec3fMetaField position, ref igVec3fMetaField rotation, LevelExplorer explorer)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Transform");
            ImGui.PopStyleColor();

            THREE.Vector3 previousPosition = position.ToVector3();
            THREE.Euler previousRotation = rotation.ToEuler(true);

            if (RenderVector3("Position", ref position, out bool onRelease))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, GetObject());
                explorer.SelectionManager.TranslateSelectionFromGUI(previousPosition, position.ToVector3());
            }
            if (onRelease) explorer.SelectionManager.ApplyChanges("translate");

            if (RenderVector3("Rotation", ref rotation, out onRelease))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, GetObject());
                explorer.SelectionManager.RotateSelectionFromGUI(previousRotation, rotation.ToEuler(true));
            }
            if (onRelease) explorer.SelectionManager.ApplyChanges("rotate");
        }

        public void RenderBounds(ref igVec3fMetaField min, ref igVec3fMetaField max, LevelExplorer explorer)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Bounds");
            ImGui.PopStyleColor();

            bool hasPressed = false;
            bool hasReleased = false;

            var previousBounds = new THREE.Box3(min.ToVector3(), max.ToVector3());

            if (RenderVector3("Min     ", ref min, out bool onPress, out bool onRelease))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, GetObject());
                if (Object3D != null) explorer.SelectionManager.UpdateSelection([this]);
            }
            hasPressed |= onPress;
            hasReleased |= onRelease;

            if (RenderVector3("Max     ", ref max, out onPress, out onRelease))
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, GetObject());
                if (Object3D != null) explorer.SelectionManager.UpdateSelection([this]);
            }
            hasPressed |= onPress;
            hasReleased |= onRelease;
            
            if (hasPressed)
            {
                explorer.UndoManager.AddAction(UndoManager.UndoActionType.Transform, previousBounds);
            }
            if (hasReleased)
            {
                var newBounds = new THREE.Box3(min.ToVector3(), max.ToVector3());
                explorer.UndoManager.FinalizeBoundsAction(newBounds);
            }
        }

        public static bool RenderVector3(string name, ref igVec3fMetaField vec, out bool onRelease, float speed = 1.0f)
        {
            return RenderVector3(name, ref vec, out _, out onRelease, speed);
        }

        public static bool RenderVector3(string name, ref igVec3fMetaField vec, out bool onPress, out bool onRelease, float speed = 1.0f)
        {
            System.Numerics.Vector3 num = vec.ToNumericsVector3();
            bool changed = false;

            ImGui.PushID(name);

            // Name
            ImGui.Text(name);
            ImGui.SameLine();

            // Input
            if (ImGui.DragFloat3("##", ref num, speed))
            {
                vec = num.ToVec3MetaField();
                changed = true;
            }
            
            onPress = ImGui.IsItemActivated();
            onRelease = ImGui.IsItemDeactivatedAfterEdit();

            ImGui.SameLine();

            // Copy
            if (ImGui.SmallButton("\uE902"))
            {
                _copyVector = num;
            }
            // Paste
            if (_copyVector != null)
            {
                ImGui.SameLine();
                if (ImGui.SmallButton("\uE901"))
                {
                    vec = _copyVector.Value.ToVec3MetaField();
                    changed = true;
                    onPress = true;
                    onRelease = true;
                }
            }

            ImGui.PopID();

            return changed;
        }
    }
}