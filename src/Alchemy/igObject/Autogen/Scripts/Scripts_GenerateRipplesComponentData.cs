namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_GenerateRipplesComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_GenerateRipplesComponent_
    {
        [FieldAttr(40)] public float RippleRadius = 10.0f;
        [FieldAttr(44)] public float RippleIntesity = 1.0f;
        [FieldAttr(48)] public Vector3? Offset;
        [FieldAttr(56)] public float SpawnRadius;
        [FieldAttr(60)] public bool Hideable;
    }
}
