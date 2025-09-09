using Alchemy;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Represents a node in an IGZ tree
    /// </summary>
    public class IgzTreeNode : TreeNode
    {
        public igObject? Object { get; } = null; // Corresponding object, null for folders

        public List<IgzTreeNode> Parents { get; } = []; // Parents of this node
        public bool RootNode { get; set; } = false; // Is this node a root node?

        // Preview-related
        public NSTMaterial? MaterialPreview { get; set; } = null;
        public CSoundPreview? SoundPreview { get; set; } = null;
        public CSubSoundPreview? SubSoundPreview { get; set; } = null;
        private bool _audioPreview = false;

        public override string GetDisplayName() => GetDisplayName(true) ?? Name + GetHashCode();

        public IgzTreeNode(igObject obj) => Object = obj;
        public IgzTreeNode(string name, List<IgzTreeNode>? children = null)
        {
            Name = name;
            Children = children?.Cast<TreeNode>().ToList() ?? [];
        }

        /// <summary>
        /// Returns the display name for this node in the form "(Type): (Name)" or "(Type) (Count)"
        /// </summary>
        /// <param name="includeType">Whether to include the type in the display name</param>
        /// <returns></returns>
        public string? GetDisplayName(bool includeType)
        {
            if (Object == null) return null;

            string? objectName = Object.GetObjectName();
            string typeName = Object.GetType().Name;
            string displayName = typeName;

            if (objectName != null)
            {
                if (!includeType) displayName = objectName;
                else displayName += ": " + objectName;
            }
            else if (TypeCount > 0)
            {
                displayName += " " + TypeCount;
            }

            return displayName;
        }

        /// <summary>
        /// Checks if this node is a root node for a given hierarchy mode
        /// </summary>
        public bool IsRootNode(HashSet<IgzTreeNode> exploredNodes, IgzTreeView.ObjectHierarchyMode hierarchyMode)
        {
            switch (hierarchyMode)
            {
                case IgzTreeView.ObjectHierarchyMode.All:
                    return true;

                case IgzTreeView.ObjectHierarchyMode.Named:
                    return Object?.GetObjectName() != null;

                case IgzTreeView.ObjectHierarchyMode.Entities:
                    return Object?.GetType().IsAssignableTo(typeof(igEntity)) == true;

                case IgzTreeView.ObjectHierarchyMode.Root:
                    if (!exploredNodes.Contains(this))
                    {
                        if (Parents.Count == 0) return true; 
                        if (Object?.GetType() == typeof(igVscMetaObject)) return true;
                        if (Object?.GetType().IsAssignableTo(typeof(igFxMaterial)) == true) return true;
                    }
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Called when this node becomes the currently focused node
        /// </summary>
        private void OnFocus()
        {
            if (NextFocus == NextFocusState.FocusAndKeyboard)
                ImGui.SetKeyboardFocusHere();

            if (Object is CSubSound subSound)
            {
                SubSoundPreview = new CSubSoundPreview(this);
                SubSoundPreview.LoadAudio(false);
            }
            else if (Object is CSoundSample soundSample)
            {
                _audioPreview = true;
                AudioPlayerInstance.InitAudioPlayer(soundSample);
            }

            NextFocus = NextFocusState.None;
        }

        /// <summary>
        /// Setup and render this node
        /// </summary>
        public void Render(IgzTreeView tree, List<IgzTreeNode> parentNodes, IgzTreeNode? parent = null, bool openOnSingleChild = true)
        {
            tree.CheckNextNode(this); // Handle keyboard navigation down

            // Setup flags
            ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.SpanFullWidth;
            
            bool recursion = parentNodes.Contains(this);

            if (Children.Count == 0 || recursion)
            {
                flags |= ImGuiTreeNodeFlags.Leaf;
            }
            else if (Children.Count == 1 && openOnSingleChild)
            {
                flags |= ImGuiTreeNodeFlags.DefaultOpen;
            }
            if (tree.SelectedNode == this)
            {
                flags |= ImGuiTreeNodeFlags.Selected;

                if (NextFocus != NextFocusState.None)
                {
                    OnFocus();
                }
            }

            // Handle search
            if (tree.IsSearchActive() && !IsSearchResult)
            {
                return;
            }
            if (NextOpen != null)
            {
                ImGui.SetNextItemOpen((bool)NextOpen);
                NextOpen = null;
            }
            
            // Render item
            if (Object == null)
            {
                IsOpen = RenderFolderNode(tree, flags);
            }
            else
            {
                IsOpen = RenderObjectNode(tree, parentNodes, parent, flags, recursion);
            }

            tree.PreviousNode = this;

            // Render children
            if (IsOpen && !recursion)
            {
                bool hasOnlyOneChild = Children.Count == 1;

                parentNodes.Add(this);
                
                foreach (IgzTreeNode child in Children)
                {
                    child.Render(tree, parentNodes, this, hasOnlyOneChild);
                }

                parentNodes.Remove(this);
            }
            if (IsOpen) ImGui.TreePop();
        }

        /// <summary>
        /// Renders this node as an object node
        /// </summary>
        private bool RenderObjectNode(IgzTreeView tree, List<IgzTreeNode> parentNodes, IgzTreeNode? parent, ImGuiTreeNodeFlags flags, bool recursion)
        {
            if (Object == null)
            {
                return RenderFolderNode(tree, flags);
            }

            bool multiReferences = Parents.Count > 1 || (Parents.Count == 1 && RootNode);

            if (multiReferences)
            {
                if (Children.Count == 0) flags |= ImGuiTreeNodeFlags.Bullet;
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff0099ff);
            }
            
            bool isOpen = ImGui.TreeNodeEx("##" + GetHashCode(), flags);

            if (multiReferences) 
            {
                ImGui.PopStyleColor();
            }

            if (ImGui.IsItemClicked())
            {
                tree.SetSelectedNode(this);
            }
            else if (ImGui.IsItemFocused())
            {
                if (ImGui.IsKeyPressed(ImGuiKey.UpArrow)) tree.SetSelectedNode(tree.PreviousNode);
                else if (ImGui.IsKeyPressed(ImGuiKey.DownArrow)) tree.SelectNextNode = true;
                else if (ImGui.IsKeyPressed(ImGuiKey.LeftArrow) && IsOpen) NextOpen = false;
                else if (ImGui.IsKeyPressed(ImGuiKey.RightArrow) && !IsOpen) NextOpen = true;
            }

            if (recursion)
            {
                ImGui.SameLine();
                ImGui.Text("(Recursion)");
            }

            ImGui.SameLine(0, 0);

            HighlightText(GetDisplayName()!, tree.SearchQuery);

            RenderObjectName(tree.IsSearchActive() ? null : parent);

            return isOpen;
        }

        /// <summary>
        /// Renders this node as a folder node
        /// </summary>
        private bool RenderFolderNode(IgzTreeView tree, ImGuiTreeNodeFlags flags)
        {
            string folderTypeStr = Name.Split(' ')[0];
            Type? folderType = Type.GetType("Alchemy." + folderTypeStr);
            uint typeColor = folderType?.GetUniqueColor() ?? 0xffffffff;

            bool expanded = ImGui.TreeNodeEx("##" + Name, flags);

            ImGui.SameLine(0, 0);
            ImGui.PushStyleColor(ImGuiCol.Text, typeColor);
            ImGui.Text(Name);
            ImGui.PopStyleColor();
            
            if (ImGui.IsItemFocused()) // TODO: This code is duplicated 3 times
            {
                if (ImGui.IsKeyPressed(ImGuiKey.UpArrow)) tree.SetSelectedNode(tree.PreviousNode);
                else if (ImGui.IsKeyPressed(ImGuiKey.DownArrow)) tree.SelectNextNode = true;
                else if (ImGui.IsKeyPressed(ImGuiKey.LeftArrow) && IsOpen) NextOpen = false;
                else if (ImGui.IsKeyPressed(ImGuiKey.RightArrow) && !IsOpen) NextOpen = true;
            }

            return expanded;
        }

        /// <summary>
        /// Renders the colorized object type and name
        /// </summary>
        /// <param name="parent">Parent node, used to shorten child object names</param>
        /// <param name="prettifyMetaObjects">Whether to shorten MetaObject names</param>
        public void RenderObjectName(IgzTreeNode? parent = null, bool prettifyMetaObjects = true)
        {
            if (Object == null) return;

            Type objectType = Object.GetType();
            string typeName = objectType.Name;
            string? objectName = Object.GetObjectName();
            bool hasName = !string.IsNullOrEmpty(objectName);

            Type? baseMetaObjectType = AttributeUtils.GetBaseMetaObjectType(Object);
            
            if (prettifyMetaObjects && baseMetaObjectType != null)
            {
                // Simplify MetaObjects names
                typeName = baseMetaObjectType.Name + ": ";
                objectName = objectType.Name;
                objectType = baseMetaObjectType;
            }
            else if (hasName)
            {
                typeName += ": ";

                // Simplify names that start with their parent name
                string? parentName = parent?.Object?.GetObjectName();
                if (parentName != null && objectName!.StartsWith(parentName))
                {
                    objectName = objectName.Substring(parentName.Length);
                    if (!objectName.StartsWith("_")) objectName = "_" + objectName;
                }
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
        /// Renders the object fields
        /// </summary>
        /// <param name="fileRenderer">Parent IGZRenderer</param>
        public override void RenderObjectView(FileRenderer fileRenderer)
        {
            if (Object == null) return;

            IgzRenderer renderer = (IgzRenderer)fileRenderer;
            
            ImGui.SetNextWindowSizeConstraints(Vector2.Zero, new Vector2(-1, ImGui.GetContentRegionAvail().Y * 0.5f));
            ImGui.BeginChild("ObjectHeader" + GetHashCode(), Vector2.Zero, ImGuiChildFlags.AutoResizeY, ImGuiWindowFlags.HorizontalScrollbar);

            // Object name

            renderer.TreeView.RenderHistoryArrows();
            RenderObjectName(null, false);

            // Previews

            MaterialPreview?.Render(renderer, this, false);
            SoundPreview?.Render(renderer, true);
            SubSoundPreview?.Render(renderer, true);
            if (_audioPreview) AudioPlayerInstance.Render();

            ImGui.Separator();
            ImGui.Spacing();
            
            // References

            RenderObjectReferences(renderer.TreeView);

            // _RenderExternalReferences(renderer);
            ImGui.EndChild();

            // Object properties table

            ImGui.BeginChild("ObjectFields" + GetHashCode());

            if (Object.GetType().IsAssignableTo(typeof(igHashTable)))
            {
                FieldRenderer.RenderHashTable(renderer, (dynamic)Object, Object.GetType().GetDisplayName());
            }
            
            renderer.RenderObject(Object);

            ImGui.EndChild();
        }

        /// <summary>
        /// Renders the object references
        /// </summary>
        private void RenderObjectReferences(IgzTreeView tree)
        {
            if (Parents.Count == 0) return;
            if (Parents.Count == 1 && !RootNode) return;

            ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanAvailWidth;
            if (Parents.Count < 10) flags |= ImGuiTreeNodeFlags.DefaultOpen;

            bool open = ImGui.TreeNodeEx($"References ({Parents.Count})", flags);
            
            if (open)
            {
                foreach (IgzTreeNode parent in Parents)
                {
                    ImGui.PushStyleColor(ImGuiCol.Text, 0xff0099ff);
                    ImGui.Bullet();
                    ImGui.PopStyleColor();
                    
                    if (ImGui.Selectable("##" + parent.GetDisplayName()))
                    {
                        tree.SetSelectedNode(parent, true);
                    }

                    ImGui.SameLine();
                    parent.RenderObjectName(null, false);
                }

                ImGui.TreePop();
            }

            ImGui.Separator();
            ImGui.Spacing();
        }

        // private void _RenderExternalReferences(IgzRenderer renderer)
        // {
        //     string? objectName = Object?.GetObjectName();

        //     if (objectName == null) return;

        //     List<string> externalReferences = NamespaceUtils.FindExternalReference(renderer.GetIgz().GetName(false), objectName);

        //     if (externalReferences.Count == 0) return;

        //     ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.SpanAvailWidth;
        //     if (externalReferences.Count < 10) flags |= ImGuiTreeNodeFlags.DefaultOpen;

        //     if (ImGui.TreeNodeEx($"External References ({externalReferences.Count})", flags))
        //     {
        //         foreach (string reference in externalReferences)
        //         {
        //             ImGui.Bullet();
        //             ImGui.SameLine();
        //             ImGui.Text(reference);
        //         }
        //         ImGui.TreePop();
        //     }

        //     ImGui.Separator();
        //     ImGui.Spacing();
        // }
    }
}