namespace Alchemy
{
    // VSC object extracted from: BossCortex_C3_MineHandler.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class BossCortex_C3_MineHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public float _Float_0x28;
        [FieldAttr(44)] public float _Float_0x2c;
        [FieldAttr(48)] public igHandleMetaField _Damage_Data = new();
        [FieldAttr(56)] public igHandleMetaField _Vfx_Effect = new();
    }
}
