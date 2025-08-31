namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CQuestConversationPresetData : igObject
    {
        [FieldAttr(16)] public float _cameraBlendInDuration = 0.5f;
        [FieldAttr(20)] public float _cameraBlendOutDuration = 0.5f;
        [FieldAttr(24)] public float _cadence = 0.5f;
    }
}
