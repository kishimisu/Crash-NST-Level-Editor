namespace Alchemy
{
    [ObjectAttr(256, 8)]
    public class CSkinnedModelInstance : CModelInstance
    {
        [FieldAttr(72)] public CEntityIDMetaField _entityID = new();
        [FieldAttr(80, false)] public CSkinAsset? _skinAsset;
        [FieldAttr(88)] public string? mSkinAnimName = null;
        [FieldAttr(96)] public igVec3fMetaField mSkinBoundsMin = new();
        [FieldAttr(108)] public igVec3fMetaField mSkinBoundsMax = new();
        [FieldAttr(120)] public CHavokAnimationCombiner? mCombiner;
        [FieldAttr(128)] public igRawRefMetaField mAnimatedSkeleton = new();
        [FieldAttr(136)] public igRawRefMetaField mAnim = new();
        [FieldAttr(144)] public bool _automaticUpdate;
        [FieldAttr(145)] public bool _updateAnimation;
        [FieldAttr(146)] public bool _physicsOutOfSync;
        [FieldAttr(147)] public bool _paused;
        [FieldAttr(148)] public bool _animationUpdateSkipped;
        [FieldAttr(152)] public igRawRefMetaField _animationEventListener = new();
        [FieldAttr(160)] public igRawRefMetaField mDefaultAnimMotion = new();
        [FieldAttr(168)] public igVectorMetaField<CBoltedModelMetaField> mBoltedModels_1 = new();
        [FieldAttr(192)] public CGraphicsSkinInfo? _skinInfo;
        [FieldAttr(200)] public CHavokSkeleton? mSkeleton;
        [FieldAttr(208)] public igRawRefMetaField _pendingAnimationControl = new();
        [FieldAttr(216)] public float _pendingBlendTime;
        [FieldAttr(224, false)] public CPhysicsSystemSkeletonBinding? _physicsSystemSkeletonBinding;
        [FieldAttr(232)] public int mRequestUpdateId;
        [FieldAttr(236)] public uint _asyncActive;
        [FieldAttr(240)] public u32 /* igStructMetaField */ _extractedMotionMemento;
    }
}
