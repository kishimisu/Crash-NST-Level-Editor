namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CCEAnimateBoltons : CCombatNodeEvent
    {
        [FieldAttr(80)] public EBoltonModels _targetBolton = EBoltonModels.EBOLTON_NONE;
        [FieldAttr(88)] public string? _animationName = null;
        [FieldAttr(96)] public float _playbackSpeed = 1.0f;
        [FieldAttr(100)] public bool _looping;
        [FieldAttr(104)] public float _blendTime = 0.1f;
    }
}
