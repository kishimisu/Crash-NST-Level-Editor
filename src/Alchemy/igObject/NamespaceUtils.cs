namespace Alchemy
{
    public static class NamespaceUtils
    {
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
    }
}