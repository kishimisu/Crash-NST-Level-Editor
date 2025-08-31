using Alchemy;

namespace Havok
{
    [ObjectAttr(24)]
    public class hkbAssetBundleStringData : hkObject
    {
        public override uint Hash => 0x46132bad;

        [FieldAttr(0)] public string _bundleName; // TYPE_STRINGPTR
        [FieldAttr(8)] public hkMemory<string> _assetNames; // TYPE_ARRAY, subtype: TYPE_STRINGPTR
    }
}