namespace Alchemy
{
    // VSC object extracted from: common_GemDoor.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_GemDoorData : CVscComponentData
    {
        [FieldAttr(40)] public int _Int;
        [FieldAttr(48)] public igHandleMetaField _GemGameVariable = new();
        [FieldAttr(56)] public igVec3fMetaField _Vec_3F = new();
        [FieldAttr(68)] public float _Float;
        [FieldAttr(72)] public igHandleMetaField _Sound_0x48 = new();
        [FieldAttr(80)] public igHandleMetaField _Vfx_Effect_0x50 = new();
        [FieldAttr(88)] public igHandleMetaField _Sound_0x58 = new();
        [FieldAttr(96)] public igHandleMetaField _Vfx_Effect_0x60 = new();
    }
}
