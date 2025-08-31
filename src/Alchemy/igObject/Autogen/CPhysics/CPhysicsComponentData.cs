namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CPhysicsComponentData : CBasePhysicsComponentData
    {
        public enum EScaleMode : uint
        {
            eSM_NoScaling = 0,
            eSM_ScaleCollisionOnSpawnOnly = 1,
            eSM_ScaleCollisionWhenChanged = 2,
        }

        [FieldAttr(24)] public EHavokEntityType _motionType = EHavokEntityType.eHET_Fixed;
        [FieldAttr(28)] public float _mass = 1.0f;
        [FieldAttr(32)] public ETeamFilterLayers _collisionLayer = ETeamFilterLayers.eTFL_Entity;
        [FieldAttr(40)] public igHandleMetaField _collisionMaterial = new();
        [FieldAttr(48)] public igHandleMetaField _motionProperties = new();
        [FieldAttr(56)] public ECharacterCollisionPriority _collisionPriority = ECharacterCollisionPriority.eCCP_None;
        [FieldAttr(60)] public EScaleMode _scaleMode = CPhysicsComponentData.EScaleMode.eSM_ScaleCollisionOnSpawnOnly;
        [FieldAttr(64)] public bool _useMaxStepAcceleration;
        [FieldAttr(68)] public float _bodyLookAheadDistance;
    }
}
