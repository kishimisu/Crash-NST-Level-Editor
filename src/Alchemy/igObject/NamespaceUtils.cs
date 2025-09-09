using System.Text;
using System.Reflection;

namespace Alchemy
{
    /// <summary>
    /// Link between a namespace and the archive that contains it
    /// </summary>
    public class NamespaceInfos
    {
        public string name { get; set; } // The name of the namespace
        public string? pak { get; set; } // The name of the first archive that contains the namespace

        public NamespaceInfos(string name, string? pak) { this.name = name; this.pak = pak; }
    }

    /// <summary>
    /// Utilities for working with namespaces and hashes
    /// </summary>
    public static class NamespaceUtils
    {
        private static Dictionary<uint, NamespaceInfos>? _namespaceInfos;

        /// <summary>
        /// Compute the hash of a string using using the FNV-1a algorithm
        /// </summary>
        /// <param name="name">The string to hash</param>
        /// <param name="basis">(Optional) The initial value of the hash</param>
        /// <returns>The hashed version of the string</returns>
        public static uint ComputeHash(string name, uint basis = 0x811c9dc5)
        {
            name = name.ToLower().Replace('\\', '/');

            for (int i = 0; i < name.Length; i++)
            {
                basis = (basis ^ name[i]) * 0x1000193;
            }

            return basis;
        }
        
        /// <summary>
        /// Extracts the name of a file from its path, optionally including the extension
        /// </summary>
        public static string GetFileName(string path, bool includeExtension = true)
        {
            return includeExtension ? Path.GetFileName(path) : Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        /// Get the namespace infos associated with a name
        /// </summary>
        public static NamespaceInfos? GetInfos(string namespaceName)
        {
            uint hash = ComputeHash(namespaceName);
            return GetInfos(hash);
        }

        /// <summary>
        /// Get the namespace infos associated with a reference
        /// </summary>
        public static NamespaceInfos? GetInfos(NamedReference reference)
        {
            uint hash = ComputeHash(reference.namespaceName);
            return GetInfos(hash);
        }

        /// <summary>
        /// Get the namespace infos associated with a hash
        /// </summary>
        public static NamespaceInfos? GetInfos(uint hash)
        {
            if (_namespaceInfos == null)
            {
                _namespaceInfos = InitializeNamespaceInfos();
            }

            if (_namespaceInfos.TryGetValue(hash, out NamespaceInfos? namespaceInfos))
            {
                return namespaceInfos;
            }

            return null;
        }

        /// <summary>
        /// Find the name corresponding to a hashed string
        /// </summary>
        public static string FindNameForHash(uint hash)
        {
            return GetInfos(hash)?.name ?? hash.ToString();
        }

        /// <summary>
        /// Initialize the namespace infos from the embedded metadata
        /// </summary>
        private static Dictionary<uint, NamespaceInfos> InitializeNamespaceInfos()
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("NST.assets.namespace_infos.metadata")!;
            using BinaryReader reader = new BinaryReader(stream);

            byte[] data = reader.ReadBytes((int)stream.Length);

            string content = Encoding.UTF8.GetString(DecompressNamespaceInfos(data));
            
            List<string> lines = content.Split('\n').ToList();
            List<string> paks = [];
            
            Dictionary<uint, NamespaceInfos> namespaceInfos = [];

            int i = 0;
            for (; i < lines.Count; i++)
            {
                string line = lines[i];
                if (string.IsNullOrEmpty(line)) break;
                paks.Add(line);
            }
            for (i++; i < lines.Count; i++)
            {
                string line = lines[i];
                List<string> items = line.Split(' ').ToList();
                
                uint id = uint.Parse(items[0]);
                string name = items[1];
                int pakId = int.Parse(items[2]);
                string? pak = pakId == 0 ? null : (paks[pakId - 1] + ".pak");

                namespaceInfos.Add(id, new NamespaceInfos(name, pak));
            }

            return namespaceInfos;
        }

        /// <summary>
        /// Decompress the namespace infos data
        /// </summary>
        private static byte[] DecompressNamespaceInfos(byte[] data)
        {
            using MemoryStream inputStream = new MemoryStream(data);
            
            byte[] props = new byte[5];
            inputStream.Read(props, 0, 5);

            byte[] lengthBytes = new byte[4];
            inputStream.Read(lengthBytes, 0, 4);

            int uncompressedSize = BitConverter.ToInt32(lengthBytes, 0);

            using MemoryStream outputStream = new MemoryStream(uncompressedSize);
           
            var decoder = new SevenZip.Compression.LZMA.Decoder();
            decoder.SetDecoderProperties(props);
            decoder.Code(inputStream, outputStream, inputStream.Length - inputStream.Position, uncompressedSize, null);

            return outputStream.ToArray();
        }
    }
}