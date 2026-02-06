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
        public NamedReference ToReference() => GetObject().ToNamedReference(FileNamespace);

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

            ImGui.PushStyleColor(ImGuiCol.Text, GetObject().GetType().GetUniqueColor());
            ImGui.Text(GetObject().GetType().Name + (maxW == 0 ? ":" : ": "));
            ImGui.PopStyleColor();

            ImGui.SameLine();
            if (maxW == 0) ImGui.Text(GetObject().ObjectName);
            else
            {
                maxW -= (ImGui.GetCursorPos().X - startX);
                ImGui.Text(ImGuiUtils.TruncateTextToFit(GetObject().ObjectName!, maxW));
            }
        }

        public void RenderTransform(ref igVec3fMetaField position, ref igVec3fMetaField rotation, LevelExplorer explorer)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Transform");
            ImGui.PopStyleColor();

            bool updated = RenderVector3("Position", ref position);
            updated     |= RenderVector3("Rotation", ref rotation);

            if (updated)
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, GetObject());

                if (Object3D != null)
                {
                    explorer.SelectionManager.UpdateSelection([this]);
                }
            }
        }

        public void RenderBounds(ref igVec3fMetaField min, ref igVec3fMetaField max, LevelExplorer explorer)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Bounds");
            ImGui.PopStyleColor();

            bool updated = RenderVector3("Min     ", ref min);
            updated     |= RenderVector3("Max     ", ref max);

            if (updated && Object3D != null)
            {
                explorer.ArchiveRenderer.SetObjectUpdated(ArchiveFile, GetObject());

                if (Object3D != null)
                {
                    explorer.SelectionManager.UpdateSelection([this]);
                }
            }
        }

        public static bool RenderVector3(string name, ref igVec3fMetaField vec, float speed = 1.0f)
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
                }
            }

            ImGui.PopID();

            return changed;
        }
    }
}