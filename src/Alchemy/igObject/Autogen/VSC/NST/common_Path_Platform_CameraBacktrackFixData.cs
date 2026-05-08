namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 56, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Path_Platform_CameraBacktrackFixData : CVscComponentData
    {
        public enum ENewEnum4_id_9ae5kad1
        {
            OnStart = 0,
            OnFinished = 1,
            None = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _common_Gem_Platform_SplineDatas002 = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float_0x30;
        [FieldAttr(nst: 52, ctr: 44)] public ENewEnum4_id_9ae5kad1 _NewEnum4_id_9ae5kad1;
        [FieldAttr(nst: 56, ctr: 48)] public float _Float_0x38;
    }
}
