namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class BossCortex_C3_ForcefieldHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float_0x28;
        [FieldAttr(nst: 44, ctr: 36)] public float _Float_0x2c;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 64, ctr: 56)] public float _Float_0x40;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float_0x44;
    }
}
