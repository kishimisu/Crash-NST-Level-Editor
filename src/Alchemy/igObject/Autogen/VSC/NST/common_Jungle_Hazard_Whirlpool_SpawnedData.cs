namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Jungle_Hazard_Whirlpool_SpawnedData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public float _Float;
        [FieldAttr(nst: 44, ctr: 36)] public bool _Bool;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Vfx_Effect_0x30 = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Vfx_Effect_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Bolt_Point = new();
    }
}
