namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CEntityMessage))]
    public class Scripts_MaterialOverrideComponentApplyMaterialMessage : CEntityMessage
    {
        public enum EAction : uint
        {
            Apply = 0,
            Remove = 1,
        }

        [FieldAttr(56)] public string? MaterialIdentifier = null;
        [FieldAttr(64)] public EAction ApplyOrRemove;
    }
}
