namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class WR_Dorsey_Dingodile_SplineEntData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public int _Int;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float_0x3c;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Entity_Handle_List = new();
    }
}
