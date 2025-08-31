namespace Alchemy
{
    [ObjectAttr(80, 8)]
    public class CMod : CUpgrade
    {
        public enum EModLocation : int
        {
            eML_Invalid = -1,
            eML_Primary = 0,
            eML_Secondary = 1,
            eML_Horn = 2,
            eML_Antenna = 3,
            eML_Count = 4,
        }

        [FieldAttr(24)] public CEntityComponentDataList? _modComponentDataList;
        [FieldAttr(32)] public string? _voiceOverNameSound = null;
        [FieldAttr(40)] public string? _voiceOverTaglineSound = null;
        [FieldAttr(48)] public string? _idleSound = null;
        [FieldAttr(56)] public string? _oneShotSound = null;
        [FieldAttr(64)] public string? _modAssetPrefix = null;
        [FieldAttr(72)] public EModLocation _modLocation = CMod.EModLocation.eML_Invalid;
        [FieldAttr(76)] public int _modIndex = -1;
    }
}
