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

        public static SKBitmap CreateScaledBitmap(this igImage2 image, int maxSize)
        {
            byte[] rgbaData = image.GetPixels();

            var info = new SKImageInfo(image._width, image._height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
            var bitmap = new SKBitmap(info);

            Marshal.Copy(rgbaData, 0, bitmap.GetPixels(), rgbaData.Length);

            int longest = Math.Max(image._width, image._height);
            if (longest <= maxSize) return bitmap; // No resize needed

            float scale = (float)maxSize / longest;
            int width = (int)(image._width * scale);
            int height = (int)(image._height * scale);

            var resizedInfo = new SKImageInfo(width, height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
            var resizedBitmap = new SKBitmap(resizedInfo);

            bitmap.ScalePixels(resizedBitmap, SKFilterQuality.High);
            bitmap.Dispose();

            return resizedBitmap;
        }

        /// <summary>
        /// Uncompress the image and return the pixel data as a RGBA byte array
        /// </summary>
        public static byte[] GetPixels(this igImage2 image, bool decode = true)
        {
            if (!image.HasPixels())
                throw new Exception($"{image} has no texture data!");

            string format = image._format?.Reference?.objectName 
                            ?? throw new Exception($"_format property is not set for {image}!");

            if (format == "r8g8b8a8_dx11")
            {
                return image._data.ToArray();
            }

            CompressionFormat compressionFormat = StringToCompressionFormat(format);

            byte[] data = image._data.ToArray();

            try
            {
                if (format.Contains("tile_ps4"))
                {
                    data = TextureHelper.UnswizzlePS4Texture(data, image._width, image._height, format);
                }

                if (format == "b8g8r8a8_tile_ps4")
                {
                    return data;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (!decode)
            {
                return data;
            }

            byte[] outPixels = new byte[image._width * image._height * 4];

            new BcDecoder()
                .DecodeRawToImageRgba32(data, image._width, image._height, compressionFormat)
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