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
        public static IgArchiveFile FindFileInArchives(string fileName, IgArchive? currentArchive = null, FileSearchType searchType = FileSearchType.Name)
        {
            // Try to find the file in the current archive
            IgArchiveFile? file = currentArchive?.FindFile(fileName, searchType);

            if (file != null)
            {
                return file;
            }

            // Find the file in its original archive
            string archivePath = NamespaceUtils.GetInfos(NamespaceUtils.ComputeHash(fileName))?.pak
                                 ?? throw new Exception($"Failed to find archive for {fileName}.");

            string gamePath = LocalStorage.Get<string>("game_path", LocalStorage.DEFAULT_GAME_PATH);

            IgArchive archive = IgArchive.Open(Path.Join(gamePath, "archives", archivePath));

            Console.WriteLine($"Searching for {fileName} in archive {archivePath}...");

            file = archive.FindFile(fileName, searchType);

            if (file == null)
            {
                throw new FileNotFoundException($"Failed to find file {fileName} in any archive.");
            }

            return file;
        }

        /// <summary>
        /// Find an igObject in the game archives
        /// </summary>
        /// <param name="reference">The object reference</param>
        /// <param name="currentArchive">The current archive, if any (searched first to improve performance)</param>
        /// <returns>The igObject corresponding to the reference</returns>
        /// <exception cref="FileNotFoundException">Thrown if the object could not be found in any archive</exception>
        public static igObject FindObjectInArchives(NamedReference reference, IgArchive? currentArchive = null)
        {
            // Try to find the object in the current archive
            igObject? obj = currentArchive?.FindObject(reference);

            if (obj != null)
            {
                return obj;
            }

            // Find the object in its original archive
            string gamePath = LocalStorage.Get<string>("game_path", LocalStorage.DEFAULT_GAME_PATH);

            string archivePath = NamespaceUtils.GetInfos(NamespaceUtils.ComputeHash(reference.namespaceName))?.pak
                                 ?? throw new Exception($"Failed to find archive for {reference.namespaceName}.");

            IgArchive archive = IgArchive.Open(Path.Join(gamePath, "archives", archivePath));

            Console.WriteLine($"Searching for {reference} in archive {archivePath}...");

            obj = archive.FindObject(reference);

            if (obj != null)
            {
                return obj;
            }

            throw new FileNotFoundException($"Failed to find object {reference} in any archive.");
        }
    }
}