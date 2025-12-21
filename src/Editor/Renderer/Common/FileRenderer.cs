using Alchemy;
using ImGuiNET;
using System.Numerics;

namespace NST
{
    /// <summary>
    /// Base class for all file renderers (IgzRenderer and HavokRenderer)
    /// </summary>
    public abstract class FileRenderer
    {
        public IgArchiveFile ArchiveFile { get; protected set; } // File being rendered
        public IgArchiveRenderer ArchiveRenderer { get; protected set; } // Parent archive renderer

        public FileRenderer? LastRenderer { get; set; } = null; // Used when the file was opened through another file to render a back button
        protected IgzPreviewManager? _previewManager; // Manages previews for models, textures, audio...
        public event Action OnUpdate; // Used by the LevelExplorer's ComponentManager to listen to file updates

        public abstract ITreeView TreeView { get; } // Object tree

        /// <summary>
        /// Finds the tree node associated to the given object
        /// </summary>
        public abstract TreeNode? FindNode(object obj);
        
        /// <summary>
        /// Finds all nodes containing objects that are derived from the given type.
        /// Used for rendering igObjectRef inputs as list
        /// </summary>
        public abstract List<TreeNode> FindDerivedObjectNodes(Type type, object? current, out int currentIndex);

        public abstract byte[] SaveFile();
        public abstract void ReloadFile();
        public abstract void OnObjectRefChanged();

        public bool IsOpenAsWindow = false; // True if undocked from its parent archive renderer
        public string GetWindowName() => ArchiveFile.GetName() + "##" + GetHashCode();

        private int _popStylesOnNextRow = 0; // Used when rendering collapsible fields
        public void PopStylesOnNextRow(int count) => _popStylesOnNextRow += count;

        /// <summary>
        /// Creates a new renderer for the given archive file
        /// </summary>
        public static FileRenderer Create(IgArchiveFile archiveFile, IgArchiveRenderer archiveRenderer)
        {
            if (archiveFile.IsIGZ()) return new IgzRenderer(archiveFile.ToIgzFile(), archiveFile, archiveRenderer);
            if (archiveFile.IsHKX()) return new HavokRenderer(archiveFile.ToHavokFile(), archiveFile, archiveRenderer);

            throw new Exception("Unknown archive file type: " + archiveFile.GetName());
        }
        
        /// <summary>
        /// Mark the file as updated, optionally specifying the object that has been updated
        /// </summary>
        public virtual void SetUpdated(object? obj = null)
        {
            ArchiveRenderer.SetObjectUpdated(ArchiveFile, obj);
            OnUpdate?.Invoke();
        }

        /// <summary>
        /// Renders the IGZ file
        /// </summary>
        public void Render()
        {
            if (!IsOpenAsWindow)
            {
                RenderContent();
                return;
            }

            // Setup window size & position
            Vector2 displaySize = ImGui.GetIO().DisplaySize;
            ImGui.SetNextWindowSize(displaySize * new Vector2(0.5f, 0.5f), ImGuiCond.FirstUseEver);
            ImGui.SetNextWindowPos(new Vector2(60, 60), ImGuiCond.FirstUseEver);

            bool isUpdated = ArchiveRenderer.FileManager.IsFileUpdated(ArchiveFile);
            ImGuiWindowFlags flags = isUpdated ? ImGuiWindowFlags.UnsavedDocument : ImGuiWindowFlags.None;

            // Render content
            ImGui.Begin(GetWindowName(), ref IsOpenAsWindow, flags);
            RenderContent();
            ImGui.End();
        }

        /// <summary>
        /// Render the tree view and object view
        /// </summary>
        public void RenderContent()
        {
            // Start table
            if (!ImGui.BeginTable("FileRendererTable" + GetHashCode(), 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg))
            {
                return;
            }
            ImGui.TableNextColumn();

            // Back button
            if (LastRenderer != null)
            {
                if (ImGui.Button("<"))
                {
                    App.FocusRenderer(LastRenderer);
                }
                ImGui.SameLine();
            }

            // File name
            ImGui.Text(ArchiveFile.GetName());
            
            // Action buttons
            if (!IsOpenAsWindow && ImGui.SmallButton("Open in new window"))
            {
                IsOpenAsWindow = true;
            }

            // Render preview (texture, model, audio...)
            _previewManager?.RenderInTreeView();

            // Render tree view and object view
            RenderTreeView();
            ImGui.TableNextColumn();
            
            RenderObjectView();
            ImGui.EndTable();

            // Handle shortcuts
            if (ImGui.Shortcut(ImGuiKey.ModCtrl | ImGuiKey.W))
            {
                IsOpenAsWindow = false;
            }
        }

        /// <summary>
        /// Render the object tree
        /// </summary>
        private void RenderTreeView()
        {
            if (TreeView.NeedsRebuild)
            {
                ImGui.TextColored(new Vector4(1, 0.9f, 0, 1), "This file has been modified externally!");
                ImGui.SameLine();
                if (ImGui.Button("Rebuild tree"))
                {
                    TreeView.RebuildTree();
                }
            }

            ImGui.BeginChild("TreeView");
            TreeView.Render();
            ImGui.EndChild();
        }

        /// <summary>
        /// Render the selected object properties
        /// </summary>
        private void RenderObjectView()
        {
            ImGui.BeginChild("ObjectView");
            _previewManager?.RenderInObjectView();
            TreeView.RenderObjectView(this);
            ImGui.EndChild();
        }

        /// <summary>
        /// Render the fields of an object
        /// </summary>
        public void RenderObject(object? obj, IReadOnlyList<CachedFieldAttr>? fields = null)
        {
            if (obj == null) return;

            if (ImGui.BeginTable("IgzObjectTable", 3, 
                  ImGuiTableFlags.Resizable 
                | ImGuiTableFlags.Reorderable 
                | ImGuiTableFlags.RowBg
                | ImGuiTableFlags.BordersInner
                | ImGuiTableFlags.Hideable
                | ImGuiTableFlags.SizingFixedFit
                | ImGuiTableFlags.NoSavedSettings
            )) {
                float totalWidth = ImGui.GetContentRegionAvail().X;

                ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, 0.3f * totalWidth);
                ImGui.TableSetupColumn("Type", ImGuiTableColumnFlags.WidthFixed, 0.2f * totalWidth);
                ImGui.TableSetupColumn("Value", ImGuiTableColumnFlags.WidthStretch);
                ImGui.TableHeadersRow();
                ImGui.PushItemWidth(-1);

                fields ??= AttributeUtils.GetAttributes(obj.GetType()).GetFields();

                FieldRenderer.RenderFields(this, obj, fields);

                PopStyles();

                ImGui.PopItemWidth();
                ImGui.EndTable();
            }
        }

        /// <summary>
        /// Pop all accumulated styles
        /// </summary>
        public void PopStyles(int additional = 0)
        {
            _popStylesOnNextRow += additional;

            if (_popStylesOnNextRow > 0)
            {
                ImGui.PopStyleColor(_popStylesOnNextRow);
                _popStylesOnNextRow = 0;
            }
        }
    }
}