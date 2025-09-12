using Havok;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Represents a hkObject node in a Havok tree
    /// </summary>
    public class HavokTreeNode : TreeNode
    {
        public hkObject Object { get; }

        public HavokTreeNode(hkObject obj) => Object = obj;
        
        public override string GetDisplayName()
        {
            string typeName = Object.GetType().Name;
            string displayName = typeName;

            if (!string.IsNullOrEmpty(Name))
            {
                displayName += ": " + Name;
            }
            else if (TypeCount > 0)
            {
                displayName += " " + TypeCount;
            }

            return displayName;
        }

        /// <summary>
        /// Setup and render this node
        /// </summary>
        public void Render(HavokTreeView tree, List<HavokTreeNode> parentNodes, HavokTreeNode? parent = null, bool defaultOpen = true)
        {
            bool recursion = parentNodes.Contains(this);

            NodePath = string.Join(" > ", parentNodes.Select(n => n.GetDisplayName())) + " > " + GetDisplayName();

            // Setup node
            ImGuiTreeNodeFlags? flags = SetupNode(tree, recursion, defaultOpen);

            if (flags == null) return;

            // Render item
            RenderNode(tree, parentNodes, parent, flags.Value, recursion);

            tree.PreviousNode = this;

            // Render children
            if (IsOpen && !recursion)
            {
                bool openChildNode = Children.Count == 1;

                parentNodes.Add(this);
                
                foreach (HavokTreeNode child in Children)
                {
                    child.Render(tree, parentNodes, this, openChildNode);
                }

                parentNodes.Remove(this);
            }
            if (IsOpen) ImGui.TreePop();
        }

        /// <summary>
        /// Render the node
        /// </summary>
        private void RenderNode(HavokTreeView tree, List<HavokTreeNode> parentNodes, HavokTreeNode? parent, ImGuiTreeNodeFlags flags, bool recursion)
        {
            bool subselected = (tree.SelectedNode == this && NodePath != tree.SelectedNodePath);

            if (subselected) ImGui.PushStyleColor(ImGuiCol.Header, new System.Numerics.Vector4(1, 1, 1, 0.15f));

            IsOpen = ImGui.TreeNodeEx("##" + GetHashCode(), flags);

            if (subselected) ImGui.PopStyleColor();

            HandleNavigation(tree);

            if (recursion)
            {
                ImGui.SameLine();
                ImGui.Text("(Recursion) ");
            }

            ImGui.SameLine(0, 0);

            HighlightText(GetDisplayName()!, tree.SearchQuery);

            RenderObjectName(tree.IsSearchActive ? null : parent);
        }

        /// <summary>
        /// Render the object name
        /// </summary>
        public void RenderObjectName(HavokTreeNode? parent = null, bool prettifyMetaObjects = true)
        {
            Type objectType = Object.GetType();
            string typeName = objectType.Name;
            string objectName = Name;
            bool hasName = !string.IsNullOrEmpty(Name);

            if (hasName)
            {
                typeName += ": ";
            }
            // Add type count if no name
            else if (TypeCount > 0) typeName += " " + TypeCount;

            if (IsUpdated) {
                if (hasName) objectName += "*";
                else typeName += "*";
            }

            // Render object type
            uint typeColor = IsUpdated && !hasName ? 0xff0099ff : objectType.GetUniqueColor();
            ImGui.PushStyleColor(ImGuiCol.Text, typeColor);
            ImGui.Text(typeName);
            ImGui.PopStyleColor();
            
            // Render object name
            if (hasName) {
                if (IsUpdated) ImGui.PushStyleColor(ImGuiCol.Text, 0xff0099ff);
                ImGui.SameLine(0, 0);
                ImGui.Text(objectName);
                if (IsUpdated) ImGui.PopStyleColor();
            }
        }

        /// <summary>
        /// Render the object fields
        /// </summary>
        /// <param name="rendererBase">Parent HavokRenderer</param>
        public override void RenderObjectView(FileRenderer rendererBase)
        {
            HavokRenderer renderer = (HavokRenderer)rendererBase;
            
            ImGui.SetNextWindowSizeConstraints(Vector2.Zero, new Vector2(-1, ImGui.GetContentRegionAvail().Y * 0.5f));
            
            ImGui.BeginChild("ObjectHeader" + GetHashCode(), Vector2.Zero, ImGuiChildFlags.AutoResizeY, ImGuiWindowFlags.HorizontalScrollbar);

            renderer.TreeView.RenderHistoryArrows();
            RenderObjectName(null, false);
            ImGui.Separator();
            ImGui.Spacing();

            ImGui.EndChild();

            ImGui.BeginChild("ObjectFields" + GetHashCode());

            renderer.RenderObject(Object);
            
            ImGui.EndChild();
        }
    }
}