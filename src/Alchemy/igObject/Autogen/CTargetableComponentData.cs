namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CTargetableComponentData : CEntityComponentData
    {
        public enum ETargetablePriority : uint
        {
            eTP_Min = 0,
            eTP_Lowest = 1,
            eTP_Lower = 2,
            eTP_Low = 3,
            eTP_Normal = 4,
            eTP_High = 5,
            eTP_Higher = 6,
            eTP_Highest = 7,
            eTP_Max = 8,
        }

        public enum ETargetableVehicleModes : uint
        {
            eTVM_OnFoot = 0,
            eTVM_Vehicle = 1,
            eTVM_Both = 2,
        }

        [FieldAttr(24)] public ETargetablePriority _priority = CTargetableComponentData.ETargetablePriority.eTP_Normal;
        [FieldAttr(28)] public bool _showTargetLockReticle = true;
        [FieldAttr(32)] public CBoltPoint? _targetLockReticleBolt;
        [FieldAttr(40)] public ETargetableVehicleModes _targetableVehicleModes = CTargetableComponentData.ETargetableVehicleModes.eTVM_Both;
    }
}
