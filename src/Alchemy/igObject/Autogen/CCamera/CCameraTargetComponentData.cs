namespace Alchemy
{
    [ObjectAttr(80, 4)]
    public class CCameraTargetComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public bool _isHero;
        [FieldAttr(25)] public bool _disablePlayerTargetsWhileEnabled;
        [FieldAttr(26)] public bool _zoomToFit;
        [FieldAttr(28)] public float _dampingFactor = 0.2f;
        [FieldAttr(32)] public float _weight = 0.6f;
        [FieldAttr(36)] public float _innerRadius = 300.0f;
        [FieldAttr(40)] public float _outerRadius = 800.0f;
        [FieldAttr(44)] public float _enableRadius = 1200.0f;
        [FieldAttr(48)] public float _disableRadius = 1300.0f;
        [FieldAttr(52)] public float _blendInTime = 1.5f;
        [FieldAttr(56)] public bool _skipBlendInTimeOnFirstEnable;
        [FieldAttr(60)] public float _blendOutTime = 1.5f;
        [FieldAttr(64)] public bool _startEnabled = true;
        [FieldAttr(68)] public float _autoDisableTime = -1.0f;
        [FieldAttr(72)] public float _heightOffset = 45.0f;
    }
}
