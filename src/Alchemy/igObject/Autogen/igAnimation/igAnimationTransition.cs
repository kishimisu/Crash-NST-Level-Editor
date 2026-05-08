namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 56, align: 8)]
    public class igAnimationTransition : igObject
    {
        [FieldAttr(nst: 16, ctr: 16, refCount: false)] public igAnimation2? _baseAnimation;
        [FieldAttr(nst: 24, ctr: 24)] public igMemoryRef<igAnimationTransitionPoint2> _transitionPointArray = new();
        [FieldAttr(nst: 40, ctr: 40)] public int _transitionPointCount;
        [FieldAttr(nst: 48, ctr: 48)] public igAnimationTransitionParameters? _defaultParameters;
    }
}
