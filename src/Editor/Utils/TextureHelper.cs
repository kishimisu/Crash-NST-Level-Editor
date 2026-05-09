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
        public static int CreateOpenGLTexture(GL gl, int width, int height, byte[] pixels, bool flipY = false, bool linear = true)
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
                gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)(linear ? TextureMinFilter.Linear : TextureMinFilter.Nearest));
                gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)(linear ? TextureMagFilter.Linear : TextureMagFilter.Nearest));

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

        public static byte[] UnswizzlePS4Texture(byte[] data, int imageWidth, int imageHeight, string format)
        {
            var blockData = new Dictionary<string, (int, int, int)>()
            {
                { "b8g8r8a8_tile_ps4", (1, 1, 4) },
                { "dxt1_tile_ps4", (4, 4, 8) },
                { "dxt3_tile_ps4", (4, 4, 16) },
                { "dxt5_tile_ps4", (4, 4, 16) },
                { "bc5_tile_ps4", (4, 4, 16) },
            };

            var deswizzleDataList = new List<(int, int)>() 
            { 
                (2,1), (2,0), (2,1), (2,0), (2,1), (2,0) 
            };

            (int blockWidth, int blockHeight, int bytesPerBlock) = blockData[format];

            int tileWidth = 8 * blockWidth;
            int tileHeight = 8 * blockHeight;
            
            int tilePerWidth = imageWidth / tileWidth;
            int expectedDataSize = imageWidth * imageHeight / (blockWidth * blockHeight) * bytesPerBlock;
            int paddedWidth = -1;
            
            // Resize data if dimensions are too low
            if (imageWidth < tileWidth || imageHeight < tileHeight)
            {
                int ratio = Math.Max(tileWidth / imageWidth, tileHeight / imageHeight);
                int newWidth = imageWidth * ratio;
                int newHeight = imageHeight * ratio;
                
                tilePerWidth = newWidth / tileWidth;
                expectedDataSize = newWidth * newHeight / (blockWidth * blockHeight) * bytesPerBlock;
                paddedWidth = newWidth;

                if (data.Length < expectedDataSize)
                {
                    byte[] resized = new byte[expectedDataSize];
                    System.Buffer.BlockCopy(data, 0, resized, 0, data.Length);
                    data = resized;
                }
            }

            int readPerTileCount = 64;
            int tileDataSize = 64 * bytesPerBlock;
            int tileCount = expectedDataSize / tileDataSize;

            List<byte[,]> tileList = [];
            List<byte[,]> tileData = [];
            int dataReadIdx = 0;

            // Unswizzle
            for (int i = 0; i < tileCount; i++)
            {
                tileData.Clear();

                for (int j = 0; j < readPerTileCount; j++)
                {
                    byte[,] chunk = new byte[1, bytesPerBlock];
                    for (int x = 0; x < bytesPerBlock; x++)
                    {
                        chunk[0, x] = data[dataReadIdx + x];
                    }
                    dataReadIdx += bytesPerBlock;
                    tileData.Add(chunk);
                }

                foreach (var (sectionNumber, axis) in deswizzleDataList)
                {
                    tileData = ConcatArrays(tileData, sectionNumber, axis);
                }

                tileList.Add(tileData[0]);
            }

            tileList = ConcatArrays(tileList, tilePerWidth, 1);
            tileList = ConcatArrays(tileList, tileList.Count, 0);

            byte[] unswizzled = new byte[expectedDataSize];

            System.Buffer.BlockCopy(tileList[0], 0, unswizzled, 0, expectedDataSize);

            if (paddedWidth == -1)
            {
                return unswizzled;
            }

            int blocksX = Math.Max(1, imageWidth / blockWidth);
            int blocksY = Math.Max(1, imageHeight / blockHeight);
            int paddedBlocksX = Math.Max(1, paddedWidth / blockWidth);

            int srcRowSize = paddedBlocksX * bytesPerBlock;
            int dstRowSize = blocksX * bytesPerBlock;

            // Resize back to original dimensions
            byte[] trimmed = new byte[blocksX * blocksY * bytesPerBlock];

            for (int y = 0; y < blocksY; y++)
            {
                int srcOffset = y * srcRowSize;
                int dstOffset = y * dstRowSize;
                System.Buffer.BlockCopy(unswizzled, srcOffset, trimmed, dstOffset, dstRowSize);
            }

            return trimmed;
        }

        private static List<byte[,]> ConcatArrays(List<byte[,]> arrayList, int sectionNumber, int axis)
        {
            var newArrayList = new List<byte[,]>(arrayList.Count);

            for (int i = 0; i < arrayList.Count; i += sectionNumber)
            {
                var chunk = arrayList.GetRange(i, sectionNumber);
                newArrayList.Add(ConcatChunk(chunk, axis));
            }

            return newArrayList;
        }

        private static byte[,] ConcatChunk(List<byte[,]> arrays, int axis)
        {
            if (axis == 0)
            {
                int cols = arrays[0].GetLength(1);

                int totalRows = 0;
                foreach (var a in arrays)
                    totalRows += a.GetLength(0);

                var result = new byte[totalRows, cols];

                int rowOffset = 0;

                foreach (var a in arrays)
                {
                    int rows = a.GetLength(0);

                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++)
                            result[rowOffset + r, c] = a[r, c];

                    rowOffset += rows;
                }

                return result;
            }
            else
            {
                int rows = arrays[0].GetLength(0);

                int totalCols = 0;
                foreach (var a in arrays)
                    totalCols += a.GetLength(1);

                var result = new byte[rows, totalCols];

                int colOffset = 0;

                foreach (var a in arrays)
                {
                    int cols = a.GetLength(1);

                    for (int r = 0; r < rows; r++)
                        for (int c = 0; c < cols; c++)
                            result[r, colOffset + c] = a[r, c];

                    colOffset += cols;
                }

                return result;
            }
        }
    }
}