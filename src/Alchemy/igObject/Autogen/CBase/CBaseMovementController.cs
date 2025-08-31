namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CBaseMovementController : igObject
    {
        public enum EMovementControllerState : int
        {
            eMCS_Invalid = -1,
            eMCS_Active = 0,
            eMCS_Paused = 1,
            eMCS_Completed = 2,
            eMCS_Inactive = 3,
        }

        [FieldAttr(16)] public bool _startEnabled;
        [FieldAttr(24)] public igHandleMetaField _entity = new();
        [FieldAttr(32)] public EMovementControllerState _state = CBaseMovementController.EMovementControllerState.eMCS_Inactive;
        [FieldAttr(40)] public igVscDelegateMetaField _finishedCallback = new();
    }
}
