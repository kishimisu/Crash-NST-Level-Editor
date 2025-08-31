namespace Alchemy
{
    [ObjectAttr(48, 8, metaType: typeof(CDotNetCombatNodeEvent))]
    public class Scripts_SendMessageEvent : CDotNetCombatNodeEvent
    {
        [FieldAttr(32)] public CEntityMessage? SendingMessage;
        [FieldAttr(40)] public bool ReturnMessage;
        [FieldAttr(41)] public bool SendToCombatTargets;
        [FieldAttr(44)] public ECombatTargetSelect CombatTargets;
    }
}
