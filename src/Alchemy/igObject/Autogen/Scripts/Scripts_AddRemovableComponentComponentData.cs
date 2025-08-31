namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_AddRemovableComponentComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_AddRemovableComponentComponent_
    {
        [FieldAttr(40)] public CEntityComponentData? ComponentToAttach;
        [FieldAttr(48)] public float ComponentDuration;
        [FieldAttr(56)] public CEntityMessage? RemovalMessage;
    }
}
