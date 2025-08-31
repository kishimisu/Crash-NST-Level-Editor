namespace Alchemy
{
    // VSC object extracted from: common_Gem_Platform_c.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_Gem_PlatformData : CVscComponentData
    {
        [FieldAttr(40)] public bool _Rotates;
        [FieldAttr(41)] public bool _Bobs;
        [FieldAttr(44)] public float _BobHeight;
        [FieldAttr(48)] public float _BobDuration;
        [FieldAttr(56)] public igHandleMetaField _GemGameVariable = new();
        [FieldAttr(64)] public igHandleMetaField _StepReactionSFX = new();
        [FieldAttr(72)] public igHandleMetaField _StepReactionVFX = new();
        [FieldAttr(80)] public igHandleMetaField _GemNotCollectedVFX = new();
        [FieldAttr(88)] public int _Int;
        [FieldAttr(92)] public bool _Bool;
        [FieldAttr(96)] public EigEaseType _EaseTypeVariable_id_8t0z7rwu_variable;
    }
}
