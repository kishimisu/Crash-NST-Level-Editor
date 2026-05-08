namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 24, align: 8)]
    public class igAnimationTransitionPoint2 : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public int _transitionTime;
        [FieldAttr(nst: 24, ctr: 16)] public igAnimationTransitionParameters? _parameters;
    }
}
