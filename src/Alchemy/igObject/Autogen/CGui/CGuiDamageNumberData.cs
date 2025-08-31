namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CGuiDamageNumberData : igObject
    {
        [FieldAttr(16)] public igHandleMetaField _iconMaterial = new();
        [FieldAttr(24)] public int _damage;
        [FieldAttr(28)] public igVec2fMetaField _screenPosition = new();
        [FieldAttr(36)] public igVec3fMetaField _worldPosition = new();
        [FieldAttr(48)] public EDamageNumberType _damageNumberType = EDamageNumberType.eDNT_Damage;
        [FieldAttr(56)] public CCharacterAttributeList? _statBoostList;
        [FieldAttr(64)] public igHandleMetaField _targetEntity = new();
        [FieldAttr(72)] public igHandleMetaField cameraSystemInstance = new();
        [FieldAttr(80)] public string? _customAnimationName = null;
    }
}
