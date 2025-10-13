using Alchemy;
using ImGuiNET;
using System.Numerics;
using System.Text.RegularExpressions;

namespace NST
{
    /// <summary>
    /// Represents a node in an IGZ tree
    /// </summary>
    public class IgzTreeNode : TreeNode
    {
        const bool showBaseMetaObjectTypes = false;

        public igObject? Object { get; } = null; // Corresponding object, null for folders

        public List<IgzTreeNode> Parents { get; } = []; // Parent object nodes
        public bool RootNode { get; set; } = false; // Is this node a root node?
        public int InitialParentCount { get; set; } = 0;

        // Preview-related
        public NSTMaterial? MaterialPreview { get; set; } = null;
        public CSoundPreview? SoundPreview { get; set; } = null;
        public CSubSoundPreview? SubSoundPreview { get; set; } = null;
        private bool _audioPreview = false;

        /// <summary>
        /// Object node constructor
        /// </summary>
        public IgzTreeNode(igObject obj)
        {
            Object = obj;
            _uuid = ImGuiUtils.Uuid();
        }

        /// <summary>
        /// Folder node constructor
        /// </summary>
        public IgzTreeNode(string name, List<IgzTreeNode>? children = null)
        {
            Name = name;
            IsFolder = true;
            Children = children?.Cast<TreeNode>().ToList() ?? [];
            _uuid = ImGuiUtils.Uuid();
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

                case IgzTreeView.ObjectHierarchyMode.Updated:
                    return IsUpdated;

                case IgzTreeView.ObjectHierarchyMode.Named:
                    return Object?.ObjectName != null;

                case IgzTreeView.ObjectHierarchyMode.Root:
                    if (!exploredNodes.Contains(this))
                    {
                        if (Parents.Count == 0) return true; 
                        if (Object?.GetType() == typeof(igVscMetaObject)) return true;
                        if (Object?.GetType().IsAssignableTo(typeof(igFxMaterial)) == true) return true;
                    }
                    if (Object is igEntity entity && entity._bitfield._canSpawn && !entity._bitfield._isArchetype) return true;
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Called when this node becomes the currently focused node
        /// </summary>
        private void OnFocus()
        {
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
        }

        /// <summary>
        /// Setup and render this node
        /// </summary>
        public void Render(IgzTreeView tree, List<IgzTreeNode> parentNodes, IgzTreeNode? parent = null, bool defaultOpen = false)
        {
            bool recursion = parentNodes.Contains(this);

            NodePath = string.Join(" > ", parentNodes.Select(n => n.GetDisplayName())) + " > " + GetDisplayName();

            // Setup node
            ImGuiTreeNodeFlags? flags = SetupNode(tree, recursion, defaultOpen, OnFocus);

            if (flags == null)  return;

            // Render item
            if (Object == null)
            {
                RenderFolderNode(tree, flags.Value);
            }
            else
            {
                RenderObjectNode(tree, parentNodes, parent, flags.Value, recursion);
            }

            tree.PreviousNode = this;

            // Render children
            if (IsOpen && !recursion)
            {
                bool openChildNode = Children.Count == 1;

                parentNodes.Add(this);
                
                foreach (IgzTreeNode child in Children.ToList())
                {
                    child.Render(tree, parentNodes, this, openChildNode);
                }

                parentNodes.Remove(this);
            }
            if (IsOpen) ImGui.TreePop();
        }

        /// <summary>
        /// Renders this node as an object node
        /// </summary>
        private void RenderObjectNode(IgzTreeView tree, List<IgzTreeNode> parentNodes, IgzTreeNode? parent, ImGuiTreeNodeFlags flags, bool recursion)
        {
            if (Object == null)
            {
                RenderFolderNode(tree, flags);
                return;
            }

            bool multiReferences = Parents.Count > 1 || (Parents.Count == 1 && RootNode);
            bool subselected = (tree.SelectedNode == this && NodePath != tree.SelectedNodePath);

            if (multiReferences)
            {
                if (Children.Count == 0) flags |= ImGuiTreeNodeFlags.Bullet;
                ImGui.PushStyleColor(ImGuiCol.Text, 0xff0099ff);
            }
            if (subselected)
            {
                ImGui.PushStyleColor(ImGuiCol.Header, new System.Numerics.Vector4(1, 1, 1, 0.15f));
            }

            IsOpen = ImGui.TreeNodeEx("###" + _uuid, flags);

            if (multiReferences) ImGui.PopStyleColor();
            if (subselected) ImGui.PopStyleColor();

            if (ImGui.BeginPopupContextItem("IgzObjectPopup" + _uuid))
            {
                RenderContextMenu(tree);
                ImGui.EndPopup();
            }

            HandleNavigation(tree);

            if (recursion)
            {
                ImGui.SameLine();
                ImGui.Text("(Recursion) ");
            }

            ImGui.SameLine(0, 0);

            HighlightText(GetDisplayName(), tree.SearchQuery);

            RenderObjectName(tree.IsSearchActive ? null : parent);
        }

        /// <summary>
        /// Renders this node as a folder node
        /// </summary>
        private void RenderFolderNode(IgzTreeView tree, ImGuiTreeNodeFlags flags)
        {
            string folderTypeStr = Name.Split(' ')[0];
            Type? folderType = Type.GetType("Alchemy." + folderTypeStr);
            uint typeColor = folderType?.GetUniqueColor() ?? 0xffffffff;

            IsOpen = ImGui.TreeNodeEx("###" + _uuid, flags);

            HandleNavigation(tree);

            ImGui.SameLine(0, 0);
            ImGui.PushStyleColor(ImGuiCol.Text, typeColor);
            ImGui.Text(Name);
            ImGui.PopStyleColor();
        }

        public void UpdateFolderName()
        {
            if (!IsFolder) return;
            Name = Regex.Replace(Name, @"\(\d+\)$", $"({Children.Count})");
        }

        /// <summary>
        /// Returns the display name for this node in the form "(Type): (Name)" or "(Type) (Count)"
        /// </summary>
        public override string GetDisplayName()
        {
            if (Object == null) return "";

            string? objectName = Object.ObjectName;
            string displayName = Object.GetType().Name;

            if (showBaseMetaObjectTypes && AttributeUtils.GetBaseMetaObjectType(Object) is Type baseMetaObjectType)
            {
                // Simplify MetaObjects names
                objectName = displayName;
                displayName = baseMetaObjectType.Name;
            }

            if (objectName != null)
            {
                displayName += ": " + objectName;
            }
            else if (TypeCount > 0)
            {
                displayName += " " + TypeCount;
            }

            return displayName;
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
            string? objectName = Object.ObjectName;
            bool hasName = !string.IsNullOrEmpty(objectName);
            
            if (showBaseMetaObjectTypes && prettifyMetaObjects && AttributeUtils.GetBaseMetaObjectType(Object) is Type baseMetaObjectType)
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
                string? parentName = parent?.Object?.ObjectName;
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
            ImGui.BeginChild("ObjectHeader" + _uuid, Vector2.Zero, ImGuiChildFlags.AutoResizeY, ImGuiWindowFlags.HorizontalScrollbar);

            // Object name

            renderer.TreeView.RenderHistoryArrows();
            RenderObjectName(null, false);

            // Hash table

            if (Object.GetType().IsAssignableTo(typeof(igHashTable)))
            {
                FieldRenderer.RenderHashTable(renderer, (dynamic)Object);
                ImGui.Spacing();
            }
            
            // "Focus" button

            if (Object is igEntity entity || Object is igSpline2 || Object is igSplineControlPoint2)
            {
                if (ImGui.SmallButton("Focus in editor"))
                {
                    App.FocusObject3D(renderer.ArchiveRenderer.Archive, Object);
                }
            }

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

            ImGui.BeginChild("ObjectFields" + _uuid);
            
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
                        tree.SetSelectedNode(parent);
                    }

                    ImGui.SameLine();
                    parent.RenderObjectName(null, false);
                }

