namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class igTimeTransform2 : igObject
    {
        public enum ERepeatMode : uint
        {
            kRepeatNone = 0,
            kRepeatClamp = 1,
            kRepeatLoop = 2,
        }

        [FieldAttr(16)] public float _scale = 1.0f;
        [FieldAttr(20)] public float _bias;
        [FieldAttr(24)] public igTimeMetaField _cutoff = new();
        [FieldAttr(28)] public ERepeatMode _repeatMode;
        [FieldAttr(32)] public igTimeMetaField _initialTime = new();
    }
}
