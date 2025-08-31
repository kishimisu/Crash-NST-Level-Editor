namespace Alchemy
{
    [ObjectAttr(1840, 8)]
    public class CAirLinearVehicleHandlingComponentData : CBaseVehicleControllerComponentData
    {
        [FieldAttr(1776)] public float _deflectionTime;
        [FieldAttr(1780)] public float _resetTime;
        [FieldAttr(1784)] public igVec3fMetaField _anglesAtMaxDeflection = new();
        [FieldAttr(1796)] public igVec2fMetaField _speedAtMaxDeflection = new();
        [FieldAttr(1804)] public bool _doAnglesFromTargetPosition;
        [FieldAttr(1808)] public igVec2fMetaField _maxTargetOffset = new();
        [FieldAttr(1816)] public float _collisionQueryRadius = 138.0f;
        [FieldAttr(1820)] public bool _enableHavokCollision = true;
        [FieldAttr(1821)] public bool _enableRaycastCollision = true;
        [FieldAttr(1822)] public bool _usePhysics;
        [FieldAttr(1824)] public EXBUTTON _jumpButtonSecondary = EXBUTTON.JUMP;
        [FieldAttr(1828)] public float _barrelRollPushForce = 1.5f;
        [FieldAttr(1832)] public float _barrelRollTime = 0.5f;
        [FieldAttr(1836)] public float _barrelRollCooldownTime = 0.75f;
    }
}
