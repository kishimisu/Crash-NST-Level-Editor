namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Air_BalloonCrateData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Component_Data = new();
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 65, ctr: 57)] public bool _Bool_0x41;
        [FieldAttr(nst: 68, ctr: 60)] public int _Int;
    }
}
