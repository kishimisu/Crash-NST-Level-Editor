namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVisualDataBoxComponentData : igComponentData
    {
        public enum EPriority : uint
        {
            kHigh = 0,
            kMedium = 1,
            kLow = 2,
        }

        public enum EAnimationType : uint
        {
            kSpacial = 0,
            kTime = 1,
        }

        [FieldAttr(24)] public igVec3fMetaField _dimensions = new();
        [FieldAttr(36)] public float _transitionSizePx = 0.75f;
        [FieldAttr(40)] public float _transitionSizeNx = 0.75f;
        [FieldAttr(44)] public float _transitionSizePy = 0.75f;
        [FieldAttr(48)] public float _transitionSizeNy = 0.75f;
        [FieldAttr(52)] public float _transitionSizePz = 0.75f;
        [FieldAttr(56)] public float _transitionSizeNz = 0.75f;
        [FieldAttr(60)] public EPriority _priority = CVisualDataBoxComponentData.EPriority.kLow;
        [FieldAttr(64)] public bool _state = true;
        [FieldAttr(68)] public EAnimationType _animationType;
        [FieldAttr(72)] public float _animationDuration = 5.0f;
        [FieldAttr(80)] public CVisualDataGroup? _data;
    }
}
