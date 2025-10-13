using System.Text.RegularExpressions;
using NST;

namespace Alchemy
{
    /// <summary>
    /// Class representing a .igz file.
    /// Contains utilities for parsing and saving IGZ files and manipulating their objects.
    /// </summary>
    public class IgzFile
    {
        public uint uid;
        private string _path;
        public List<igObject> Objects { get; set; } = [];
        public TDEP_Fixup Dependencies { get; set; } = [];

        public string GetName(bool includeExtension = true) => NamespaceUtils.GetFileName(_path, includeExtension);
        
        /// <summary>
        /// Creates a new IGZ file from a list of objects
        /// </summary>
        public IgzFile(string path, List<igObject>? objects = null)
        {
            _path = path;
            Objects = objects ?? [];
            uid = ImGuiUtils.Uuid();
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
            uid = ImGuiUtils.Uuid();
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
            return (T?)(object?)Objects.Find(o => o is T);
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

            return Objects.Find(o => o.ObjectName?.ToLowerInvariant() == objectName);
        }

        public T? FindObject<T>(NamedReference reference) where T : igObject
        {
            return FindObject(reference) as T;
        }

        public T? FindObject<T>(string objectName) where T : igObject
        {
            objectName = objectName.ToLowerInvariant();

            return Objects.Find(o => o.ObjectName?.ToLowerInvariant() == objectName) as T;
        }

        public T? FindObject<T>(uint nameHash) where T : igObject
        {
            return Objects.Find(o => {
                if (o is not T) return false;
                if (o.ObjectName == null) return false;
                return NamespaceUtils.ComputeHash(o.ObjectName!) == nameHash;
            }) as T;
        }

        private static string IncrementTrailingNumber(string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Match digits at the end of the string
            var match = Regex.Match(input, @"(\d+)$");
            if (!match.Success)
            {
                // No trailing number found, just append 1
                return input + "1";
            }

            string numberStr = match.Value;
            int numberLength = numberStr.Length;

            int number = int.Parse(numberStr);
            number++;

            string newNumberStr = number.ToString().PadLeft(numberLength, '0');

            // If the number grew in length (e.g. 0999 -> 1000), don't pad
            if (newNumberStr.Length > numberLength)
            {
                newNumberStr = number.ToString();
            }

            return input.Substring(0, match.Index) + newNumberStr;
        }

        private string FindSuitableName(string name, IEnumerable<igObject>? additionalObjects = null)
        {
            var objects = Objects.Concat(additionalObjects ?? []);

            while (objects.Any(e => e.ObjectName == name))
            {
                name = IncrementTrailingNumber(name);
            } 

            return name;
        }

        /// <summary>
        /// Clone an object and all of its dependencies to another archive
        /// </summary>
        public static T Clone<T>(T sourceObject, IgArchive sourceArchive, IgArchive destArchive, IgzFile sourceIgz, IgzFile destIgz, Dictionary<igObject, igObject>? clones = null) where T : igObject
        {
            igObject clone = destIgz.AddClone(sourceObject, sourceIgz, clones);

            List<string> dependencies = sourceIgz.GetDependencies(sourceObject);

            AddDependencies(sourceArchive, destArchive, dependencies);

            foreach (var tdep in sourceIgz.Dependencies)
            {
                foreach (var dep in dependencies)
                {
                    if (dep == Path.GetFileNameWithoutExtension(tdep.path).ToLowerInvariant() && !destIgz.Dependencies.Contains(tdep))
                    {
                        destIgz.Dependencies.Add(tdep);
                        break;
                    }
                }
            }

            return (T)clone;
        }

        /// <summary>
        /// Clone an object and add it to this file
        /// </summary>
        /// <param name="obj">The object to clone</param>
        /// <param name="source">The source igz file</param>
        /// <param name="clones">The list of cloned objects</param>
        /// <returns>The cloned object</returns>
        public T AddClone<T>(T obj, IgzFile? source = null, Dictionary<igObject, igObject>? clones = null, CloneMode mode = CloneMode.Deep) where T : igObject
        {
            if (obj.ObjectName == null) throw new Exception("Not implemented");
            
            source ??= this;
            clones ??= new Dictionary<igObject, igObject>();

            obj = source.FindObject<T>(obj.ObjectName) ?? obj;

            List<igObject> prevKeys = clones.Keys.ToList();

            // Clone object recursively
            T clone = source.CreateClone(obj, this, clones, mode);

            Dictionary<igObject, igObject> newClones = clones.Where(kvp => !prevKeys.Contains(kvp.Key)).ToDictionary();

            foreach ((igObject src, igObject dst) in newClones)
            {
                if (Objects.Contains(dst))
                {
                    continue;
                }

                if (source == this)
                {
                    Objects.Add(dst);
                }
                else
                {
                    // Update handles
                    foreach (var handle in dst.GetHandles())
                    {
                        if (handle.namespaceName.ToLower() == source.GetName(false).ToLower())
                        {
                            handle.namespaceName = GetName(false);
                        }
                    }

                    Objects.Add(dst);
                }
            }

            return clone;
        }

