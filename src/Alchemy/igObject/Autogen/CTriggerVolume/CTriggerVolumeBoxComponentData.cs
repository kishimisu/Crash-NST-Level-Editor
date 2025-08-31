namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CTriggerVolumeBoxComponentData : CTriggerVolumeComponentData
    {
        [FieldAttr(80)] public igVec3fMetaField _dimensions = new();
        [FieldAttr(92)] public float _convexRadius = 0.05f;
    }
}
