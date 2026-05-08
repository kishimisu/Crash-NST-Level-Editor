namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class H100_Hub_Area_Transition_Music_TriggerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public bool _Bool_0x28;
        [FieldAttr(nst: 49, ctr: 41)] public bool _Bool_0x29;
        [FieldAttr(nst: 50, ctr: 42)] public bool _Bool_0x2a;
        [FieldAttr(nst: 51, ctr: 43)] public bool _Bool_0x2b;
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool_0x2c;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Game_Int_Variable = new();
    }
}
