namespace Alchemy
{
    // VSC object extracted from: Multiple_Spawner_Template_c.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class Multiple_Spawner_Template_c : CVscComponentData
    {
        [FieldAttr(40)] public bool _SpawnMultipleWaves;
        [FieldAttr(41)] public bool _WaitForSpawnTemplateEvent;
        [FieldAttr(42)] public bool _SpawnAtSpawner;
        [FieldAttr(43)] public bool _UseTriggerVolume;
        [FieldAttr(48)] public igHandleMetaField _Spawn_Entity_List = new();
        [FieldAttr(56)] public igHandleMetaField _DependentSpawnersList = new();
        [FieldAttr(64)] public float _DelayBetweenEntities;
        [FieldAttr(68)] public float _DelayBetweenSets;
        [FieldAttr(72)] public igHandleMetaField _Bolt_Point = new();
        [FieldAttr(80)] public igHandleMetaField _Entity_List = new();
        [FieldAttr(88)] public int _Int;
        [FieldAttr(92)] public bool _Bool_0x5c;
        [FieldAttr(93)] public bool _Bool_0x5d;
        [FieldAttr(94)] public bool _Bool_0x5e;
        [FieldAttr(96)] public float _Float;
        [FieldAttr(100)] public bool _Bool_0x64;
        [FieldAttr(104)] public string? _String = null;
    }
}
