using NST;
using SkiaSharp;
using BCnEncoder.Decoder;
using BCnEncoder.Encoder;
using BCnEncoder.ImageSharp;
using BCnEncoder.Shared;
using System.Runtime.InteropServices;

namespace Alchemy
{
    /// <summary>
    /// Simple texture data container
    /// </summary>
    public class TextureData
    {
        public byte[] pixels;
        public int width;
        public int height;
    }

    /// <summary>
    /// Extensions for igImage2 objects
    /// </summary>
    public static class igImage2Extensions
    {
        /// <summary>
        /// Check if the image has texture data
        /// </summary>
        public static bool HasPixels(this igImage2 image) => image._data.IsActive() && image._data.Count > 0;

        /// <summary>
        /// Uncompress the image and return the pixel data as a RGBA byte array
        /// </summary>
        public static byte[] GetPixels(this igImage2 image, bool decode = true, int level = 0, int index = 0)
        {
            if (!image.HasPixels())
                throw new Exception($"{image} has no texture data!");

            string format = image._format?.Reference?.objectName ??
                throw new Exception($"_format property is not set for {image}!");

            CompressionFormat compressionFormat = StringToCompressionFormat(format);

            (int dataOffset, int dataSize) = ComputeOffsetAndSize(image, level, index, format, compressionFormat);

            dataSize = Math.Min(dataSize, image._data.Count - dataOffset);
            
            byte[] data = new byte[dataSize];

            for (int i = 0; i < dataSize; i++)
            {
                data[i] = image._data[dataOffset + i];
            }
            
            int width = image._width >> level;
            int height = image._height >> level;

            if (format.Contains("tile_ps4"))
            {
                try
                {
                    data = TextureHelper.UnswizzlePS4Texture(data, width, height, format);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            if (!decode)
            {
                return data;
            }

            byte[] outPixels = new byte[width * height * 4];

            new BcDecoder()
                .DecodeRawToImageRgba32(data, width, height, compressionFormat)
                .CopyPixelDataTo(outPixels);
            
            return outPixels;
        }

        /// <summary>
        /// Set new pixel data for the image
        /// </summary>
        /// <param name="format">igMetaImage containing the format of the pixel data</param>
        public static void SetPixels(this igImage2 image, byte[] pixels, int width, int height, igMetaImage? format)
        {
            string formatStr = format?.Reference?.objectName ?? "r8g8b8a8_dx11";

            CompressionFormat compression = StringToCompressionFormat(formatStr);

            image.SetPixels(pixels, width, height, compression);
        }
        
        /// <summary>
        /// Set new pixel data for the image
        /// </summary>
        /// <param name="compression">Compression format of the pixel data</param>
        public static void SetPixels(this igImage2 image, byte[] pixels, int width, int height, CompressionFormat compression = CompressionFormat.Bc1)
        {
            string format = CompressionFormatToString(compression);
            
            image._width = (u16)width;
            image._height = (u16)height;
            image._levelCount = 1; // (u16)(int.Log2(int.Min(width, height)) - 1); // TODO: Fix LOD not working if set to > 1

            if (image._format == null) image._format = new igMetaImage();
            image._format.Reference = new NamedReference("metaimages", format, true);

            BcEncoder encoder = new BcEncoder();
            encoder.OutputOptions.GenerateMipMaps = false;
            encoder.OutputOptions.Quality = CompressionQuality.BestQuality;
            encoder.OutputOptions.Format = compression;

            byte[][] encoded = encoder.EncodeToRawBytes(pixels, width, height, PixelFormat.Rgba32);

            image._data.Set(encoded[0].ToList());
        }

        public static SKBitmap CreateBitmapLOD(this igImage2 image, int maxSize)
        {
            int logW = System.Numerics.BitOperations.Log2(image._width);
            int logH = System.Numerics.BitOperations.Log2(image._height);
            int logMax = System.Numerics.BitOperations.Log2((uint)maxSize);
            int level = Math.Max(0, Math.Min(image._levelCount - 1, Math.Max(logW, logH) - logMax));

            int width = image._width >> level;
            int height = image._height >> level;

            byte[] rgbaData = image.GetPixels(level: level);

            var info = new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
            var bitmap = new SKBitmap(info);

            Marshal.Copy(rgbaData, 0, bitmap.GetPixels(), rgbaData.Length);

            return bitmap;
        }

        public static byte[] ConvertFromCtrToNst(this igImage2 image, string format)
        {
            bool decode = format == "b8g8r8a8_tile_ps4";

            float bytesPerPixel = StringToCompressionFormat(format) switch
            {
                CompressionFormat.Bc1 => 0.5f,
                CompressionFormat.Bc3 or CompressionFormat.Bc5 => 1,
                _ => 4,
            };

            int width = image._width;
            int height = image._height;
            int totalSize = 0;
            
            for (int i = 0; i < image._levelCount; i++, width /= 2, height /= 2)
            {
                totalSize += (int)(Math.Max(16, width * height) * bytesPerPixel);
            }
            totalSize *= image._imageCount;

            byte[] converted = new byte[totalSize];
            int offset = 0;

            for (int index = 0; index < image._imageCount; index++)
            {
                for (int level = 0; level < image._levelCount; level++)
                {
                    byte[] data = image.GetPixels(decode, level, index);
                    Buffer.BlockCopy(data, 0, converted, offset, data.Length);
                    offset += data.Length;
                }
            }

            return converted;
        }

        private static (int, int) ComputeOffsetAndSize(this igImage2 image, int level, int index, string format, CompressionFormat compressionFormat)
        {
            float bytesPerPixel = compressionFormat switch
            {
                CompressionFormat.Bc1 => 0.5f,
                CompressionFormat.Bc2 or CompressionFormat.Bc3 or CompressionFormat.Bc5 => 1,
                _ => 4,
            };
            
            int width = image._width;
            int height = image._height;
            int offset = 0;
            int imageSize = 0;

            if (!format.Contains("tile_ps4"))
            {
                for (int i = 0; i < image._levelCount; i++, width /= 2, height /= 2)
                {
                    int levelSize = (int)(Math.Max(16, width * height) * bytesPerPixel);

                    if (i < level)
                    {
                        offset += levelSize;
                    }

                    imageSize += levelSize;
                }

                offset += imageSize * index;
            }
            else
            {
                int minSize = compressionFormat switch
                {
                    CompressionFormat.Bc1 or CompressionFormat.Bc2 or CompressionFormat.Bc3 or CompressionFormat.Bc5 => 32,
                    _ => 8,
                };

                for (int i = 0; i < level; i++, width /= 2, height /= 2)
                {
                    int w = Math.Max(width, minSize);
                    int h = Math.Max(height, minSize);

                    var levelSize = w * h * bytesPerPixel * image._imageCount;
                    
                    offset += MathUtils.GetNextPowerOfTwo((int)levelSize);
                }

                width = Math.Max(image._width >> level, minSize);
                height = Math.Max(image._height >> level, minSize);

                imageSize = (int)(width * height * bytesPerPixel);
                offset += imageSize * index;
            }

            return (offset, imageSize);
        }

        /// <summary>
        /// Converts an igMetaImage string to a CompressionFormat
        /// </summary>
        private static CompressionFormat StringToCompressionFormat(string format)
        {
            switch (format)
            {
                case "r8g8b8a8_dx11":
                    return CompressionFormat.Rgba;
                case "b8g8r8a8_tile_ps4":
                    return CompressionFormat.Bgra;
                case "dxt1_dx11":
                case "dxt1_tile_ps4":
                    return CompressionFormat.Bc1;
                case "dxt3_dx11":
                case "dxt3_tile_ps4":
                    return CompressionFormat.Bc2;
                case "dxt5_dx11":
                case "dxt5_tile_ps4":
                    return CompressionFormat.Bc3;
                case "bc5_dx11":
                case "bc5_tile_ps4":
                    return CompressionFormat.Bc5;
                default:
                    throw new Exception($"Unknown compression format: {format}");
            }
        }

        /// <summary>
        /// Converts a CompressionFormat to an igMetaImage string
        /// </summary>
        private static string CompressionFormatToString(CompressionFormat format)
        {
            switch (format)
            {
                case CompressionFormat.Rgba:
                    return "r8g8b8a8_dx11";
                case CompressionFormat.Bc1:
                    return "dxt1_dx11";
                case CompressionFormat.Bc2:
                    return "dxt3_dx11";
                case CompressionFormat.Bc3:
                    return "dxt5_dx11";
                case CompressionFormat.Bc5:
                    return "bc5_dx11";
                default:
                    throw new Exception($"Unknown compression format: {format}");
            }
        }
    }
}