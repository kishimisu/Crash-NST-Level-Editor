namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CStaticComponentData : igComponentData
    {
        [ObjectAttr(4)]
        public class FlagsBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public igModelInstance.EDistanceCullImportance _distanceCullImportance = igModelInstance.EDistanceCullImportance.kMedium;
            [FieldAttr(3, size: 1)] public bool _ignoreOcclusionBoxes;
            [FieldAttr(4, size: 1)] public bool _receiveDecals = false;
            [FieldAttr(5, size: 1)] public bool _disableVisual;
            [FieldAttr(6, size: 1)] public bool _castsShadows = false;
            [FieldAttr(7, size: 2)] public EMobileShadowState _mobileShadowState;
            [FieldAttr(9, size: 1)] public bool _includeInBake = false;
        }

        [FieldAttr(24)] public CFxMaterialRedirectTable? _materialOverrides;
        [FieldAttr(32)] public FlagsBitfield _flagsBitfield = new();
    }
}
