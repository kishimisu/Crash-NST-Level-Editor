namespace Alchemy
{
    [ObjectAttr(344, 8)]
    public class CVehicleSystemData : igObject
    {
        public enum EVehicleCollisionReaction : int
        {
            eVCR_None = -1,
            eVCR_Minor = 0,
            eVCR_Moderate = 1,
            eVCR_Major = 2,
        }

        [FieldAttr(16)] public float _armorStatConstant = 100.0f;
        [FieldAttr(20)] public float _massForMinWeight = 100.0f;
        [FieldAttr(24)] public float _massForMaxWeight = 1.0f;
        [FieldAttr(32)] public CVehicleCollisionResponseCriteriaList? _collisionResponseCriteria;
        [FieldAttr(40)] public CVehicleCollisionSpeedMassModList? _speedMassModifcations;
        [FieldAttr(48)] public CVehicleCollisionDriftMassModList? _driftMassModifcations;
        [FieldAttr(56)] public igVfxRangedCurveMetaField _collisionDamageMultiplierByWeightDifference = new();
        [FieldAttr(140)] public igVfxRangedCurveMetaField _collisionVelocityTransferredByWeight = new();
        [FieldAttr(224)] public float _knockawayFromCollisionDuration = 0.1f;
        [FieldAttr(228)] public float _knockawayFromCollisionForceMultiplier = 1.0f;
        [FieldAttr(232)] public float _knockawayAngularTime = 0.1f;
        [FieldAttr(240)] public CVehicleSection? _debugDefaultVehicleSection;
        [FieldAttr(248)] public CVehicleSwapData? _vehicleSwapData;
        [FieldAttr(256)] public int _topSpeedStatToMatchBoost = 95;
        [FieldAttr(260)] public float _superChargeDamageMultiplier = 1.1f;
        [FieldAttr(264)] public CDifficultySpecificFloat? _skylanderDamageReductionMultiplier;
        [FieldAttr(272)] public igHandleMetaField _onlyDriversCanModSwapVo = new();
        [FieldAttr(280)] public igHandleMetaField _onlyDriversCanModSwapHugoVo = new();
        [FieldAttr(288)] public igHandleMetaField _hugoObjectiveRequirement = new();
        [FieldAttr(296)] public CVehiclePersonalizationSetItemList? _vehiclePersonalizationSets;
        [FieldAttr(304)] public CVehiclePersonalizationColorSchemeItemList? _vehiclePersonalizationColorScheme;
        [FieldAttr(312)] public CVehiclePersonalizationTopperItemList? _vehiclePersonalizationToppers;
        [FieldAttr(320)] public CVehiclePersonalizationNeonItemList? _vehiclePersonalizationNeon;
        [FieldAttr(328)] public CVehiclePersonalizationTauntItemList? _vehiclePersonalizationTaunts;
        [FieldAttr(336)] public CVehiclePersonalizationBoostItemList? _vehiclePersonalizationBoosts;
    }
}
