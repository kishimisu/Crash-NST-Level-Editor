namespace Alchemy
{
    [ObjectAttr(nst: 88, ctr: 80, align: 4, metaType: typeof(CVscComponentData))]
    public class common_Basic_BonusRound_Platform_StartData : CVscComponentData
    {
        public enum ENewEnum5_id_b8ggnmc2
        {
            MoveFinished = 0,
            EnterTrigger = 1,
            None = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _EntityTagVariable_id_4dvdsghy_variable = new();
        [FieldAttr(nst: 48, ctr: 40)] public ENewEnum5_id_b8ggnmc2 _NewEnum5_id_b8ggnmc2;
        [FieldAttr(nst: 52, ctr: 44)] public bool _Bool;
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _Entity_0x38 = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Entity_0x40 = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _EntityTagVariable_id_dc99te9h_variable = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _Game_Bool_Variable = new();
    }
}
