namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_OrientCameraSwitchData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Camera_Base_0x28 = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Camera_Base_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
    }
}
