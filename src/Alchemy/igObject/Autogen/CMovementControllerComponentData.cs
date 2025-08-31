namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CMovementControllerComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CBaseMovementControllerList? _controllerList;
        [FieldAttr(32)] public bool _autoChangeHavokType = true;
        [FieldAttr(33)] public bool _forcePositionReplication;
        [FieldAttr(36)] public float _maxVelocity = 1000.0f;
    }
}
