namespace Alchemy
{
    [ObjectAttr(96, 8, metaType: typeof(CDeathHandlingLogic))]
    public class CDeathHandlingLogic : CBehaviorLogic
    {
        [FieldAttr(80)] public float _removalDelay;
        [FieldAttr(84)] public float _fadeStartDelay;
        [FieldAttr(88)] public float _fadeDuration = 0.5f;
    }
}
