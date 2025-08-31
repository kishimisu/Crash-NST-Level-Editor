namespace Alchemy
{
    // VSC object extracted from: common_LevelEnd_CrateCounter_c.igz

    [ObjectAttr(96, metaType: typeof(CVscComponentData))]
    public class common_LevelEnd_CrateCounterData : CVscComponentData
    {
        public enum ENewEnum13_id_jtw9zr4w
        {
            None = 0,
            Countdown = 1,
            NoCratesBroken = 2,
        }

        public enum ENewEnum14_id_6osrh3mf
        {
            Clear = 0,
            Blue = 1,
            Yellow = 2,
        }

        [FieldAttr(40)] public ENewEnum13_id_jtw9zr4w _NewEnum13_id_jtw9zr4w;
        [FieldAttr(44)] public ENewEnum14_id_6osrh3mf _NewEnum14_id_6osrh3mf;
        [FieldAttr(48)] public igHandleMetaField _EntityVariable_id_qqdf2er0_variable = new();
        [FieldAttr(56)] public igHandleMetaField _EntityVariable_id_3xc19dte_variable = new();
        [FieldAttr(64)] public igHandleMetaField _Count = new();
        [FieldAttr(72)] public int _Int;
        [FieldAttr(80)] public igHandleMetaField _EntityVariable_id_654izvrc_variable = new();
        [FieldAttr(88)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
