using Alchemy;

namespace Havok
{
    public class HavokDataSection : HavokSection
    {
        public HavokDataSection() : base("__data__") { }

        private BinaryWriter _writer;

        private Stack<hkObject> _globalObjectQueue = [];
        private List<hkObject> _localObjectQueue = [];
        private Dictionary<hkObject, int> _writtenObjects = [];

        private List<(int offset, int destination)> _localFixups = [];
        private List<(int offset, hkObject destination)> _globalFixups = [];

        public bool AlignNextString { get; set; }

        public void AddObjectToQueue(hkObject obj) => _localObjectQueue.Add(obj);
        public void AddLocalFixup(int offset, int destination) => _localFixups.Add((offset, destination));
        public void AddGlobalFixup(int offset, hkObject destination) => _globalFixups.Add((offset, destination));

        public void WriteObjects(BinaryWriter writer, hkObject rootLevelContainer)
        {
            _writer = writer;
            
            _writtenObjects.Clear();
            _localFixups.Clear();
            _globalFixups.Clear();

            _dataOffset = writer.GetPosition();

            _globalObjectQueue = new Stack<hkObject>([ rootLevelContainer ]);

            AlignNextString = true;

            while (_globalObjectQueue.Count > 0)
            {
                hkObject obj = _globalObjectQueue.Pop();

                if (_writtenObjects.Keys.Contains(obj)) continue;

                WriteObject(obj);
            }

            writer.Seek(0, SeekOrigin.End);
            writer.Align(16);
        }

        private void WriteObject(hkObject obj)
        {
            int position = ReserveBytes(AttributeUtils.GetObjectSize(obj.GetType()));

            _writtenObjects.Add(obj, position);
            _writer.Seek(position, SeekOrigin.Begin);

            _localObjectQueue.Clear();

            obj.Write(this, _writer);

            for (int i = _localObjectQueue.Count - 1; i >= 0; i--) 
            {
                _globalObjectQueue.Push(_localObjectQueue[i]);
            }
        }

        public int ReserveBytes(int size, int alignment = 16)
        {
            int position = (int)_writer.BaseStream.Length;

            if (position % alignment != 0) {
                position += alignment - (position % alignment);
            }

            _writer.BaseStream.SetLength(position + size);

            return position;
        }

        public void WriteFixups(BinaryWriter writer, HavokClassNameSection classNameSection)
        {
            int localFixupOffset = WriteLocalFixups(writer);
            int globalFixupOffset = WriteGlobalFixups(writer);
            int virtualFixupOffset = WriteVirtualFixups(writer, classNameSection);

            int bufferSize = writer.GetPosition() - _dataOffset;

            UpdateHeader(localFixupOffset, globalFixupOffset, virtualFixupOffset, bufferSize);
        }

        private int WriteLocalFixups(BinaryWriter writer)
        {
            int position = writer.GetPosition();

            foreach ((int source, int destination) in _localFixups)
            {
                writer.Write(source - _dataOffset);
                writer.Write(destination - _dataOffset);
            }

            FillToAlign(writer, 0xFF, 16);

            return position - _dataOffset;
        }

        private int WriteGlobalFixups(BinaryWriter writer, int sectionID = 2)
        {
            int position = writer.GetPosition();

            foreach ((int source, hkObject obj) in _globalFixups)
            {
                int destination = _writtenObjects[obj];

                writer.Write(source - _dataOffset);
                writer.Write(sectionID);
                writer.Write(destination - _dataOffset);
            }

            FillToAlign(writer, 0xFF, 16);

            return position - _dataOffset;
        }

        private int WriteVirtualFixups(BinaryWriter writer, HavokClassNameSection classNameSection, int sectionID = 0)
        {
            List<hkObject> virtualFixups = _globalFixups
                .Select(x => x.destination)
                .Distinct()
                .Append(_writtenObjects.Keys.First())
                .OrderBy(x => _writtenObjects[x])
                .ToList();

            int position = writer.GetPosition();

            foreach (hkObject obj in virtualFixups)
            {
                int source = _writtenObjects[obj];
                int classNameOffset = classNameSection.GetClassOffset(obj);

                writer.Write(source - _dataOffset);
                writer.Write(sectionID);
                writer.Write(classNameOffset);
            }

            FillToAlign(writer, 0xFF, 16);

            return position - _dataOffset;
        }
    }
}