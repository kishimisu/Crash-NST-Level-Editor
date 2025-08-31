namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CPlayerRespawnGroundChecker : igObject
    {
        public enum EResult : uint
        {
            eR_None = 0,
            eR_Pending = 1,
            eR_Success = 2,
            eR_Failure = 3,
        }

        [FieldAttr(16)] public igHandleMetaField _activeQuery = new();
        [FieldAttr(24)] public EResult _result;
        [FieldAttr(28)] public igVec3fMetaField _groundPosition = new();
        [FieldAttr(40)] public bool _isLandVehicle;
    }
}
