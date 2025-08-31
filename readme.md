### Crash NST Level Editor

Tihs repo currently contains the core API for a work-in-progress level editor for Crash NST (PC).

```csharp
// Open archive
IgArchive archive = IgArchive.Open(archiveDir + "L101_NSanityBeach.pak");

// Find archive file
IgArchiveFile file = archive.FindFile("L101_NSanityBeach_Crates.igz", FileSearchType.NameWithExtension)!;

// Convert to igz file
IgzFile igz = file.ToIgzFile();

// List objects of type CEntity
List<CEntity> entities = igz.FindObjects<CEntity>();

// Move all entities up
entities.ForEach(entity => entity._parentSpacePosition._z += 100.0f);

// Save igz file in archive
file.SetData(igz.Save());

// Save updated archive to disk
archive.Save();

```

## Archive explorer

***Coming very soon!***

## Level editor

***Coming very soon!***

## Project structure

```
src/
│
├── Alchemy/     # Alchemy-related classes
│ ├── IgArchive/ # .pak files
│ ├── IgzFile/   # .igz files
│ ├── igObject/  # Alchemy objects
│
├── Havok/       # Havok-related classes
│ ├── HavokFile/ # .hkx files
│ ├── hkObject/  # Havok objects
│
├── Utils/       # Common utilities
│
├── Program.cs - Demo
```