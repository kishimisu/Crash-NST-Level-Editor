namespace Alchemy
{
    [ObjectAttr(296, 4)]
    public class CVfxBudget : igVfxBudget
    {
        [FieldAttr(240)] public uint _CVfxBoltCount = 32;
        [FieldAttr(244)] public uint _CVfxCameraBoltCount = 32;
        [FieldAttr(248)] public uint _CVfxDebugBoltCount = 32;
        [FieldAttr(252)] public uint _CVfxMeshSpawnLocationCount = 32;
        [FieldAttr(256)] public uint _CVfxGroundBoltCount = 32;
        [FieldAttr(260)] public uint _CVfxScreenBoltCount = 32;
        [FieldAttr(264)] public uint _CVfxLandVehicleMaterialCollisionBoltCount = 32;
        [FieldAttr(268)] public uint _CVfxWaterVehicleWaterCollisionBoltCount = 32;
        [FieldAttr(272)] public uint _CVfxVehicleMaterialCollisionSpawnRateCount = 32;
        [FieldAttr(276)] public uint _pointLightPoolCount = 32;
        [FieldAttr(280)] public uint _boxLightPoolCount = 32;
        [FieldAttr(284)] public uint _tintSpherePoolCount = 32;
        [FieldAttr(288)] public uint _rigidBodyCount = 200;
        [FieldAttr(292)] public uint _drawModelCount = 200;
    }
}
