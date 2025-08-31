namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CTelegram : igObject
    {
        [FieldAttr(16)] public CEntityMessage? _sendingMessage;
        [FieldAttr(24)] public float _messageSendDelayOverride = -1.0f;
        [FieldAttr(28)] public float _randomMaxDelayOverride = -1.0f;
        [FieldAttr(32)] public CEntityTargetList? _sendMessageTargets;
        [FieldAttr(40)] public uint _additionalTargets;
        [FieldAttr(44)] public bool _actOnTargets;
    }
}
