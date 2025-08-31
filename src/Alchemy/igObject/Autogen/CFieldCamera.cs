namespace Alchemy
{
    [ObjectAttr(336, 16)]
    public class CFieldCamera : CCameraBase
    {
        [FieldAttr(288)] public CCameraBase? _A;
        [FieldAttr(296)] public CCameraBase? _B;
        [FieldAttr(304)] public float _progressCached;
        [FieldAttr(308)] public igVec3fMetaField _min = new();
        [FieldAttr(320)] public igVec3fMetaField _max = new();
        [FieldAttr(332)] public ECameraModelBlendType _blendType = ECameraModelBlendType.eCMBT_Linear;
    }
}
