namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CPlayerRespawnBlockerChecker : igObject
    {
        public enum EResult : uint
        {
            eR_None = 0,
            eR_Pending = 1,
            eR_Blocked = 2,
            eR_Clear = 3,
        }

        [FieldAttr(16)] public igHandleMetaField _activeQuery = new();
        [FieldAttr(24)] public EResult _result;
        [FieldAttr(28)] public igVec3fMetaField _sourcePos = new();
    }
}
