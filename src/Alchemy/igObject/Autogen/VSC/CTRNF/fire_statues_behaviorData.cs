namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class fire_statues_behaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Vfx_Effect = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x28;
        [FieldAttr(nst: 52, ctr: 44)] public float _Float_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x30;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Sound = new();
    }
}
