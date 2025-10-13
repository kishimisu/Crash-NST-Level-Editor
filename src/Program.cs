using Alchemy;

class Program
{
    // STAThread is necessary for Windows.Forms.OpenFileDialog/SaveFileDialog
    [STAThread]
    static void Main(string[] args)
    {
        new NST.SilkWindow().Run(); // Application entry point
    }

    /// <summary>
    /// Igz file editing example
    /// </summary>
    void Example()
    {
        const string archiveDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Crash Bandicoot - N Sane Trilogy\\archives\\";

        // Open archive
        IgArchive archive = IgArchive.Open(archiveDir + "L101_NSanityBeach.pak");

        // Find archive file
        IgArchiveFile file = archive.FindFile("L101_NSanityBeach_Crates.igz", FileSearchType.NameWithExtension)!;

        // Convert to igz file
        IgzFile igz = file.ToIgzFile();

        // List objects of type CEntity
        List<CEntity> entities = igz.FindObjects<CEntity>();

        // Find crate entities
        foreach (CEntity entity in entities)
        {
            string? objectName = entity.ObjectName;

            if (objectName == null || !objectName.Contains("Crate_") || objectName.EndsWith("_gen")) {
                continue;
            }
            Console.WriteLine($"Found crate: {objectName}");

            // Move each crate up
            entity._parentSpacePosition._z += 100.0f;
        }

        // Rebuild IGZ
        byte[] newIgzData = igz.Save();

        // Update file data
        file.SetData(newIgzData);

        // Save updated archive to disk
        archive.Save();
    }
}