using System.Text.Json;

namespace NST
{
    /// <summary>
    /// Utilities for storing settings and data locally
    /// </summary>
    public static class LocalStorage
    {
        public static readonly string DEFAULT_GAME_PATH = @"C:\Program Files (x86)\Steam\steamapps\common\Crash Bandicoot - N Sane Trilogy";
        private const string STORAGE_FOLDER_NAME = "NST_Modding_Tool"; // Name of the local storage folder
        private const int MAX_RECENT_FILES = 15; // Maximum number of recent files to store

        public static List<string> RecentFiles { get; private set; } = []; // List of recently opened files
        public static List<string> RecentLevels { get; private set; } = []; // List of recently opened levels
        
        public static string? GamePath { get; private set; } = null; // Path to the game folder
        public static string ArchivePath => Path.Join(GamePath ?? DEFAULT_GAME_PATH, "archives"); // Path to the archives folder
        public static string UpdateFilePath => Path.Join(ArchivePath, "update.pak"); // Path to the update file
        public static string AutoBackupPath => GetStoragePath("backups");

        private static string _storageFilePath = ""; // Path to the main local storage file
        public static string AutoBackupSize { get; private set; } = "";

        /// <summary>
        /// Initialize the local storage.
        /// Checks for the game executable and creates the local storage folder if it doesn't exist
        /// </summary>
        public static void Initialize(string storageFileName = "localstorage.json")
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(folderPath, STORAGE_FOLDER_NAME);

            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }

            _storageFilePath = Path.Combine(appFolder, storageFileName);

            GamePath = Get<string>("game_path");

            // Check if the path to the game folder is valid
            if (GamePath == null)
            {
                if (Directory.Exists(DEFAULT_GAME_PATH))
                {
                    SetGamePath(DEFAULT_GAME_PATH);
                }
            }
            else if (!Directory.Exists(GamePath))
            {
                GamePath = null;
                Remove("game_path");
            }

            // Compute the size of the auto-backup folder
            if (Directory.Exists(AutoBackupPath))
            {
                DirectoryInfo dir = new DirectoryInfo(AutoBackupPath);
                FileInfo[] files = dir.GetFiles();
                long size = 0;

                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }

                const double MB = 1024d * 1024;
                const double GB = 1024d * 1024 * 1024;

                AutoBackupSize = size >= GB ? $"{size / GB:F2} GB" : $"{size / MB:F2} MB";
            }
            
            RecentFiles = Get<List<string>>("recent_files") ?? [];
            RecentLevels = Get<List<string>>("recent_levels") ?? [];

            AudioPlayerInstance.AutoPlayAudio = Get("auto_play_audio", false);
        }

        /// <summary>
        /// Check if the file is locked by another process before saving
        /// </summary>
        public static bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            
            FileStream? stream = null;

            try
            {
                stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                return false;
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }
        }

        /// <summary>
        /// Add a file to the recent files list
        /// </summary>
        public static void AddRecentFile(string path, bool isLevel = false)
        {
            List<string> list = isLevel ? RecentLevels : RecentFiles;

            if (list.Contains(path))
            {
                list.Remove(path);
            }

            list.Insert(0, path);
            list = list.Take(MAX_RECENT_FILES).ToList();

            Set(isLevel ? "recent_levels" : "recent_files", list);
        }

        /// <summary>
        /// Remove a file from the recent files list
        /// </summary>
        public static void RemoveRecentFile(string path, bool? isLevel = null)
        {
            if (isLevel != true && RecentFiles.Contains(path))
            {
                RecentFiles.Remove(path);
                Set("recent_files", RecentFiles);
            }

            if (isLevel != false && RecentLevels.Contains(path))
            {
                RecentLevels.Remove(path);
                Set("recent_levels", RecentLevels);
            }
        }

        /// <summary>
        /// Open the file explorer to set a new path to the game folder
        /// </summary>
        public static void SetNewGamePath()
        {
            List<string> paths = FileExplorer.OpenFiles(LocalStorage.DEFAULT_GAME_PATH, FileExplorer.EXT_EXECUTABLE, false);

            if (paths.Count > 0)
            {
                string? folder = Path.GetDirectoryName(paths[0]);

                if (folder != null)
                {
                    SetGamePath(folder);
                }
                else
                {
                    ModalRenderer.ShowMessageModal("An error occurred", "Could not set the game path.");
                }
            }
        }

        /// <summary>
        /// Set the new path to the game folder
        /// </summary>
        private static void SetGamePath(string path)
        {
            GamePath = path;
            Set("game_path", path);

            Console.WriteLine($"Game folder set to {path}");
        }

        /// <summary>
        /// Get the path to a file in the local storage
        /// </summary>
        public static string GetStoragePath(string fileName)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string appFolder = Path.Combine(folderPath, STORAGE_FOLDER_NAME);

            return Path.Combine(appFolder, fileName);
        }

        public static void DeleteAutoBackupFolder()
        {
            Directory.Delete(AutoBackupPath, true);
            AutoBackupSize = "";
        }

        /// <summary>
        /// Set a value in the local storage
        /// </summary>
        public static void Set(string key, object value)
        {
            var data = GetAll();
            data[key] = value is string str ? str : JsonSerializer.Serialize(value);
            File.WriteAllText(_storageFilePath, JsonSerializer.Serialize(data));
        }

        /// <summary>
        /// Read a value from the local storage, falling back to a default value if it doesn't exist
        /// </summary>
        public static T? Get<T>(string key, T? defaultValue = default)
        {
            var data = GetAll();
            
            if (!data.ContainsKey(key)) return defaultValue;

            if (typeof(T) == typeof(string)) return (T)(object)data[key];

            return JsonSerializer.Deserialize<T>(data[key]);
        }

        /// <summary>
        /// Remove a value from the local storage
        /// </summary>
        public static void Remove(string key)
        {
            var data = GetAll();
            data.Remove(key);
            File.WriteAllText(_storageFilePath, JsonSerializer.Serialize(data));
        }

        /// <summary>
        /// Read all values from the local storage
        /// </summary>
        private static Dictionary<string, string> GetAll()
        {
            if (!File.Exists(_storageFilePath)) return [];

            string json = File.ReadAllText(_storageFilePath);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? [];
        }
    }
}