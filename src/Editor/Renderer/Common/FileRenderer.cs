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

        public abstract ITreeView TreeView { get; } // Object tree

        /// <summary>
        /// Finds the tree node associated to the given object
        /// </summary>
        public abstract TreeNode FindNode(object obj);
        
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
        }

        /// <summary>
        /// Renders the IGZ file
        /// </summary>
        /// <param name="horizontalLayout">True for archive renderers, false for level editors</param>
        public void Render(bool horizontalLayout = true)
        {
            if (!IsOpenAsWindow)
            {
                RenderContent(horizontalLayout);
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
            RenderContent(horizontalLayout);
            ImGui.End();
        }

        /// <summary>
        /// Render the tree view and object view
        /// </summary>
        public void RenderContent(bool horizontalLayout)
        {
            // Start table
            if (horizontalLayout)
            {
                if (!ImGui.BeginTable("FileRendererTable" + GetHashCode(), 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.RowBg))
                {
                    return;
                }
                ImGui.TableNextColumn();
            }

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
            if (horizontalLayout)
            {
                // (IgArchiveRenderer) Pop out as window
                if (!IsOpenAsWindow && ImGui.SmallButton("Open in new window"))
                {
                    IsOpenAsWindow = true;
                }
            }
            else
            {
                // (Level Editor) Open in original archive
                if (ImGui.SmallButton("Open in archive"))
                {
                    App.FocusRenderer(this);
                }
            }

            // Render preview (texture, model, audio...)
            _previewManager?.RenderInTreeView();

            // Render tree view and object view
            if (horizontalLayout)
            {
                RenderTreeView();
                ImGui.TableNextColumn();
                RenderObjectView();

                if (_previewManager?.GetModelPreview() is ModelPreview mp && !ImGui.IsItemHovered())
                {
                    mp.SetRenderDrawCall(-1); // In a model file, reset the drawcall override when the mouse leaves
                }
                
                ImGui.EndTable();
            }
            else
            {
                ImGui.SetNextWindowSizeConstraints(Vector2.Zero, new Vector2(-1, ImGui.GetContentRegionAvail().Y * 0.6f));
                RenderObjectView();
                
                ImGui.Separator();
                RenderTreeView();
            }

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
        public void RenderObject(object? obj)
        {
            if (obj == null) return;

            if (ImGui.BeginTable("IgzObjectTable", 3, 
                  ImGuiTableFlags.Resizable 
                | ImGuiTableFlags.Reorderable 
                | ImGuiTableFlags.RowBg
                | ImGuiTableFlags.BordersInner
                | ImGuiTableFlags.Hideable
                | ImGuiTableFlags.NoPadOuterX
                // | ImGuiTableFlags.SizingStretchProp
                | ImGuiTableFlags.NoSavedSettings
            )) {
                float totalWidth = ImGui.GetContentRegionAvail().X;
                float[] ratios = { 0.4f, 0.2f, 0.4f };

                ImGui.TableSetupColumn("Name", ImGuiTableColumnFlags.WidthFixed, ratios[0] * totalWidth);
                ImGui.TableSetupColumn("Type", ImGuiTableColumnFlags.WidthFixed, ratios[1] * totalWidth);
                ImGui.TableSetupColumn("Value", ImGuiTableColumnFlags.WidthFixed, ratios[2] * totalWidth);
                ImGui.TableHeadersRow();
                ImGui.PushItemWidth(-1);

                FieldRenderer.RenderFields(this, obj);

                while (_popStylesOnNextRow > 0)
                {
                    _popStylesOnNextRow--;
                    ImGui.PopStyleColor();
                }

                ImGui.PopItemWidth();
                ImGui.EndTable();
            }
        }

        /// <summary>
        /// Pop all accumulated styles
        /// </summary>
        public void PopStyles()
        {
            if (_popStylesOnNextRow > 0)
            {
                for (int i = 0; i < _popStylesOnNextRow; i++)
                {
                    ImGui.PopStyleColor();
                }
                _popStylesOnNextRow = 0;
            }
        }
    }
}