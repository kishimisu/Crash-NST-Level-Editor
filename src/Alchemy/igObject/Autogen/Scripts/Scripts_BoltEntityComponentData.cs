namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_BoltEntityComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_BoltEntityComponent_
    {
        [FieldAttr(40)] public igHandleMetaField _EntityToBoltTo = new();
        [FieldAttr(48)] public bool AttachToParent;
        [FieldAttr(56)] public CBoltPoint? cBoltPoint;
        [FieldAttr(64)] public bool bCollision;
        [FieldAttr(65)] public bool bPositionOffset;
        [FieldAttr(66)] public bool bSingleFrame;
        [FieldAttr(67)] public bool bKeepAngles;
        [FieldAttr(68)] public bool AuthorityOnly;
    }
}
