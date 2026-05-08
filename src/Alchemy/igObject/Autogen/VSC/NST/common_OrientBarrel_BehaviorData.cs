namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class common_OrientBarrel_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public string? _Death_State = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float_0x48;
    }
}
