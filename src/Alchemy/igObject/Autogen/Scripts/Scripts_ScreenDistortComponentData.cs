namespace Alchemy
{
    [ObjectAttr(72, 8, metaType: typeof(CDotNetEntityComponentData_1))]
    public class Scripts_ScreenDistortComponentData : NovaScript_CDotNetEntityComponentData_1_Scripts_ScreenDistortComponent_
    {
        [FieldAttr(40)] public string? ScreenDistortStartCustomEvent = "ScreenDistortOn";
        [FieldAttr(48)] public string? ScreenDistortStopCustomEvent = "ScreenDistortOff";
        [FieldAttr(56)] public float DistortStrength = 1.0f;
        [FieldAttr(60)] public EigEaseType DistortEaseType = EigEaseType.kEaseTypeSinusoidal;
        [FieldAttr(64)] public float DistortEaseRatioIn = 0.4f;
        [FieldAttr(68)] public float DistortEaseRatioOut = 0.4f;
    }
}
