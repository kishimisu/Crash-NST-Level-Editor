namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class Multiple_Spawner_Template_c : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _SpawnMultipleWaves;
        [FieldAttr(nst: 41, ctr: 33)] public bool _WaitForSpawnTemplateEvent;
        [FieldAttr(nst: 42, ctr: 34)] public bool _SpawnAtSpawner;
        [FieldAttr(nst: 43, ctr: 35)] public bool _UseTriggerVolume;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Spawn_Entity_List = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _DependentSpawnersList = new();
        [FieldAttr(nst: 64, ctr: 56)] public float _DelayBetweenEntities;
        [FieldAttr(nst: 68, ctr: 60)] public float _DelayBetweenSets;
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(nst: 88, ctr: 80)] public int _Int;
        [FieldAttr(nst: 92, ctr: 84)] public bool _Bool_0x5c;
        [FieldAttr(nst: 93, ctr: 85)] public bool _Bool_0x5d;
        [FieldAttr(nst: 94, ctr: 86)] public bool _Bool_0x5e;
        [FieldAttr(nst: 96, ctr: 88)] public float _Float;
        [FieldAttr(nst: 100, ctr: 92)] public bool _Bool_0x64;
        [FieldAttr(nst: 104, ctr: 96)] public string? _String = null;
    }
}
