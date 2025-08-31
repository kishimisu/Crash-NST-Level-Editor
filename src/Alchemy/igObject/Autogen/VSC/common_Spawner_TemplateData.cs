namespace Alchemy
{
    // VSC object extracted from: common_Spawner_Template_c.igz

    [ObjectAttr(104, metaType: typeof(CVscComponentData))]
    public class common_Spawner_TemplateData : CVscComponentData
    {
        public enum ENewEnum11_id_6xic0fuw
        {
            None = 0,
            Level = 1,
            Session = 2,
        }

        [FieldAttr(40)] public bool _ActivateCheckpointLoad;
        [FieldAttr(41)] public bool _ActivateOnSpawn;
        [FieldAttr(42)] public bool _RespawnOnDeath;
        [FieldAttr(43)] public bool _SpawnOnEnter;
        [FieldAttr(44)] public bool _WaitForSpawnTemplateEvent;
        [FieldAttr(48)] public igHandleMetaField _SpawnAtEntity = new();
        [FieldAttr(56)] public igHandleMetaField _UsedEntityToSpawn = new();
        [FieldAttr(64)] public igHandleMetaField _TriggerVolume = new();
        [FieldAttr(72)] public igHandleMetaField _EntityToSpawn = new();
        [FieldAttr(80)] public float _InitialDelay;
        [FieldAttr(84)] public float _DeathRespawnTimer;
        [FieldAttr(88)] public bool _Bool_0x58;
        [FieldAttr(89)] public bool _Bool_0x59;
        [FieldAttr(92)] public ENewEnum11_id_6xic0fuw _NewEnum11_id_6xic0fuw;
        [FieldAttr(96)] public bool _Bool_0x60;
        [FieldAttr(97)] public bool _Bool_0x61;
        [FieldAttr(98)] public bool _Bool_0x62;
    }
}
