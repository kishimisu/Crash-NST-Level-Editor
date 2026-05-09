using Alchemy;
using ImGuiNET;

namespace NST
{
    public class NSTWorldVisualData : NSTObject<CWorldVisualData>
    {
        public override THREE.Vector3 GetPosition() => new THREE.Vector3(0, 0, 0);
        public override THREE.Object3D CreateObject3D(bool selected = false) => Object3D = new THREE.Object3D();
        public override THREE.Matrix4 ObjectToWorld() => new THREE.Matrix4();

        public NSTWorldVisualData(CWorldVisualData worldVisual, IgArchiveFile archiveFile)
        {
            Object = worldVisual;
            ArchiveFile = archiveFile;
        }

        public override void Render(LevelExplorer explorer)
        {
            base.Render(explorer);

            IgzRenderer? renderer = null;

            ImGui.PushStyleColor(ImGuiCol.Text, 0xff20dfff);
            ImGui.SeparatorText("Properties");
            ImGui.PopStyleColor();

            if (ImGui.TreeNodeEx("Environment maps..."))
            {
                renderer ??= explorer.FileManager.GetOrCreateRenderer(ArchiveFile, explorer.ArchiveRenderer);
                renderer.RenderObject(Object, Object.GetFields(explorer.Archive.GameVersion));
                ImGui.TreePop();
            }

            ImGui.Spacing();

            if (Object._defaultGroup != null && ImGui.TreeNodeEx("Visual properties..."))
            {
                renderer ??= explorer.FileManager.GetOrCreateRenderer(ArchiveFile, explorer.ArchiveRenderer);
                renderer.RenderObject(Object._defaultGroup, Object._defaultGroup.GetFields(explorer.Archive.GameVersion));
                ImGui.TreePop();
            }
        }
    }
}