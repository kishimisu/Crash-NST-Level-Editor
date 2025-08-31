namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CTakeHitLogic))]
    public class CTakeHitLogic : CBehaviorLogic
    {
        [FieldAttr(80)] public bool _allowMultiplePushbacks;
        [FieldAttr(84)] public float _pushbackScale = 1.0f;
    }
}
