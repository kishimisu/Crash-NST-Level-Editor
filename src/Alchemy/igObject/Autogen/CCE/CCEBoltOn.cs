namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CCEBoltOn : CCombatNodeEvent
    {
        [FieldAttr(80)] public string? mModelName = null;
        [FieldAttr(88)] public string? mSkinName = null;
        [FieldAttr(96)] public CBoltPoint? mBoltPoint;
        [FieldAttr(104)] public EBoltonModels mBoltOnSlot;
        [FieldAttr(108)] public bool mRemoveBoltOn;
        [FieldAttr(109)] public bool mReplaceCurrent;
    }
}
