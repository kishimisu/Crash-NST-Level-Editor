namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igAnimation2 : igNamedObject
    {
        [FieldAttr(24)] public int _priority;
        [FieldAttr(32)] public igAnimationBinding2List? _bindingList;
        [FieldAttr(40)] public igAnimationTransitionList? _transitionList;
    }
}
