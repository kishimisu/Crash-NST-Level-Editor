namespace Alchemy
{
    [ObjectAttr(nst: 96, ctr: 88, align: 4, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(nst: 40, ctr: 32)] public ENewEnum13_id_jtw9zr4w _NewEnum13_id_jtw9zr4w;
        [FieldAttr(nst: 44, ctr: 36)] public ENewEnum14_id_6osrh3mf _NewEnum14_id_6osrh3mf;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _EntityVariable_id_qqdf2er0_variable = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _EntityVariable_id_3xc19dte_variable = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Count = new();
        [FieldAttr(nst: 72, ctr: 64)] public int _Int;
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _EntityVariable_id_654izvrc_variable = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
