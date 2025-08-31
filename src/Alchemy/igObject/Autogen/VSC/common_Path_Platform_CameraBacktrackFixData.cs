namespace Alchemy
{
    // VSC object extracted from: common_Path_Platform_CameraBacktrackFix.igz

    [ObjectAttr(64, metaType: typeof(CVscComponentData))]
    public class common_Path_Platform_CameraBacktrackFixData : CVscComponentData
    {
        public enum ENewEnum4_id_9ae5kad1
        {
            OnStart = 0,
            OnFinished = 1,
            None = 2,
        }

        [FieldAttr(40)] public igHandleMetaField _common_Gem_Platform_SplineDatas002 = new();
        [FieldAttr(48)] public float _Float_0x30;
        [FieldAttr(52)] public ENewEnum4_id_9ae5kad1 _NewEnum4_id_9ae5kad1;
        [FieldAttr(56)] public float _Float_0x38;
    }
}
