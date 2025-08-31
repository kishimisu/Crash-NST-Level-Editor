namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CBehaviorEventTimeline : CCharacterEventTimeline
    {
        [FieldAttr(32)] public bool _disableWhenAnimationOverridden;
        [FieldAttr(33)] public bool _startAtCurrentTimeWhenActivated;
        [FieldAttr(36)] public float _layerWeightThreshhold;
    }
}
