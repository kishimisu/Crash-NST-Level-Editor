using System.Diagnostics;

namespace NST
{
    public static class CrashHandler
    {
        private static List<string> _warnings = [];

        public static void Log(string message)
        {
            Console.WriteLine(message);
            _warnings.Add(message);
        }

        public static UnhandledExceptionEventHandler CreateExceptionHandler()
        {
            return new UnhandledExceptionEventHandler(OnUnhandledException);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                ShowCrashStackTrace(ex);
            }
        }

        private static void ShowCrashStackTrace(Exception ex)
        {
            string time = DateTime.UtcNow.ToString();

            string stackTrace = $"""
            Application crashed
            Time: {time}
            {(_warnings.Count == 0 ? "" : "\n" + string.Join("\n\n", _warnings) + "\n")}
            {ex}
            """;
            
            string logDir = LocalStorage.GetStoragePath("logs");
            string filePath = Path.Join(logDir, "crash-log-latest.txt");

            Directory.CreateDirectory(logDir);
            File.WriteAllText(filePath, stackTrace);

            Process.Start(new ProcessStartInfo
            {
                FileName = logDir,
                UseShellExecute = true
            });
        }
    }
}