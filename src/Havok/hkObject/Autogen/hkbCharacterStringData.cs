using Alchemy;

namespace Havok
{
    [ObjectAttr(224)]
    public class hkbCharacterStringData : hkReferencedObject
    {
        public override uint Hash => 0xb9d8a52;

        [FieldAttr(16)] public hkMemory<hkbCharacterStringDataFileNameMeshNamePair> _skinNames; // TYPE_ARRAY, ctype: hkbCharacterStringDataFileNameMeshNamePair, subtype: TYPE_STRUCT
        [FieldAttr(32)] public hkMemory<hkbCharacterStringDataFileNameMeshNamePair> _boneAttachmentNames; // TYPE_ARRAY, ctype: hkbCharacterStringDataFileNameMeshNamePair, subtype: TYPE_STRUCT
        [FieldAttr(48)] public hkMemory<hkbAssetBundleStringData> _animationBundleNameData; // TYPE_ARRAY, ctype: hkbAssetBundleStringData, subtype: TYPE_STRUCT
        [FieldAttr(64)] public hkMemory<hkbAssetBundleStringData> _animationBundleFilenameData; // TYPE_ARRAY, ctype: hkbAssetBundleStringData, subtype: TYPE_STRUCT
        [FieldAttr(80)] public hkMemory<string> _characterPropertyNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(96)] public hkMemory<string> _retargetingSkeletonMapperFilenames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(112)] public hkMemory<string> _lodNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(128)] public hkMemory<string> _mirroredSyncPointSubstringsA; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(144)] public hkMemory<string> _mirroredSyncPointSubstringsB; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
        [FieldAttr(160)] public string _name; // TYPE_STRINGPTR
        [FieldAttr(168)] public string _rigName; // TYPE_STRINGPTR
        [FieldAttr(176)] public string _ragdollName; // TYPE_STRINGPTR
        [FieldAttr(184)] public string _behaviorFilename; // TYPE_STRINGPTR
        [FieldAttr(192)] public string _luaScriptOnCharacterActivated; // TYPE_STRINGPTR
        [FieldAttr(200)] public string _luaScriptOnCharacterDeactivated; // TYPE_STRINGPTR
        [FieldAttr(208)] public hkMemory<string> _luaFiles; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
    }
}