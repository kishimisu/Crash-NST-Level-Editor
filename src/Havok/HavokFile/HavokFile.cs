using Alchemy;

namespace Havok
{
    public class HavokFile
    {
        public hkRootLevelContainer RootLevelContainer;

        private string _path;
        private HavokHeader _header;
        private Dictionary<int, hkObject> _rootObjects = [];

        public List<hkObject> GetAllObjects() => GetObjects();
        public List<hkObject> GetRootObjects() => GetObjects(true);
        public hkObject GetObject(int offset) => _rootObjects[offset];

        public HavokFile(string path, byte[] data) : this(data) => _path = path;

        public HavokFile(byte[] data)
        {
            using MemoryStream stream = new MemoryStream(data.ToArray());
            using BinaryReader reader = new BinaryReader(stream);
            using BinaryWriter writer = new BinaryWriter(stream);

            // File header
            _header = new HavokHeader(reader);
           
            // Section headers
            long sectionOffset = reader.BaseStream.Position;
            List<HavokSection> sections = new List<HavokSection>(_header.sectionCount);

            for (int i = 0; i < _header.sectionCount; i++) 
            {
                reader.Seek(sectionOffset + i * HavokSection.Size);
                sections.Add(new HavokSection(reader));
            }

            // Apply fixups
            foreach (HavokSection section in sections)
            {
                section.Fixup(reader, writer, sections);
            }

            // Initialize root objects
            HavokSection dataSection = sections[_header.contentSectionIndex];
            foreach ((int offset, string className) in dataSection.virtualFixups)
            {
                hkObject obj = hkObject.CreateEmptyInstance(className);
                _rootObjects.Add(offset, obj);
            }

            // Parse all objects
            foreach ((int offset, hkObject obj) in _rootObjects)
            {
                reader.Seek(offset);
                obj.Parse(this, reader);
            }

            // Expose hkRootLevelContainer
            RootLevelContainer = (hkRootLevelContainer)_rootObjects.Values.First(x => x is hkRootLevelContainer);
        }

        public byte[] Save()
        {
            using MemoryStream stream = new MemoryStream();
            using BinaryWriter writer = new BinaryWriter(stream);

            // File header
            _header.Write(writer);

            // Sections
            HavokClassNameSection classNameSection = new HavokClassNameSection();
            HavokTypeSection typeSection = new HavokTypeSection();
            HavokDataSection dataSection = new HavokDataSection();

            int sectionOffset = writer.GetPosition();
            int dataOffset = sectionOffset + HavokSection.Size * _header.sectionCount;

            writer.Seek(dataOffset, SeekOrigin.Begin);

            // Section 1: Class names
            classNameSection.WriteClassNames(writer, GetRootObjects());

            // Section 2: Types
            typeSection.WriteTypes(writer);

            // Section 3: Objects (+ fixups)
            dataSection.WriteObjects(writer, RootLevelContainer);
            dataSection.WriteFixups(writer, classNameSection);

            // Section headers
            writer.Seek(sectionOffset, SeekOrigin.Begin);
            classNameSection.WriteHeader(writer);
            typeSection.WriteHeader(writer);
            dataSection.WriteHeader(writer);

            return stream.ToArray();
        }

        private List<hkObject> GetObjects(bool rootOnly = false)
        {
            Stack<hkObject> stack = new Stack<hkObject>([ RootLevelContainer ]);
            HashSet<hkObject> visited = [];
            List<hkObject> objects = [];

            while (stack.Count > 0)
            {
                hkObject obj = stack.Pop();

                if (visited.Contains(obj)) continue;

                List<hkObject> children = obj.GetChildren();
                
                for (int i = children.Count - 1; i >= 0; i--)
                {
                    stack.Push(children[i]);
                }

                visited.Add(obj);

                if (!rootOnly || obj is hkRootLevelContainer || obj is hkReferencedObject || obj is hkRefCountedProperties)
                {
                    objects.Add(obj);
                }
            }

            return objects;
        }
    }
}