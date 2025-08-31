namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CTriggerVolumeCapsuleComponentData : CTriggerVolumeComponentData
    {
        [FieldAttr(80)] public igVec3fMetaField _bottom = new();
        [FieldAttr(92)] public igVec3fMetaField _top = new();
        [FieldAttr(104)] public float _radius = 10.0f;
    }
}
