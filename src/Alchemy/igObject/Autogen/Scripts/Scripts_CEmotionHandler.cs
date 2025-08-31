namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_CEmotionHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public float _emotionEmotionWhenActivated = 1.0f;
        [FieldAttr(84)] public float _emotionEmotionWhileDeactivated = 1.0f;
    }
}
