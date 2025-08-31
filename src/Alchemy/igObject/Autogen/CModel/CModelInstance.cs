namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CModelInstance : igNamedObject
    {
        [FieldAttr(24)] public bool mIsLinked;
        [FieldAttr(32, false)] public CGameEntity? mEntity;
        [FieldAttr(40)] public igModelInstance? mIgModel;
        [FieldAttr(48, false)] public CModelInstance? mBoltTargetModel;
        [FieldAttr(56)] public CBoltedModelList? mBoltedModels;
        [FieldAttr(64)] public EAnimationEventMask _animationEventMask;
    }
}
