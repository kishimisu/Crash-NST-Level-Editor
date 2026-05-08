namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Gem_PlatformData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _Rotates;
        [FieldAttr(nst: 41, ctr: 33)] public bool _Bobs;
        [FieldAttr(nst: 44, ctr: 36)] public float _BobHeight;
        [FieldAttr(nst: 48, ctr: 40)] public float _BobDuration;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _GemGameVariable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _StepReactionSFX = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _StepReactionVFX = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _GemNotCollectedVFX = new();
        [FieldAttr(nst: 88, ctr: 80)] public int _Int;
        [FieldAttr(nst: 92, ctr: 84)] public bool _Bool;
        [FieldAttr(nst: 96, ctr: 88)] public EigEaseType _EaseTypeVariable_id_8t0z7rwu_variable;
    }
}
