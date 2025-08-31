namespace Alchemy
{
    [ObjectAttr(88, 8)]
    public class CVector3SliderNodeData : igObject
    {
        [FieldAttr(16)] public CVectorSlider? _slider;
        [FieldAttr(24)] public igVscDelegateMetaField _reachedStartCallback = new();
        [FieldAttr(40)] public igVscDelegateMetaField _updatingCallback = new();
        [FieldAttr(56)] public igVscDelegateMetaField _reachedEndCallback = new();
        [FieldAttr(72)] public igVscVec3fDelegateMetaField _currentValue = new();
    }
}
