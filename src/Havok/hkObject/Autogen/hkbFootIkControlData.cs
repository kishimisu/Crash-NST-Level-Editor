using Alchemy;

namespace Havok
{
    [ObjectAttr(80)]
    public class hkbFootIkControlData : hkObject
    {
        public override uint Hash => 0x7f18a9a6;

        [FieldAttr(0)] public hkbFootIkGains _gains; // TYPE_STRUCT, ctype: hkbFootIkGains
        [FieldAttr(40)] public hkMemory<u32> _unk0; // TYPE_ARRAY, arrsize: NaN, flags: undefined, vdefault: undefined
        [FieldAttr(56)] public i32 _unk1; // TYPE_INT32, subtype: undefined, arrsize: NaN, flags: undefined, vdefault: undefined
        [FieldAttr(60)] public i32 _unk2; // TYPE_INT32, subtype: undefined, arrsize: NaN, flags: undefined, vdefault: undefined
        [FieldAttr(64)] public i32 _unk3; // TYPE_INT32, subtype: undefined, arrsize: NaN, flags: undefined, vdefault: undefined
        [FieldAttr(68)] public i32 _unk4; // TYPE_INT32, subtype: undefined, arrsize: NaN, flags: undefined, vdefault: undefined
        [FieldAttr(72)] public i32 _unk5; // TYPE_INT32, subtype: undefined, arrsize: NaN, flags: undefined, vdefault: undefined
        [FieldAttr(76)] public i32 _unk6; // TYPE_INT32, subtype: undefined, arrsize: NaN, flags: undefined, vdefault: undefined
    }
}