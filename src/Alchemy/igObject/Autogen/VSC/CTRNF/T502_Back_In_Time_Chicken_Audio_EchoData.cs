namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class T502_Back_In_Time_Chicken_Audio_EchoData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Rumble_Data = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity = new();
    }
}
