namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igGuiKeyframe : igObject
    {
        public enum EInterpolationMode : int
        {
            kInterpolationInheritFromTrack = -1,
            kInterpolationNone = 0,
            kInterpolationLinear = 1,
            kInterpolationBezier = 2,
        }

        [FieldAttr(16)] public igTimeMetaField _time = new();
        [FieldAttr(20)] public EInterpolationMode _interpolationIn = igGuiKeyframe.EInterpolationMode.kInterpolationInheritFromTrack;
        [FieldAttr(24)] public EInterpolationMode _interpolationOut = igGuiKeyframe.EInterpolationMode.kInterpolationInheritFromTrack;
    }
}
