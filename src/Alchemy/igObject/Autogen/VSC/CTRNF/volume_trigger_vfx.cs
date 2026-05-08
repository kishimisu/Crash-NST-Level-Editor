namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class volume_trigger_vfx : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SteamBlower_BehaviorDatas = new();
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Sound = new();
        [FieldAttr(nst: 56, ctr: 48)] public float _SteamBlower_BehaviorDatas002;
        [FieldAttr(nst: 60, ctr: 52)] public float _Float;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x38;
        [FieldAttr(nst: 65, ctr: 57)] public bool _Bool_0x39;
        [FieldAttr(nst: 66, ctr: 58)] public bool _Bool_0x3a;
    }
}
