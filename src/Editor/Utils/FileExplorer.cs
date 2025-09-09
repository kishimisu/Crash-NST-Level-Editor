namespace NST
{
    /// <summary>
    /// Utility class for opening and saving files using Windows file explorer
    /// TODO: find a cross-platform alternative
    /// </summary>
    public static class FileExplorer
    {
        public static string EXT_ALL = "All files (*.*)|*.*";
        public static string EXT_ALCHEMY = "Alchemy files (*.pak,*.igz)|*.pak;*.igz;|" + EXT_ALL;
        public static string EXT_ARCHIVES = "PAK archives (*.pak)|*.pak|" + EXT_ALL;
        public static string EXT_IMAGES = "Image Files|*.png;*.apng;*.jpg;*.jpeg;*.jfif;*.gif;*.bm;*.bmp;*.dip;*.ppm;*.pbm;*.pgm;*.tga;*.vda;*.icb;*.vst;*.tiff;*.tif;*.webp;*.qoi";
        public static string EXT_AUDIO = "Audio Files (*.mp3,*.ogg,*.wav)|*.mp3;*.ogg;*.wav|" + EXT_ALL;

        public static List<string> OpenFiles(string initialDirectory, string extensions, bool multiSelect)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = initialDirectory,
                Filter = extensions,
                Multiselect = multiSelect
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (multiSelect)
                {
                    return openFileDialog.FileNames.ToList();
                }
                else
                {
                    return [openFileDialog.FileName];
                }
            }

            return [];
        }

        public static string? SaveFile(string initialDirectory, string extensions, string defaultName)
        {
            using SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = initialDirectory,
                FileName = SanitizeFileName(defaultName),
                Filter = extensions
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        private static string SanitizeFileName(string fileName)
        {
            string invalidChars = new string(Path.GetInvalidFileNameChars());

            for (int i = 0; i < fileName.Length; i++)
            {
                char currentChar = fileName[i];

                if (invalidChars.Contains(currentChar))
                {
                    fileName = fileName.Replace(currentChar, '_');
                }
            }

            return fileName;
        }
    }
}