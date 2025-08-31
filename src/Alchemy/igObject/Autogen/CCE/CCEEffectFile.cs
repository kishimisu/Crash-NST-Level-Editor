namespace Alchemy
{
    [ObjectAttr(160, 8)]
    public class CCEEffectFile : CCombatNodeEvent
    {
        [FieldAttr(80)] public CUpgradeableVfx? _effect;
        [FieldAttr(88)] public CBoltPoint? mBoltPoint;
        [FieldAttr(96)] public CBoltPoint? mBoltPoint2;
        [FieldAttr(104)] public CBoltPoint? _passengerBoltPoint;
        [FieldAttr(112)] public CBoltPoint? _passengerBoltPoint2;
        [FieldAttr(120)] public string? _tagName = null;
        [FieldAttr(128)] public bool _preventDuplicates;
        [FieldAttr(129)] public bool _activateTerrainSpawnLayers;
        [FieldAttr(130)] public bool _attachToBolt = true;
        [FieldAttr(131)] public bool _useBoltOrientation = true;
        [FieldAttr(132)] public bool _checkForGround;
        [FieldAttr(136)] public float _checkUpOffset = 60.0f;
        [FieldAttr(140)] public float _checkLength = 100.0f;
        [FieldAttr(144)] public bool _killEffectOnEnd;
        [FieldAttr(148)] public igVfxManager.EffectKillType _killTypeOnEnd = igVfxManager.EffectKillType.kHardKill;
        [FieldAttr(152)] public bool _spawnWhenEntityInvisible = true;
    }
}
