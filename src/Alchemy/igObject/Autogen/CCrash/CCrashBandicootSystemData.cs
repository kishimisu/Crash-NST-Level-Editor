namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CCrashBandicootSystemData : igSingleton
    {
        [FieldAttr(16)] public igHandleMetaField _crash1Hub = new();
        [FieldAttr(24)] public igHandleMetaField _crash2Hub = new();
        [FieldAttr(32)] public igHandleMetaField _crash3Hub = new();
        [FieldAttr(40)] public int _deathRatingOne = 7;
        [FieldAttr(44)] public int _deathRatingTwo = 12;
        [FieldAttr(48)] public int _deathRatingThree = 15;
        [FieldAttr(56)] public CGameBoolVariable? _superChargedBodySlamGameVariable;
        [FieldAttr(64)] public CGameBoolVariable? _doubleJumpGameVariable;
        [FieldAttr(72)] public CGameBoolVariable? _deathTornadoSpinGameVariable;
        [FieldAttr(80)] public CGameBoolVariable? _fruitBazookaGameVariable;
        [FieldAttr(88)] public CGameBoolVariable? _speedShoesGameVariable;
        [FieldAttr(96)] public CGameBoolVariable? _speedShoesCrash2GameVariable;
        [FieldAttr(104)] public CGameBoolVariable? _playableCocoGameVariable;
    }
}
