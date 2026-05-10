namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class spawn_vfx_in_sequenceData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int;
        [FieldAttr(nst: 44, ctr: 36)] public bool _Bool_0x24;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Float_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public bool _Bool_0x30;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _igEntity_List = new();
        [FieldAttr(nst: 72, ctr: 64)] public bool _Bool_0x40;
        [FieldAttr(nst: 73, ctr: 65)] public bool _Bool_0x41;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Vfx_Effect_List = new();
    }
}