                ImGui.TreePop();
            }

            ImGui.Separator();
            ImGui.Spacing();
        }

        /// <summary>
        /// Context menu that appears when right-clicking an object node
        /// </summary>
        private void RenderContextMenu(IgzTreeView tree)
        {
            if (Object == null) return;

            if (ImGui.Selectable("Copy object name"))
            {
                ImGui.SetClipboardText(GetDisplayName());
            }
            
            Dictionary<string, CloneMode> pasteModes = new()
            {
                { "shallow", CloneMode.Shallow },
                { "deep", CloneMode.Deep | CloneMode.SkipComponents },
                { "full", CloneMode.Deep },
            };
            foreach ((string modeStr, CloneMode mode) in pasteModes)
            {
                if (ImGui.Selectable($"Copy object ({modeStr})"))
                {
                    IgzRenderer.CopyObject = (igObject)Object.Clone(mode: CloneMode.Shallow);
                    IgzRenderer.CopyRenderer = tree.Renderer;
                    IgzRenderer.CopyMode = mode;
                }
            }

            if (IgzRenderer.CopyObject != null && IgzRenderer.CopyRenderer != null)
            {
                ImGui.Separator();
                
                if (ImGui.Selectable($"Paste object ({IgzRenderer.CopyObject.GetType().Name})"))
                {
                    // Paste in the same file
                    if(tree.Renderer == IgzRenderer.CopyRenderer)
                    {
                        igObject clone = tree.Renderer.Igz.AddClone(IgzRenderer.CopyObject, mode: IgzRenderer.CopyMode);
                        IgzTreeNode newNode = tree.Add(clone, true)[0];
                        tree.SetSelectedNode(newNode);
                    }
                    // Paste in a different file
                    else if (tree.Renderer.ArchiveRenderer == IgzRenderer.CopyRenderer.ArchiveRenderer)
                    {
                        igObject clone = tree.Renderer.Igz.AddClone(IgzRenderer.CopyObject, IgzRenderer.CopyRenderer.Igz);
                        IgzTreeNode newNode = tree.Add(clone, true)[0];
                        tree.SetSelectedNode(newNode);

                        foreach (var tdep in IgzRenderer.CopyRenderer.Igz.Dependencies)
                        {
                            if (!tree.Renderer.Igz.Dependencies.Contains(tdep))
                            {
                                tree.Renderer.Igz.Dependencies.Add(tdep);
                            }
                        }
                    }
                    // Paste in a different archive
                    else
                    {
                        igObject clone = IgzFile.Clone(IgzRenderer.CopyObject,
                            IgzRenderer.CopyRenderer.ArchiveRenderer.Archive, tree.Renderer.ArchiveRenderer.Archive,
                            IgzRenderer.CopyRenderer.Igz, tree.Renderer.Igz
                        );
                        IgzTreeNode newNode = tree.Add(clone, true)[0];
                        tree.SetSelectedNode(newNode);
                    }
                }

                bool canPasteValues = Object.GetType().IsAssignableTo(IgzRenderer.CopyObject.GetType());

                if (!canPasteValues) ImGui.BeginDisabled();

                if (ImGui.Selectable("Paste object values"))
                {
                    IgzRenderer.CopyObject.Copy(Object);
                    tree.RebuildNode(this);
                }

                if (!canPasteValues) ImGui.EndDisabled();
            }

            ImGui.Separator();

            if (ImGui.Selectable("Rename"))
            {
                ModalRenderer.ShowRenameModal(Object.ObjectName ?? "", (newName) => 
                {
                    Object.ObjectName = newName;
                    tree.Renderer.SetUpdated(Object);
                });
            }
            if (ImGui.Selectable("Duplicate"))
            {
                igObject clone = tree.Renderer.Igz.AddClone(Object, mode: CloneMode.Deep | CloneMode.SkipComponents);
                IgzTreeNode newNode = tree.Add(clone, true)[0];
                tree.SetSelectedNode(newNode);
            }
            if (ImGui.Selectable("Delete"))
            {
                List<igObject> removed = tree.Renderer.Igz.Remove(Object).ToList();

                foreach (igObject obj in removed)
                {
                    tree.Remove(this, false);
                    tree.Renderer.SetUpdated(Object);
                }

                if (tree.SelectedNode == this)
                {
                    tree.SetSelectedNode(null);
                }
            }
        }

        // private void _RenderExternalReferences(IgzRenderer renderer)
        // {
        //     string? objectName = Object?.ObjectName;

        //     if (objectName == null) return;

        //     List<string> externalReferences = NamespaceUtils.FindExternalReference(renderer.Igz.GetName(false), objectName);

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