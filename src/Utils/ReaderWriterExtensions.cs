using System.Runtime.InteropServices;
using System.Text;

namespace Alchemy
{
    public static class BinaryReaderExtensions
    {
        public static void Seek(this BinaryReader reader, long offset, SeekOrigin origin = SeekOrigin.Begin)
        {
            reader.BaseStream.Seek(offset, origin);
        }

        public static string ReadNullTerminatedString(this BinaryReader reader)
        {
            var bytes = new List<byte>();
            byte b;
            
            while ((b = reader.ReadByte()) != 0)
            {
                if (reader.BaseStream.Position >= reader.BaseStream.Length)
                    throw new Exception($"End of file reached while reading string.");

                bytes.Add(b);
            }
            
            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        public static T ReadStruct<T>(this BinaryReader reader) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] buffer = reader.ReadBytes(size);

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(buffer, 0, ptr, size);
                return Marshal.PtrToStructure<T>(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static T[] ReadArray<T>(this BinaryReader reader, int count) where T : struct
        {
            T[] result = new T[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = reader.ReadStruct<T>();
            }

            return result;
        }

        public static List<T> ReadList<T>(this BinaryReader reader, int count) where T : struct
        {
            return reader.ReadArray<T>(count).ToList();
        }
    }

    public static class BinaryWriterExtensions
    {
        public static int GetPosition(this BinaryWriter writer) => (int)writer.BaseStream.Position;

        public static void Align(this BinaryWriter writer, int alignment) 
        {
            writer.BaseStream.Position = (writer.BaseStream.Position + alignment - 1) & ~(alignment - 1);
        }

        public static void WriteStruct<T>(this BinaryWriter writer, T data) where T : struct
        {
            int size = Marshal.SizeOf<T>();
            byte[] buffer = new byte[size];

            IntPtr ptr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(data, ptr, false);
                Marshal.Copy(ptr, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            writer.Write(buffer);
        }

        public static void WriteNullTerminatedString(this BinaryWriter writer, string value)
        {
            writer.Write(Encoding.UTF8.GetBytes(value));
            writer.Write((byte)0);
        }

        public static void WriteChars(this BinaryWriter writer, string value)
        {
            writer.Write(Encoding.UTF8.GetBytes(value));
        }
    }

    public static class MemoryStreamExtensions
    {
        public static int GetPosition(this MemoryStream stream) => (int)stream.Position;

        public static void Align(this MemoryStream stream, int alignment) 
        {
            stream.Position = (stream.Position + alignment - 1) & ~(alignment - 1);
        }
    }
}