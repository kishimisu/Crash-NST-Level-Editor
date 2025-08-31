namespace Alchemy
{
    [ObjectAttr(160, 8, metaType: typeof(CSetGameSpeedMessage))]
    public class CSetGameSpeedMessage : CEntityMessage
    {
        [FieldAttr(56)] public float _speed = 1.0f;
        [FieldAttr(60)] public float _timeInSeconds;
        [FieldAttr(64)] public igVfxRangedCurveMetaField _gameSpeedCurve = new();
        [FieldAttr(152)] public igStringRefList? _volumeGroupsToPitch;
    }
}
