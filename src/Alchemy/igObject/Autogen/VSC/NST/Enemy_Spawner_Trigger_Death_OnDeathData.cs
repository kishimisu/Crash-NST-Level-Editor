namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_Spawner_Trigger_Death_OnDeathData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
        [FieldAttr(nst: 56, ctr: 48)] public string? _String = null;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 65, ctr: 57)] public bool _Bool_0x41;
        [FieldAttr(nst: 66, ctr: 58)] public bool _Bool_0x42;
        [FieldAttr(nst: 67, ctr: 59)] public bool _Bool_0x43;
    }
}
