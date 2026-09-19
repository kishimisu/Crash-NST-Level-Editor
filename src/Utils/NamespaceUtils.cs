using System.Text;
using System.Reflection;

namespace Alchemy
{
    /// <summary>
    /// Link between a namespace and the archive that contains it
    /// </summary>
    public class NamespaceInfos(string name, string? archive = null)
    {
        public string Name { get; set; } = name; // The name of the namespace
        public string? Archive { get; set; } = archive; // The name of the first archive that contains the namespace
        public Dictionary<string, string> Paths { get; set; } = []; // The list of file paths and corresponding parent archive for this namespace

        public void AddPath(string ext, string archive)
        {
            if (Archive == null || ext == ".igz")
            {
                Archive = $"{archive}.pak";
            }

            Paths.Add(ext, archive);
        }
    }

    /// <summary>
    /// Utilities for working with namespaces and hashes
    /// </summary>
    public static class NamespaceUtils
    {
        private static Dictionary<uint, NamespaceInfos>? _namespaceInfos;

        public static string GetExtension(string path) => Path.GetExtension(path);
        public static string? GetDirectoryName(string path) => Path.GetDirectoryName(path);

        /// <summary>
        /// Extracts the name of a file from its path, optionally including the extension
        /// </summary>
        public static string GetFileName(string path, bool includeExtension = true)
        {
            return includeExtension ? Path.GetFileName(path) : Path.GetFileNameWithoutExtension(path);
        }

        /// <summary>
        /// Compute the hash of a string using using the FNV-1a algorithm
        /// </summary>
        /// <param name="name">The string to hash</param>
        /// <param name="basis">(Optional) The initial value of the hash</param>
        /// <returns>The hashed version of the string</returns>
        public static uint ComputeHash(string name, uint basis = 0x811c9dc5)
        {
            name = name.ToLowerInvariant().Replace('\\', '/');

            var bytes = Encoding.UTF8.GetBytes(name);

            for (int i = 0; i < bytes.Length; i++)
            {
                basis = (basis ^ bytes[i]) * 0x1000193;
            }

            return basis;
        }

        /// <summary>
        /// Add a new entry to the namespace info cache
        /// </summary>
        public static void AddInfos(string name)
        {
            uint hash = ComputeHash(name);

            _namespaceInfos ??= InitializeNamespaceInfos();

            if (!_namespaceInfos.ContainsKey(hash))
            {
                _namespaceInfos[hash] = new NamespaceInfos(name, null);
            }
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
            _namespaceInfos ??= InitializeNamespaceInfos();

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
            return GetInfos(hash)?.Name ?? hash.ToString();
        }

        /// <summary>
        /// Initialize the namespace infos from the embedded metadata
        /// </summary>
        private static Dictionary<uint, NamespaceInfos> InitializeNamespaceInfos()
        {
            using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("NST.assets.namespace_infos.metadata")!;
            using MemoryStream input = DecompressNamespaceInfos(stream);
            using BinaryReader reader = new BinaryReader(input, Encoding.UTF8);

            int archiveCount = reader.ReadInt32();
            int nameCount = reader.ReadInt32();
            
            var namespaceInfos = new Dictionary<uint, NamespaceInfos>();

            for (int i = 0; i < archiveCount; i++)
            {
                string archiveName = reader.ReadString();
                int fileCount = reader.ReadInt32();

                for (int j = 0; j < fileCount; j++)
                {
                    string filePath = reader.ReadString();

                    string fileName = GetFileName(filePath, false); 
                    uint hash = ComputeHash(fileName);

                    if (!namespaceInfos.TryGetValue(hash, out var infos))
                    {
                        infos = new NamespaceInfos(fileName);
                        namespaceInfos[hash] = infos;
                    }

                    infos.AddPath(filePath, archiveName);
                }
            }

            for (int i = 0; i < nameCount; i++)
            {
                string name = reader.ReadString();
                namespaceInfos.Add(ComputeHash(name), new NamespaceInfos(name));
            }

            return namespaceInfos;
        }

        /// <summary>
        /// Decompress the namespace infos data
        /// </summary>
        private static MemoryStream DecompressNamespaceInfos(Stream input)
        {
            byte[] props = new byte[5];
            input.ReadExactly(props);

            byte[] lengthBytes = new byte[4];
            input.ReadExactly(lengthBytes);

            int uncompressedSize = BitConverter.ToInt32(lengthBytes);

            var stream = new MemoryStream();
            var decoder = new SevenZip.Compression.LZMA.Decoder();

            decoder.SetDecoderProperties(props);
            decoder.Code(input, stream, input.Length - input.Position, uncompressedSize, null);

            stream.Position = 0;

            return stream;
        }
    }
}