namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CModelAnimationDatabase : igInfo
    {
        [FieldAttr(40)] public CModelAnimationHashTable? _animations;
        [FieldAttr(48)] public float _animationLength;
        [FieldAttr(52)] public bool _isLooping;
    }
}
