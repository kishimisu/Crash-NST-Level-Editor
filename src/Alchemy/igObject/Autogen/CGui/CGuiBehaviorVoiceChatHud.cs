namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CGuiBehaviorVoiceChatHud : igGuiBehavior
    {
        [FieldAttr(16)] public int _talkerIndex;
        [FieldAttr(24, false)] public igGuiPlaceable? _speakerIconPlaceable;
        [FieldAttr(32, false)] public igGuiPlaceable? _gamertagPlaceable;
        [FieldAttr(40)] public float _opacity;
        [FieldAttr(44)] public float _targetOpacity;
    }
}
