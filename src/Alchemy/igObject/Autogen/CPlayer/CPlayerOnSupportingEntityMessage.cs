namespace Alchemy
{
    [ObjectAttr(80, 8, metaType: typeof(CPlayerOnSupportingEntityMessage))]
    public class CPlayerOnSupportingEntityMessage : CEntityMessage
    {
        [FieldAttr(56)] public igHandleMetaField _supportingEntity = new();
        [FieldAttr(64)] public igHandleMetaField _lastSupportingEntity = new();
        [FieldAttr(72)] public EPlayerSupportType _supportType;
    }
}
