namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(igGuiVscBehavior))]
    public class Octane_Customization_PlayerInfo_InfoBox_ButtonText : igGuiVscBehavior
    {
        [FieldAttr(nst: 48, ctr: 40)] public string? _String = null;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity = new();
    }
}
