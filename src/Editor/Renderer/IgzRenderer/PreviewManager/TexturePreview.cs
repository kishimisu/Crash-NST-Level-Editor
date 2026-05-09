using Alchemy;
using ImGuiNET;

namespace NST
{
    /// <summary>
    /// Handles rendering of texture previews
    /// </summary>
    public class TexturePreview
    {
        private igImage2 _image; // Image object
        private IgzRenderer _renderer; // Parent IGZ renderer

        private int _textureId = -1; // OpenGL texture
        private int _imageWidth, _imageHeight;

        private int _selectedLevel = 0; // Current LOD
        private int _selectedIndex = 0; // Current image index
        private int _selectedChannel = -1; // RGBA selection

        public TexturePreview(IgzRenderer renderer, igImage2 image)
        {
            _renderer = renderer;
            _image = image;

            LoadImage(image.GetPixels());
        }

        private void LoadImage(byte[] imageData)
        {
            int width = _image._width >> _selectedLevel;
            int height = _image._height >> _selectedLevel;

            _textureId = TextureHelper.CreateOpenGLTexture(SilkWindow.instance._gl, width, height, imageData, flipY: true, linear: false);
            _imageWidth = width;
            _imageHeight = height;
        }

        /// <summary>
        /// Render the texture preview and options
        /// </summary>
        public void Render()
        {
            if (_textureId == -1) return;

            TextureHelper.RenderImageFittingParentWidth(_textureId, _imageWidth, _imageHeight);

            if (ImGui.Button("Extract Image"))
            {
                OnClickExtractImage();
            }

            ImGui.SameLine();

            if (ImGui.Button("Replace Image"))
            {
                OnClickReplaceImage();
            }

            float w = ImGui.GetContentRegionAvail().X * 0.15f;

            if (_image._levelCount > 1)
            {
                ImGui.SameLine();
                ImGuiUtils.Prefix("LOD");
                ImGui.SetNextItemWidth(w);
                if (ImGui.SliderInt("##imageLevel", ref _selectedLevel, 0, _image._levelCount - 1))
                {
                    LoadImage(_image.GetPixels(true, _selectedLevel, _selectedIndex));
                }
            }

            if (_image._imageCount > 1)
            {
                ImGui.SameLine();
                ImGuiUtils.Prefix("Index");
                ImGui.SetNextItemWidth(w);
                if (ImGui.SliderInt("##imageIndex", ref _selectedIndex, 0, _image._imageCount - 1))
                {
                    LoadImage(_image.GetPixels(true, _selectedLevel, _selectedIndex));
                }
            }

            ImGui.SameLine();
            float buttonSize = (ImGui.CalcTextSize("R").X + ImGui.GetStyle().FramePadding.X * 2) * 4 + ImGui.GetStyle().ItemSpacing.X * 3;
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + ImGui.GetContentRegionAvail().X - buttonSize);

            RenderChannelButton(0, "R", 0xff0000ff);
            RenderChannelButton(1, "G", 0xff00ff00);
            RenderChannelButton(2, "B", 0xffff0000);
            RenderChannelButton(3, "A", 0xffffffff);
        }

        /// <summary>
        /// Render a channel button (R, G, B, A)
        /// </summary>
        private void RenderChannelButton(int index, string label, uint color)
        {
            bool selected = _selectedChannel == index;

            if (index > 0) ImGui.SameLine();

            if (selected) ImGui.PushStyleColor(ImGuiCol.Button, color);
            if (selected && index == 3) ImGui.PushStyleColor(ImGuiCol.Text, 0xff0000ff);

            if (ImGui.Button(label))
            {
                OnClickChannel(index);
            }

            if (selected) ImGui.PopStyleColor();
            if (selected && index == 3) ImGui.PopStyleColor();
        }

        /// <summary>
        /// Update the texture to display only the selected channel
        /// </summary>
        private void OnClickChannel(int index)
        {
            byte[] pixels = _image.GetPixels(true, _selectedLevel, _selectedIndex);

            _selectedChannel = (_selectedChannel == index) ? -1 : index;

            switch (_selectedChannel)
            {
                case 0: // Red
                    for (int i = 0; i < pixels.Length; i += 4)
                    {
                        pixels[i + 1] = pixels[i + 2] = 0;
                        pixels[i + 3] = 255;
                    }
                break;
                case 1: // Green
                    for (int i = 0; i < pixels.Length; i += 4)
                    {
                        pixels[i] = pixels[i + 2] = 0;
                        pixels[i + 3] = 255;
                    }
                break;
                case 2: // Blue
                    for (int i = 0; i < pixels.Length; i += 4)
                    {
                        pixels[i] = pixels[i + 1] = 0;
                        pixels[i + 3] = 255;
                    }
                break;
                case 3: // Alpha
                    for (int i = 0; i < pixels.Length; i += 4)
                    {
                        pixels[i] = pixels[i + 1] = pixels[i + 2] = pixels[i + 3];
                        pixels[i + 3] = 255;
                    }
                break;
            }

            LoadImage(pixels);
        }

        /// <summary>
        /// Extract the image from the igImage2 object to a file
        /// </summary>
        private void OnClickExtractImage()
        {
            igImage2? image = _renderer.Igz.FindObject<igImage2>();
            if (image == null)
            {
                ModalRenderer.ShowMessageModal("Information", "No igImage2 object found");
                return;
            }

            string fileName = (image._name != null)
                ? Path.GetFileNameWithoutExtension(image._name) + ".png"
                : "image.png";

            string? filePath = FileExplorer.SaveFile(FileExplorer.EXT_IMAGES, fileName);

            if (filePath == null) return;

            byte[] pixels = image.GetPixels(true, _selectedLevel, _selectedIndex);
            TextureHelper.SaveImageToFile(pixels, image._width, image._height, filePath);
        }

        /// <summary>
        /// Replace the igImage2 content with a new image
        /// </summary>
        private void OnClickReplaceImage()
        {
            igImage2? image = _renderer.Igz.FindObject<igImage2>();
            if (image == null)
            {
                ModalRenderer.ShowMessageModal("Information", "No igImage2 object found");
                return;
            }

            List<string> files = FileExplorer.OpenFiles(FileExplorer.EXT_IMAGES, false, "");
            if (files.Count != 1) return;

            // Load image
            byte[] pixels = TextureHelper.LoadImageFromFile(files[0], out int width, out int height);

            // Update igImage2 data
            image.SetPixels(pixels, width, height, image._format);
            
            // Save changes
            _renderer.ArchiveFile.SetData(_renderer.Igz.Save());
            _renderer.SetUpdated(image);

            // Create OpenGL texture for UI rendering
            LoadImage(pixels);
        }
    }
}