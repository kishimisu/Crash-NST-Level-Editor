namespace Alchemy
{
    [ObjectAttr(nst: 104, ctr: 96, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Spawner_TemplateData : CVscComponentData
    {
        public enum ENewEnum11_id_6xic0fuw
        {
            None = 0,
            Level = 1,
            Session = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public bool _ActivateCheckpointLoad;
        [FieldAttr(nst: 41, ctr: 33)] public bool _ActivateOnSpawn;
        [FieldAttr(nst: 42, ctr: 34)] public bool _RespawnOnDeath;
        [FieldAttr(nst: 43, ctr: 35)] public bool _SpawnOnEnter;
        [FieldAttr(nst: 44, ctr: 36)] public bool _WaitForSpawnTemplateEvent;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _SpawnAtEntity = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _UsedEntityToSpawn = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _TriggerVolume = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _EntityToSpawn = new();
        [FieldAttr(nst: 80, ctr: 72)] public float _InitialDelay;
        [FieldAttr(nst: 84, ctr: 76)] public float _DeathRespawnTimer;
        [FieldAttr(nst: 88, ctr: 80)] public bool _Bool_0x58;
        [FieldAttr(nst: 89, ctr: 81)] public bool _Bool_0x59;
        [FieldAttr(nst: 92, ctr: 84)] public ENewEnum11_id_6xic0fuw _NewEnum11_id_6xic0fuw;
        [FieldAttr(nst: 96, ctr: 88)] public bool _Bool_0x60;
        [FieldAttr(nst: 97, ctr: 89)] public bool _Bool_0x61;
        [FieldAttr(nst: 98, ctr: 90)] public bool _Bool_0x62;
    }
}
