using Alchemy;

namespace Havok
{
    [ObjectAttr(128)]
    public class hkbProjectStringData : hkReferencedObject
    {
        public override uint Hash => 0xca08c2ba;

        [FieldAttr(16)] public hkMemory<string> _animationFilenames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(32)] public hkMemory<string> _behaviorFilenames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(48)] public hkMemory<string> _characterFilenames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(64)] public hkMemory<string> _eventNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(80)] public string _animationPath; // TYPE_STRINGPTR
        [FieldAttr(88)] public string _behaviorPath; // TYPE_STRINGPTR
        [FieldAttr(96)] public string _characterPath; // TYPE_STRINGPTR
        [FieldAttr(104)] public string _scriptsPath; // TYPE_STRINGPTR
        [FieldAttr(112)] public string _fullPathToSource; // TYPE_STRINGPTR
        [FieldAttr(120)] public string _rootPath; // TYPE_STRINGPTR, flags: SERIALIZE_IGNORED
    }
}