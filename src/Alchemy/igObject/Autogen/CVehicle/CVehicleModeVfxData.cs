namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CVehicleModeVfxData : igObject
    {
        public enum EVehicleModeVfxType : uint
        {
            eVMVT_All = 0,
            eVMVT_Arena = 1,
            eVMVT_Linear = 2,
            eVMVT_Expedition = 3,
            eVMVT_UnderWaterArena = 4,
            eVMVT_UnderWaterLinear = 5,
            eVMVT_MagicMoment = 6,
        }

        [FieldAttr(16)] public EVehicleModeVfxType _modeType;
        [FieldAttr(24)] public CModVfxDataList? _modeVfx;
    }
}
