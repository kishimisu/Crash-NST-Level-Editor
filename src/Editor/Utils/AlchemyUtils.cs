using Alchemy;

namespace NST
{
    /// <summary>
    /// Utilities for finding files and objects in the game archives
    /// </summary>
    public static class AlchemyUtils
    {
        /// <summary>
        /// Find a file in the game archives
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <param name="currentArchive">The current archive, if any (searched first to improve performance)</param>
        /// <param name="searchType">How the fileName should be matched against other file names</param>
        /// <returns>The archive file matching the fileName</returns>
        /// <exception cref="FileNotFoundException">Thrown if the file could not be found in any archive</exception>
        public static IgArchiveFile? FindFileInArchives(string fileName, out IgArchive? outArchive, IgArchive? currentArchive = null, FileSearchType searchType = FileSearchType.Name)
        {
            outArchive = null;

            // Try to find the file in the current archive
            IgArchiveFile? file = currentArchive?.FindFile(fileName, searchType);

            if (file != null && currentArchive != null)
            {
                outArchive = currentArchive;
                return file;
            }

            // Find the file in its original archive
            string? archivePath = NamespaceUtils.GetInfos(NamespaceUtils.ComputeHash(fileName))?.pak;

            if (archivePath == null)
            {
                Console.WriteLine($"Failed to find archive for {fileName}.");
                return null;
            }

            Console.WriteLine($"Searching for {fileName} in archive {archivePath}...");

            IgArchive archive = IgArchive.Open(Path.Join(LocalStorage.GamePath, "archives", archivePath));

            file = archive.FindFile(fileName, searchType);
            outArchive = archive;

            if (file == null)
            {
                Console.WriteLine($"Failed to find file {fileName} in any archive.");
            }

            return file;
        }

        /// <summary>
        /// Find an igObject in the currently open files or in the game archives
        /// </summary>
        /// <param name="reference">The object reference</param>
        /// <returns>The igObject corresponding to the reference</returns>
        /// <exception cref="FileNotFoundException">Thrown if the object could not be found in any archive</exception>
        public static igObject? FindObjectInArchives(NamedReference reference, IgArchive? archive, LevelExplorer? explorer = null, IgzFile? igz = null)
        {
            // Hashed namespace
            if (reference.namespaceName.All(char.IsDigit))
            {
                IgArchiveFile? file = archive?.FindFile(reference.namespaceName, FileSearchType.NamespaceHash);
                if (file != null)
                {
                    reference = reference.Clone();
                    reference.namespaceName = file.GetName(false);
                }
            }

            // Try to find the object in the current igz
            igObject? obj = igz?.FindObject(reference);

            if (obj != null) return obj;

            // Try to find the object in the current open files
            IgArchiveFile? parentFile = null;
            obj = explorer?.FileManager.FindObjectInOpenFiles(reference, out parentFile);

            if (obj != null && (archive == null || parentFile?.GameVersion == archive.GameVersion)) return obj;
            
            // Try to find the object in the current archive
            obj = archive?.FindObject(reference);

            if (obj != null || (archive != null && archive.GameVersion == GameVersion.CTR)) return obj;

            // Find the object in its original archive
            string? archivePath = NamespaceUtils.GetInfos(reference)?.pak;

            if (archivePath == null)
            {
                Console.WriteLine($"Failed to find archive for {reference}.");
                return null;
            }

            Console.WriteLine($"Searching for {reference} in archive {archivePath}...");

            IgArchive originalArchive = IgArchive.Open(Path.Join(LocalStorage.GamePath, "archives", archivePath));

            obj = originalArchive.FindObject(reference);

            if (obj == null)
            {
                Console.WriteLine($"Failed to find object {reference} in any archive.");
            }

            return obj;
        }
    }
}