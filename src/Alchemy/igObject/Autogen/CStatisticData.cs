namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CStatisticData : igObject
    {
        public enum EStatisticWriteType : int
        {
            eSWT_Invalid = -1,
            eSWT_Replace = 0,
            eSWT_Add = 1,
            eSWT_Max = 2,
            eSWT_Min = 3,
            eSWT_BitwiseOR = 4,
        }

        [FieldAttr(16)] public ELeaderBoardID _leaderboardId;
        [FieldAttr(20)] public i16 _keyArchiveId = -1;
        [FieldAttr(24)] public EStatisticWriteType _writeType;
    }
}
