namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _SpawnerActivationList = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _DelayBetweenActiavations;
        [FieldAttr(nst: 52, ctr: 44)] public ENewEnum4_id_daqgq2qt _NewEnum4_id_daqgq2qt;
        [FieldAttr(nst: 56, ctr: 48)] public int _Int;
        [FieldAttr(nst: 60, ctr: 52)] public bool _Bool_0x3c;
        [FieldAttr(nst: 61, ctr: 53)] public bool _Bool_0x3d;
    }
}
