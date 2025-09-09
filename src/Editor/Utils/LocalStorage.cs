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

        private static string storageFilePath = ""; // Path to the main local storage file

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

            storageFilePath = Path.Combine(appFolder, storageFileName);

            if (Get<string>("game_path") == null)
            {
                if (Directory.Exists(DEFAULT_GAME_PATH))
                {
                    Set("game_path", DEFAULT_GAME_PATH);
                }
                else
                {
                    throw new Exception("Could not find game path"); // TODO
                }
            }
            
            RecentFiles = Get<List<string>>("recent_files") ?? [];
        }

        /// <summary>
        /// Add a file to the recent files list
        /// </summary>
        public static void AddRecentFile(string path)
        {
            if (RecentFiles.Contains(path))
            {
                RecentFiles.Remove(path);
            }

            RecentFiles.Insert(0, path);
            RecentFiles = RecentFiles.Take(MAX_RECENT_FILES).ToList();

            Set("recent_files", RecentFiles);
        }

        /// <summary>
        /// Remove a file from the recent files list
        /// </summary>
        public static void RemoveRecentFile(string path)
        {
            if (!RecentFiles.Contains(path))
            {
                return;
            }

            RecentFiles.Remove(path);

            Set("recent_files", RecentFiles);
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

        /// <summary>
        /// Set a value in the local storage
        /// </summary>
        public static void Set(string key, object value)
        {
            var data = GetAll();
            data[key] = JsonSerializer.Serialize(value);
            File.WriteAllText(storageFilePath, JsonSerializer.Serialize(data));
        }

        /// <summary>
        /// Read a value from the local storage, falling back to a default value if it doesn't exist
        /// </summary>
        public static T Get<T>(string key, T defaultValue)
        {
            return Get<T>(key) ?? defaultValue;
        }

        /// <summary>
        /// Read a value from the local storage
        /// </summary>
        public static T? Get<T>(string key)
        {
            var data = GetAll();
            
            if (!data.ContainsKey(key)) return default;

            if (typeof(T) == typeof(string)) return (T)(object)data[key];

            return JsonSerializer.Deserialize<T>(data[key]);
        }

        /// <summary>
        /// Read all values from the local storage
        /// </summary>
        private static Dictionary<string, string> GetAll()
        {
            if (!File.Exists(storageFilePath)) return [];

            string json = File.ReadAllText(storageFilePath);
            return JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? [];
        }
    }
}