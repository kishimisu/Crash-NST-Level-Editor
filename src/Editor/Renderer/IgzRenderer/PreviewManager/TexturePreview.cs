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

        private int _selectedChannel = -1; // RGBA selection

        public TexturePreview(IgzRenderer renderer, igImage2 image)
        {
            _renderer = renderer;
            _image = image;

            LoadImage(image.GetPixels(), image._width, image._height);
        }

        private void LoadImage(byte[] imageData, int width, int height)
        {
            _textureId = TextureHelper.CreateOpenGLTexture(SilkWindow.instance._gl, width, height, imageData, flipY: true);
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
            byte[] pixels = _image.GetPixels();

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

            LoadImage(pixels, _image._width, _image._height);
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

            string? filePath = FileExplorer.SaveFile("", FileExplorer.EXT_IMAGES, fileName);

            if (filePath == null) return;

            TextureHelper.SaveImageToFile(image.GetPixels(), image._width, image._height, filePath);
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

            List<string> files = FileExplorer.OpenFiles("", FileExplorer.EXT_IMAGES, false);
            if (files.Count != 1) return;

            // Load image
            byte[] pixels = TextureHelper.LoadImageFromFile(files[0], out int width, out int height);

            // Update igImage2 data
            image.SetPixels(pixels, width, height, image._format);
            
            // Save changes
            _renderer.ArchiveFile.SetData(_renderer.Igz.Save());
            _renderer.SetUpdated(image);

            // Create OpenGL texture for UI rendering
            LoadImage(pixels, width, height);
        }
    }
}