namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CQuestSystemData : igObject
    {
        [FieldAttr(16)] public CQuestTrackList? _questTracks;
        [FieldAttr(24)] public CEntityHandleGuiMaterialHashTable? _questNPCObjectiveImageMap;
        [FieldAttr(32)] public float _reminderFrequency = 120.0f;
        [FieldAttr(36)] public float _newQuestAlertDelay = 8.0f;
        [FieldAttr(40)] public float _interactionAlertFrequency = 10.0f;
    }
}
