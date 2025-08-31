namespace Alchemy
{
    [ObjectAttr(64, 4)]
    public class CScreenspaceTargetComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public igVec3fMetaField _targetingBoxDimensions = new();
        [FieldAttr(36)] public bool _targetingBoxOffsetIsWorld = true;
        [FieldAttr(40)] public igVec3fMetaField _targetingBoxOffset = new();
        [FieldAttr(52)] public CScreenspaceTarget.EScreenspaceTargetShape _shapeType;
        [FieldAttr(56)] public bool _requireVisible = true;
        [FieldAttr(57)] public bool _useTargetingBoxCenter;
    }
}
