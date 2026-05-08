namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 8)]
    public class CRigidAnimCtrl : igTimeTransform2
    {
        [FieldAttr(nst: 40, ctr: 32)] public string? mAnimName = null;
        [FieldAttr(nst: 48, ctr: 40)] public float mAnimPauseStart;
        [FieldAttr(nst: 52, ctr: 44)] public float mAnimPauseEnd;
        [FieldAttr(nst: 56, ctr: 48)] public float mAnimPauseSpeed;
        [FieldAttr(nst: 64, ctr: 56)] public igVscDelegateMetaField mAnimCycle = new();
        [FieldAttr(nst: 80, ctr: 72)] public igVscDelegateMetaField mAnimComplete = new();
        [FieldAttr(nst: 96, ctr: 88)] public uint mAnimPlaybackId = 4294967295;
        [FieldAttr(nst: 100, ctr: 92)] public ERigidAnimCtrlState mAnimState;
    }
}
