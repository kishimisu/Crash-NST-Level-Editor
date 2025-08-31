namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_MaterialOverrideComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_MaterialOverrideComponent_
    {
        [FieldAttr(40)] public List_1? Materials;
        [FieldAttr(48)] public bool ApplyMaterialsOnStart = true;
        [FieldAttr(56)] public string? MaterialIdentifier = null;
    }
}
