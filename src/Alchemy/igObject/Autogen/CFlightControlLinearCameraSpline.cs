namespace Alchemy
{
    [ObjectAttr(104, 8)]
    public class CFlightControlLinearCameraSpline : CAttachmentSpline
    {
        [FieldAttr(88)] public igVec2fMetaField _vehicleTranslationScreenMin = new();
        [FieldAttr(96)] public igVec2fMetaField _vehicleTranslationScreenMax = new();
    }
}
