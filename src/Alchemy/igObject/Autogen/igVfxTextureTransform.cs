namespace Alchemy
{
    public class igVfxTextureTransform
    {
        public enum ERotate : uint
        {
            kRotationNone = 0,
            kRotation90 = 1,
            kRotation180 = 2,
            kRotation270 = 3,
            kRotationRandom = 4,
        }

        public enum EMirror : uint
        {
            kMirrorNone = 0,
            kMirrorReverse = 1,
            kMirrorRandom = 2,
        }
    }
}
