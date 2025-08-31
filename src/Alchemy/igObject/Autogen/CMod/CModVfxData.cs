namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CModVfxData : igObject
    {
        public enum EVehicleModVfxType : uint
        {
            eVMVT_Tread = 0,
            eVMVT_Ambient = 1,
        }

        [FieldAttr(16)] public CVfxEffectDotNetHandle? _effect;
        [FieldAttr(24)] public CBoltPoint? _bolt01;
        [FieldAttr(32)] public CBoltPoint? _bolt02;
        [FieldAttr(40)] public EVehicleModVfxType _modType;
        [FieldAttr(44)] public bool _playsWhileJumping;
        [FieldAttr(45)] public bool _hardKill;
        [FieldAttr(48)] public float _secondsToGoToFullThrottle = 0.5f;
        [FieldAttr(52)] public float _secondsDownFromFullThrottle = 0.25f;
    }
}
