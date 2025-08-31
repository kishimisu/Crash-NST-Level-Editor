namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CAttributeBoostMessage))]
    public class CAttributeBoostMessage : CEntityMessage
    {
        public enum EAddRemoveOperation : uint
        {
            eARO_Add = 0,
            eARO_Remove = 1,
        }

        [FieldAttr(56)] public CCharacterAttributeList? _attributeBoosts;
        [FieldAttr(64)] public EAddRemoveOperation _addRemoveOperation;
    }
}
