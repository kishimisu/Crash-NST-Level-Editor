namespace Alchemy
{
    [ObjectAttr(nst: 80, ctr: 72, align: 4, metaType: typeof(CVscComponentData))]
    public class Enemy_PlayLoopingAnimation_OnEnter_BehaviorData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Entity = new();
        [FieldAttr(nst: 48, ctr: 40)] public string? _String_0x30 = null;
        [FieldAttr(nst: 56, ctr: 48)] public string? _String_0x38 = null;
        [FieldAttr(nst: 64, ctr: 56)] public bool _Bool_0x40;
        [FieldAttr(nst: 65, ctr: 57)] public bool _Bool_0x41;
        [FieldAttr(nst: 68, ctr: 60)] public float _Float;
        [FieldAttr(nst: 72, ctr: 64)] public string? _String_0x48 = null;
    }
}
