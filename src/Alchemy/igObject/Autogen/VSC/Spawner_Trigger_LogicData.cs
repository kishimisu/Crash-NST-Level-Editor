namespace Alchemy
{
    // VSC object extracted from: Spawner_Trigger_Logic_c.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class Spawner_Trigger_LogicData : CVscComponentData
    {
        public enum ENewEnum4_id_daqgq2qt
        {
            SpawnWithDefaultActivation = 0,
            SpawnAndForceActivation = 1,
            ForceActivateExistingEntity = 2,
            SpawnDefaultActivationORForceActivateExistingEntity = 3,
            ForceAttackExistingEntity = 4,
            ForceTellExistingEntity = 5,
        }

        [FieldAttr(40)] public igHandleMetaField _SpawnerActivationList = new();
        [FieldAttr(48)] public float _DelayBetweenActiavations;
        [FieldAttr(52)] public ENewEnum4_id_daqgq2qt _NewEnum4_id_daqgq2qt;
        [FieldAttr(56)] public int _Int;
        [FieldAttr(60)] public bool _Bool_0x3c;
        [FieldAttr(61)] public bool _Bool_0x3d;
    }
}
