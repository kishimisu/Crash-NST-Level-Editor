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
        public byte[] Save(string? newNamespace = null, bool includeDependencies = false)
        {
            if (newNamespace != null)
            {
                string currentNamespace = Path.GetFileNameWithoutExtension(_path);
                ReplaceHandlesNamespace(currentNamespace, newNamespace);
            }

            return IgzWriter.BuildIGZ(Objects, includeDependencies ? Dependencies : []);
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

        public T? FindObject<T>(string objectName) where T : igObject
        {
            objectName = objectName.ToLowerInvariant();

            return Objects.Find(o => o.ObjectName?.ToLowerInvariant() == objectName) as T;
        }

        /// <summary>
        /// Clone an object from one archive to another
        /// </summary>
        /// <param name="dependencies">All dependencies of the object in the source archive</param>
        public static T Clone<T>(T sourceObject, IgArchive sourceArchive, IgArchive destArchive, IgzFile sourceIgz, IgzFile destIgz, out List<IgArchiveFile> dependencies, Dictionary<igObject, igObject>? clones = null) where T : igObject
        {
            igObject clone = destIgz.AddClone(sourceObject, sourceIgz, clones);

            HashSet<string> objectStrings = sourceIgz.GetObjectDependencies(sourceObject);

            dependencies = IgArchiveExtensions.FindDependencies(sourceArchive, destArchive, objectStrings);

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

            // obj = source.FindObject<T>(obj.ObjectName) ?? obj;

            T clone = source.CreateClone(obj, this, clones, mode);

            return clone;
        }

        /// <summary>
        /// Clone an object and its children recursively and add all new objects to another file
        /// </summary>
        private T CreateClone<T>(T obj, IgzFile dest, Dictionary<igObject, igObject> clones, CloneMode mode = CloneMode.Deep) where T : igObject
        {
            List<igObject> prevKeys = clones.Keys.ToList();

            // Clone child objects
            T clone = (T)obj.Clone(this, dest, mode, clones);

            Dictionary<igObject, igObject> newClones = clones.Where(kvp => !prevKeys.Contains(kvp.Key)).ToDictionary();

            string srcNamespace = GetName(false).ToLower();
            string dstNamespace = dest.GetName(false);

            // Add new objects and update handle namespaces
            foreach ((igObject src, igObject dst) in newClones.ToList())
            {
                if (dest.Objects.Contains(dst))
                {
                    newClones.Remove(src);
                    continue;
                }

                if (dst.ObjectName != null)
                {
                    string newName = dest.FindSuitableName(dst.ObjectName);
                    // Console.WriteLine("Updating name: " + dst.ObjectName + " => " + newName);
                    dst.ObjectName = newName;
                }

                if (dest != this && !mode.HasFlag(CloneMode.SkipEntities))
                {
                    // Update handles
                    foreach (var handle in dst.GetHandles())
                    {
                        if (handle.namespaceName.ToLower() != srcNamespace) continue;

                        // Console.WriteLine($"Updating handle namespace: {handle} => {GetName(false).ToLower()}");
                        handle.namespaceName = dstNamespace;
                    }
                }

                dest.Objects.Add(dst);
            }

            // Clone child handles
            foreach ((igObject src, igObject dst) in newClones)
            {
                List<NamedReference> srcHandles = src.GetHandles();
                List<NamedReference> dstHandles = dst.GetHandles();

                foreach ((NamedReference srcHandle, NamedReference dstHandle) in srcHandles.Zip(dstHandles))
                {
                    if (srcHandle.namespaceName.ToLower() != srcNamespace) continue;

                    igObject? srcObject = FindObject(srcHandle);

                    if (srcObject == null)
                    {
                        Console.WriteLine("Warning: Source handle not found in igz file: " + srcHandle);
                        continue;
                    }

                    if (!Objects.Contains(srcObject))
                    {
                        Console.WriteLine("Warning: Source object not found in igz file: " + srcObject);
                        continue;
                    }

                    if (!clones.ContainsKey(srcObject))
                    {
                        igObject handleClone = CreateClone(srcObject, dest, clones, mode);

                        dstHandle.objectName = handleClone.ObjectName!;
                    }
                    else
                    {
                        // Console.WriteLine("Updating handle object name: " + dstHandle.objectName + " => " + clones[srcObject].ObjectName!);
                        dstHandle.objectName = clones[srcObject].ObjectName!;
                    }
                }
            }

            return clone;
        }

        /// <summary>
        /// Find all strings referenced by an object and its children
        /// </summary>
        public HashSet<string> GetObjectDependencies(igObject obj)
        {
            List<string> deps = [];
            List<igObject> children = [ obj ];
            children.AddRange(obj.GetChildrenRecursive(this, ChildrenSearchParams.IncludeHandles));

            foreach (igObject child in children)
            {
                var strings = child.GetStrings();
                if (strings.Count == 0) continue;
                deps.AddRange(strings);
            }

            string namespaceName = GetName(false).ToLowerInvariant();

            HashSet<string> result = deps
                .Where(d => !string.IsNullOrEmpty(d))
                .Select(d => Path.GetFileNameWithoutExtension(d).ToLowerInvariant())
                .ToHashSet();

            result.Remove(namespaceName);

            return result;
        }

        /// <summary>
        /// Find all strings referenced by this file
        /// </summary>
        public HashSet<string> GetDependencies()
        {
            List<string> deps = Dependencies.Select(d => d.path).ToList();

            foreach (igObject obj in Objects)
            {
                deps.AddRange(obj.GetStrings());
            }

            return deps
                .Where(d => !string.IsNullOrEmpty(d))
                .Select(d => Path.GetFileNameWithoutExtension(d).ToLowerInvariant())
                .ToHashSet();
        }

        /// <summary>
        /// Remove an object from the file and from all its parents.
        /// Recursively remove all of its children too and return all removed objects.
        /// </summary>
        public HashSet<igObject> Remove(igObject toRemove, bool force = true, HashSet<igObject>? removed = null)
        {
            Dictionary<igObject, (List<igObject> parents, List<igObject> children)> references = [];
            
            igObject? objectList = Objects.Count > 0 ? (Objects[0] as igObjectList) : null;
            var objects = objectList == null ? Objects : Objects.Skip(1);

            HashSet<igObject> allChildren = toRemove.GetChildrenRecursive(this, ChildrenSearchParams.IncludeHandles).ToHashSet();
            allChildren.Add(toRemove);

            foreach (igObject parent in objects)
            {
                bool inHierarchy = allChildren.Contains(parent);

                foreach (igObject child in parent.GetChildren(this, ChildrenSearchParams.IncludeHandles))
                {
                    if (!references.ContainsKey(parent))
                    {
                        references[parent] = (new List<igObject>(), new List<igObject>());
                    }
                    references[parent].children.Add(child);

                    if (!references.ContainsKey(child))
                    {
                        references[child] = (new List<igObject>(), new List<igObject>());
                    }

                    if (inHierarchy) continue;

                    references[child].parents.Add(parent);
                }
            }

            removed ??= new HashSet<igObject>();

            return RemoveRecursive(toRemove, force, references, removed);
        }

        private HashSet<igObject> RemoveRecursive(igObject obj, bool force, Dictionary<igObject, (List<igObject> parents, List<igObject> children)> references, HashSet<igObject> removed)
        {
            (List<igObject>? parents, List<igObject>? children) = references.ContainsKey(obj) ? references[obj] : (null, null);

            if (parents == null || parents.Count == 0 || force)
            {
                removed.Add(obj);

                Objects.Remove(obj);

                if (parents == null || children == null) return removed;

                foreach (igObject parent in parents)
                {
                    parent.RemoveChild(obj);

                    references[parent].children.Remove(obj);
                }

                foreach (igObject child in children)
                {
                    if (removed.Contains(child)) continue;

                    references[child].parents.Remove(obj);

                    RemoveRecursive(child, false, references, removed);
                }
            }

            return removed;
        }

        private string FindSuitableName(string name)
        {
            while (Objects.Any(e => e.ObjectName == name))
            {
                name = IncrementTrailingNumber(name);
            } 

            return name;
        }

        private static string IncrementTrailingNumber(string input)
        {
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