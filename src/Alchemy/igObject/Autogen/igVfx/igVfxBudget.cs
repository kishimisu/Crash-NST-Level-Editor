namespace Alchemy
{
    [ObjectAttr(240, 4)]
    public class igVfxBudget : igObject
    {
        [FieldAttr(16)] public u8 _spawnGroupCount = 1;
        [FieldAttr(20)] public uint _pghPoolSize = 32;
        [FieldAttr(24)] public uint _geoAndMaterialPoolSize = 32;
        [FieldAttr(28)] public uint _spawnedEffectPoolCapacity = 32;
        [FieldAttr(32)] public uint _igVfxRangedCurveSpawnCountCount = 32;
        [FieldAttr(36)] public uint _igVfxRangedCurveSpawnRateCount = 32;
        [FieldAttr(40)] public uint _igVfxBoltCount = 32;
        [FieldAttr(44)] public uint _igVfxSubEffectBoltCount = 32;
        [FieldAttr(48)] public uint _igGuiPlaceableBoltCount = 32;
        [FieldAttr(52)] public uint _igVfxBoxSpawnLocationCount = 32;
        [FieldAttr(56)] public uint _igVfxCurveSpawnLocationCount = 32;
        [FieldAttr(60)] public uint _igVfxCylindricalSpawnLocationCount = 32;
        [FieldAttr(64)] public uint _igVfxSpawnLocationCount = 32;
        [FieldAttr(68)] public uint _igVfxSphericalSpawnLocationCount = 32;
        [FieldAttr(72)] public uint _igVfxCompositeSpawnLocationCount = 32;
        [FieldAttr(76)] public uint _igVfxBezierCount = 32;
        [FieldAttr(80)] public uint _igVfxBezierInstanceCount = 32;
        [FieldAttr(84)] public uint _igVfxBezierWindingFlips = 3;
        [FieldAttr(88)] public uint _igVfxCylinderCount = 32;
        [FieldAttr(92)] public uint _igVfxCylinderInstanceCount = 32;
        [FieldAttr(96)] public uint _igVfxCylinderWindingFlips = 3;
        [FieldAttr(100)] public uint _igVfxDecalCount = 32;
        [FieldAttr(104)] public uint _igVfxDecalInstanceCount = 32;
        [FieldAttr(108)] public uint _igVfxDecalWindingFlips = 3;
        [FieldAttr(112)] public uint _decalPoolCount = 32;
        [FieldAttr(116)] public uint _igVfxLineCount = 32;
        [FieldAttr(120)] public uint _igVfxLineInstanceCount = 32;
        [FieldAttr(124)] public uint _igVfxLineWindingFlips = 3;
        [FieldAttr(128)] public uint _igVfxModelCount = 32;
        [FieldAttr(132)] public uint _igVfxModelInstanceCount = 32;
        [FieldAttr(136)] public uint _modelPoolCount = 32;
        [FieldAttr(140)] public uint _igVfxModelWindingFlips;
        [FieldAttr(144)] public uint _igVfxOperatorPrimitiveCount = 32;
        [FieldAttr(148)] public uint _igVfxOperatorPrimitiveInstanceCount = 32;
        [FieldAttr(152)] public uint _igVfxOperatorPrimitiveWindingFlips;
        [FieldAttr(156)] public uint _igVfxOperatorStorage1Count = 32;
        [FieldAttr(160)] public uint _igVfxOperatorStorage2Count = 32;
        [FieldAttr(164)] public uint _igVfxOperatorStorage3Count = 32;
        [FieldAttr(168)] public uint _igVfxDrawSubEffectOperatorBoltCount = 32;
        [FieldAttr(172)] public uint _igVfxDrawTrailControlPointArrayCount = 32;
        [FieldAttr(176)] public uint _igVfxPlacedPrimitiveCount;
        [FieldAttr(180)] public uint _igVfxPlacedPrimitiveInstanceCount;
        [FieldAttr(184)] public uint _igVfxPlacedPrimitiveWindingFlips = 3;
        [FieldAttr(188)] public uint _igVfxSpriteCount = 32;
        [FieldAttr(192)] public uint _igVfxSpriteInstanceCount = 32;
        [FieldAttr(196)] public uint _igVfxSpriteWindingFlips = 3;
        [FieldAttr(200)] public uint _igVfxSubEffectCount = 32;
        [FieldAttr(204)] public uint _igVfxSubEffectInstanceCount = 32;
        [FieldAttr(208)] public uint _igVfxSubEffectWindingFlips;
        [FieldAttr(212)] public uint _igVfxTrailCount = 32;
        [FieldAttr(216)] public uint _igVfxTrailInstanceCount = 32;
        [FieldAttr(220)] public uint _igVfxTrailWindingFlips = 3;
        [FieldAttr(224)] public uint _igVfxTrailControlPointArrayCount = 32;
        [FieldAttr(228)] public uint _igVfxDataBlockCount;
        [FieldAttr(232)] public uint _streamHeapBlockSize = 512;
        [FieldAttr(236)] public uint _streamHeapTotalSize = 65536;
    }
}
