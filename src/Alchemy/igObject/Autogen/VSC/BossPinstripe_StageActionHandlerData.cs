namespace Alchemy
{
    // VSC object extracted from: BossPinstripe_StageActionHandler.igz

    [ObjectAttr(56, metaType: typeof(CVscComponentData))]
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

        [FieldAttr(40)] public ENewEnum3_id_rqzi70ky _NewEnum3_id_rqzi70ky;
        [FieldAttr(44)] public bool _Bool;
        [FieldAttr(48)] public float _Float;
        [FieldAttr(52)] public EPinstripeLocation _PinstripeLocation;
    }
}
