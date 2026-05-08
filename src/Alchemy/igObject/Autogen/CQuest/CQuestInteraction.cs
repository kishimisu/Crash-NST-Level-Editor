namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 88, align: 8)]
    public class CQuestInteraction : igObject
    {
        [FieldAttr(nst: 16, ctr: 16)] public igHandleMetaField _interactionEntity = new();
        [FieldAttr(nst: 24, ctr: 24)] public CInteractionComponentData? _interactionComponentData;
        [FieldAttr(nst: 32, ctr: 32)] public igHandleMetaField _alertData = new();
        [FieldAttr(nst: 40, ctr: 40)] public bool _automaticallyTriggerInteraction;
        [FieldAttr(nst: 48, ctr: 48)] public string? _description = null;
        [FieldAttr(nst: 56, ctr: 56)] public string? _notInHubDescription = null;
        [FieldAttr(nst: 64, ctr: 64)] public igHandleMetaField _image = new();
        [FieldAttr(nst: 72, ctr: 72)] public igHandleMetaField _quest = new();
        [FieldAttr(nst: 80, ctr: 80)] public CObjectiveHudData? _objectiveHudData;
    }
}
