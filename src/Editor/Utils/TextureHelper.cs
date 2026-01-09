using ImGuiNET;
using System.Numerics;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;
using Silk.NET.OpenGLES;

namespace NST
{
    /// <summary>
    /// Helper class for working with textures
    /// </summary>
    public static class TextureHelper
    {
        private static int _textureId = -1; // OpenGL texture id

        /// <summary>
        /// Load an image from the disk
        /// </summary>
        public static byte[] LoadImageFromFile(string filePath, out int width, out int height)
        {
                using Image<Rgba32> inputImage = Image.Load<Rgba32>(filePath);

                width = inputImage.Width;
                height = inputImage.Height;

                byte[] pixels = new byte[width * height * 4];

                inputImage.Mutate(x => x.Flip(FlipMode.Vertical));
                inputImage.CopyPixelDataTo(pixels);

                return pixels;
        }

        /// <summary>
        /// Save an image to the disk
        /// </summary>
        public static void SaveImageToFile(byte[] pixels, int width, int height, string filePath)
        {
            using var image = Image.LoadPixelData<Rgba32>(pixels, width, height);
            image.Mutate(x => x.Flip(FlipMode.Vertical));
            image.Save(filePath);
        }

        /// <summary>
        /// Render a texture and fit it to the parent window or container while preserving the aspect ratio
        /// </summary>
        /// <returns>The bounds of the image on the screen (x, y, w, h)</returns>
        public static Vector4 RenderImageFittingParentWidth(int textureId, int width, int height, float maxHeightRatio = 0.6f, Vector4? tint = null)
        {
            float aspectRatio = (float)width / (float)height;

            // Get available width and height of the parent window or container
            Vector2 contentRegion = ImGui.GetContentRegionAvail();

            float x = ImGui.GetCursorScreenPos().X;
            float y = ImGui.GetCursorScreenPos().Y;

            // Desired width is the available width of the parent
            float desiredWidth = contentRegion.X; // - ImGui.GetStyle().ItemSpacing.X;
            float desiredHeight = desiredWidth / aspectRatio;

            // Ensure height does not exceed parent height
            float maxHeight = contentRegion.Y * maxHeightRatio;
            if (desiredHeight > maxHeight)
            {
                desiredHeight = maxHeight;
                desiredWidth = desiredHeight * aspectRatio;
            }

            Vector2 imageSize = new Vector2(desiredWidth, desiredHeight);

            // Calculate the horizontal offset to center the image
            float horizontalOffset = (contentRegion.X - desiredWidth) / 2;

            // Apply horizontal offset
            ImGui.SetCursorPosX(ImGui.GetCursorPosX() + horizontalOffset);

            ImGui.Image(textureId, imageSize, Vector2.Zero, Vector2.One, tint ?? Vector4.One);

            return new Vector4(x + horizontalOffset, y, imageSize.X, imageSize.Y);
        }

        /// <summary>
        /// Create an OpenGL texture from a byte array of pixels
        /// </summary>
        public static int CreateOpenGLTexture(GL gl, int width, int height, byte[] pixels, bool flipY = false)
        {
            // Flip image vertically
            if (flipY)
            {
                using var image = Image.LoadPixelData<Rgba32>(pixels, width, height);
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                image.CopyPixelDataTo(pixels);
            }

            if (_textureId == -1)
            {
                // Generate OpenGL texture
                uint textureId = gl.GenTexture();
                gl.BindTexture(TextureTarget.Texture2D, textureId);

                // Set texture parameters
                gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
                gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
                gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
                gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

                GLEnum internalFormat = GLEnum.Rgba;
                GLEnum format = GLEnum.Rgba;
                GLEnum type = GLEnum.UnsignedByte;
                int mipMapLevel = 0;
                int border = 0;

                // Load texture data
                gl.TexImage2D<byte>(GLEnum.Texture2D, mipMapLevel, (int)internalFormat, (uint)width, (uint)height, border, format, type, pixels);

                _textureId = (int)textureId;
            }
            else
            {
                // Update existing texture
                gl.BindTexture(TextureTarget.Texture2D, (uint)_textureId);
                gl.TexImage2D<byte>(GLEnum.Texture2D, 0, (int)GLEnum.Rgba, (uint)width, (uint)height, 0, GLEnum.Rgba, GLEnum.UnsignedByte, pixels);
            }

            gl.GenerateMipmap(GLEnum.Texture2D);
            gl.BindTexture(TextureTarget.Texture2D, 0);

            return _textureId;
        }
    }
}