        private T CreateClone<T>(T obj, IgzFile dest, Dictionary<igObject, igObject> clones, CloneMode mode = CloneMode.Deep) where T : igObject
        {
            List<igObject> prevKeys = clones.Keys.ToList();

            T clone = (T)obj.Clone(this, dest, mode, clones);

            Dictionary<igObject, igObject> newClones = clones.Where(kvp => !prevKeys.Contains(kvp.Key)).ToDictionary();

            foreach (igObject dst in newClones.Values)
            {
                if (dst.ObjectName != null)
                {
                    string newName = dest.FindSuitableName(dst.ObjectName, clones.Values);
                    dst.ObjectName = newName;
                }
            }

            foreach ((igObject src, igObject dst) in newClones)
            {
                List<NamedReference> srcHandles = src.GetHandles();
                List<NamedReference> dstHandles = dst.GetHandles();

                foreach ((NamedReference srcHandle, NamedReference dstHandle) in srcHandles.Zip(dstHandles))
                {
                    if (srcHandle.namespaceName.ToLower() != GetName(false).ToLower()) continue;

                    igObject? srcObject = FindObject(srcHandle);

                    if (srcObject == null)
                    {
                        continue;
                    }

                    if (!clones.ContainsKey(srcObject))
                    {
                        igObject handleClone = CreateClone(srcObject, dest, clones, mode);

                        dstHandle.objectName = handleClone.ObjectName!;
                    }
                    else
                    {
                        dstHandle.objectName = clones[srcObject].ObjectName!;
                    }
                }
            }

            return clone;
        }

        public static void AddDependencies(IgArchive source, IgArchive destination, List<string> dependencies, HashSet<string>? added = null)
        {
            added ??= new HashSet<string>();

            foreach (IgArchiveFile file in source.GetFiles())
            {
                foreach (string dep in dependencies)
                {
                    if (file.GetName(false).ToLowerInvariant() == dep
                        && !added.Contains(file.GetPath())
                        && !destination.GetFiles().Any(f => f.GetPath() == file.GetPath()))
                    {
                        destination.AddFile(file);
                        added.Add(file.GetPath());

                        if (file.IsIGZ())
                            AddDependencies(source, destination, file.ToIgzFile().GetDependencies(), added);
                    }
                }
            }
        }

        public List<string> GetDependencies(igObject obj)
        {
            List<string> deps = [];
            List<igObject> children = [ obj ];
            children.AddRange(obj.GetChildrenRecursive(this, ChildrenSearchParams.IncludeHandles));

            foreach (igObject child in children)
            {
                deps.AddRange(child.GetStrings());

                foreach (NamedReference handle in child.GetHandles())
                {
                    deps.Add(handle.namespaceName);
                }
            }

            string namespaceName = GetName(false).ToLowerInvariant();

            return deps
                .Where(d => !string.IsNullOrEmpty(d))
                .Select(d => Path.GetFileNameWithoutExtension(d).ToLowerInvariant())
                .Distinct()
                .Where(d => d != namespaceName)
                .ToList();
        }

        public List<string> GetDependencies()
        {
            List<string> deps = Dependencies.Select(d => d.path).ToList();

            foreach (igObject obj in Objects)
            {
                foreach (NamedReference handle in obj.GetHandles())
                {
                    deps.Add(handle.namespaceName);
                }
            }

            return deps.Where(d => !string.IsNullOrEmpty(d)).Select(d => Path.GetFileNameWithoutExtension(d).ToLowerInvariant()).Distinct().ToList();
        }

        public HashSet<igObject> Remove(igObject obj, bool force = true, HashSet<igObject>? removed = null)
        {
            igObject? objectList = (Objects[0] as igObjectList);

            List<igObject> parents = Objects.Where(e => e != objectList && e.GetChildren(this, ChildrenSearchParams.IncludeHandles).Contains(obj)).ToList();

            removed ??= new HashSet<igObject>();

            if (parents.Count == 0 || force)
            {
                Console.WriteLine("Removing " + obj + (force ? " (force)" : ""));

                removed.Add(obj);

                Objects.Remove(obj);

                foreach (igObject parent in parents)
                {
                    parent.RemoveChild(obj);
                }

                foreach (igObject child in obj.GetChildren(this, ChildrenSearchParams.IncludeHandles))
                {
                    if (removed.Contains(child)) continue;

                    Remove(child, false, removed);
                }
            }

            return removed;
        }

        // public List<igObject> FindParents(igObject obj, ChildrenSearchParams searchParams = ChildrenSearchParams.Default)
        // {
        //     return Objects.Where(o => o.GetChildren(searchParams).Any(c => c == obj)).ToList();
        // }
        // public List<igObject> FindParentsRecursive(igObject obj, ChildrenSearchParams searchParams = ChildrenSearchParams.Default, HashSet<igObject> visited = null)
        // {
        //     visited ??= new HashSet<igObject>();

        //     List<igObject> parents = FindParents(obj, searchParams)
        //         .Where(p => visited.Add(p))
        //         .ToList();

        //     return parents.Concat(parents.SelectMany(p => FindParentsRecursive(p, searchParams, visited))).ToList();
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