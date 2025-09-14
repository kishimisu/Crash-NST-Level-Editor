namespace Alchemy
{
    /// <summary>
    /// Class representing a .igz file.
    /// Contains utilities for parsing and saving IGZ files and manipulating their objects.
    /// </summary>
    public class IgzFile
    {
        private string _path;
        public List<igObject> Objects { get; set; } = [];
        public TDEP_Fixup Dependencies { get; set; } = [];

        public string GetName(bool includeExtension = true) => NamespaceUtils.GetFileName(_path, includeExtension);
        
        /// <summary>
        /// Creates a new IGZ file from a list of objects
        /// </summary>
        public IgzFile(string path, List<igObject> objects)
        {
            _path = path;
            Objects = objects;
        }

        /// <summary>
        /// Instanciate all objects from an IGZ file raw data
        /// </summary>
        /// <param name="path">The file's path in the archive</param>
        /// <param name="data">The file's raw data. It must be uncompressed</param>
        public IgzFile(string path, byte[] data)
        {
            IgzReader reader = new IgzReader(new MemoryStream(data));

            _path = path;
            Objects = reader.GetObjects();
            Dependencies = reader.GetDependencies();
        }

        /// <summary>
        /// Construct a new .igz file from the current object list and return its raw data
        /// </summary>
        /// <param name="newNamespace">(Optional) The new namespace for the file</param>
        /// <returns>The .igz file content as raw bytes</returns>
        public byte[] Save(string? newNamespace = null)
        {
            if (newNamespace != null)
            {
                string currentNamespace = Path.GetFileNameWithoutExtension(_path);
                ReplaceHandlesNamespace(currentNamespace, newNamespace);
            }

            return IgzWriter.BuildIGZ(Objects, Dependencies);
        }

        /// <summary>
        /// Replace all matching handles namespaces in the file with a new one
        /// </summary>
        /// <param name="currentNamespace">The namespace to replace</param>
        /// <param name="newNamespace">The new namespace</param>
        private void ReplaceHandlesNamespace(string currentNamespace, string newNamespace)
        {
            foreach (igObject obj in Objects)
            {
                foreach (NamedReference handle in obj.GetHandles())
                {
                    if (handle.namespaceName == currentNamespace)
                    {
                        handle.SetNamespace(newNamespace);
                    }
                }
            }
        }

        /// <summary>
        /// Find the first object of type T
        /// </summary>
        /// <returns>The object if found, null otherwise</returns>
        public T? FindObject<T>() where T : igObject
        {
            return (T?)(object?)Objects.FirstOrDefault(o => o is T);
        }

        /// <summary>
        /// Find all objects of type T
        /// </summary>
        public List<T> FindObjects<T>()
        {
            return Objects.Where(o => o is T).Cast<T>().ToList();
        }

        /// <summary>
        /// Find an object using its reference
        /// </summary>
        /// <param name="reference">The object reference</param>
        /// <returns>The object if found, null otherwise</returns>
        public igObject? FindObject(NamedReference reference)
        {
            if (reference.namespaceName.ToLower() != GetName(false).ToLower())
            {
                // The handle doesn't point to the current file
                return null;
            }

            string objectName = reference.objectName.ToLowerInvariant();

            return Objects.FirstOrDefault(o => o.GetObjectName()?.ToLowerInvariant() == objectName);
        }

        public T? FindObject<T>(NamedReference reference) where T : igObject
        {
            return FindObject(reference) as T;
        }

        public T? FindObject<T>(string objectName) where T : igObject
        {
            objectName = objectName.ToLowerInvariant();

            return Objects.FirstOrDefault(o => o.GetObjectName()?.ToLowerInvariant() == objectName) as T;
        }

        public T? FindObject<T>(uint nameHash) where T : igObject
        {
            return Objects.FirstOrDefault(o => {
                if (o is not T) return false;
                if (o.GetObjectName() == null) return false;
                return NamespaceUtils.ComputeHash(o.GetObjectName()!) == nameHash;
            }) as T;
        }

        public static T Clone<T>(T obj, string? suffix = null, bool deep = false) where T : igObject
        {
            return (T)obj.Clone(suffix, deep);
        }

        // public static T Clone<T>(T obj, string? newName = null, bool deep = false) where T : igObject
        // {
        //     T clone = (T)obj.Clone(deep);

        //     if (newName != null) {
        //         clone.SetObjectName(newName);
        //     }

        //     return clone;
        // }

        // public static IgzFile CreateTexture(string imagePath, CompressionFormat compressionFormat = CompressionFormat.Bc1)
        // {
        //     byte[] pixels = TextureHelper.LoadImageFromFile(imagePath, out int width, out int height);

        //     igImage2 image = new igImage2("image_name");

        //     image.SetPixels(pixels, width, height, compressionFormat);

        //     return new IgzFile([ image ]);
        // }
    }
}