namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CBehaviorClip : CCharacterClip
    {
        [FieldAttr(32)] public CBehaviorLayer? _layer;
        [FieldAttr(40)] public bool _isPartial;
        [FieldAttr(48)] public CBehaviorStateList? _parentStates;
    }
}
