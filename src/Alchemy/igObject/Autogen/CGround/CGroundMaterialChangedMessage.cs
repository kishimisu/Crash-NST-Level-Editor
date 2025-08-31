namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CGroundMaterialChangedMessage))]
    public class CGroundMaterialChangedMessage : CEntityMessage
    {
        [FieldAttr(56)] public igHandleMetaField _newMaterial = new();
    }
}
