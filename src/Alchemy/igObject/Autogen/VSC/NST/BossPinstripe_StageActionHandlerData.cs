namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 48, align: 4, metaType: typeof(CVscComponentData))]
    public class BossPinstripe_StageActionHandlerData : CVscComponentData
    {
        public enum ENewEnum3_id_rqzi70ky
        {
            Shoot = 0,
            MoveToLeftScreen = 1,
            MoveToDeskTop = 2,
            MoveToRightScreen = 3,
            GunJammed = 4,
        }

        public enum EPinstripeLocation
        {
            DeskTop = 0,
            LeftScreen = 1,
            RightScreen = 2,
        }

        [FieldAttr(nst: 40, ctr: 32)] public ENewEnum3_id_rqzi70ky _NewEnum3_id_rqzi70ky;
        [FieldAttr(nst: 44, ctr: 36)] public bool _Bool;
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
        [FieldAttr(nst: 52, ctr: 44)] public EPinstripeLocation _PinstripeLocation;
    }
}
