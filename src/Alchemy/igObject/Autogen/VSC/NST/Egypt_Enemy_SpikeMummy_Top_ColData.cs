namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Egypt_Enemy_SpikeMummy_Top_ColData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? _SpinDeath = null;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Bolt_Point_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 72, ctr: 64)] public float _Float;
        [FieldAttr(nst: 76, ctr: 68)] public bool _Bool;
    }
}
