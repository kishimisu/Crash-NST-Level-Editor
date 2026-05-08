namespace Alchemy
{
    [ObjectAttr(nst: 64, ctr: 16, align: 8)]
    public class CMultiplayerAssignTeamsComponentData : CEntityComponentData
    {
        public enum ETeamAssignmentMode
        {
            eTAM_EvenTeams = 0,
            eTAM_OnePlayerPerTeam = 1,
            eTAM_OneVsAllTheRest = 2,
        }

        [FieldAttr(nst: 24)] public bool _showOnlineNames;
        [FieldAttr(nst: 28)] public ETeamAssignmentMode _teamAssignmentMode;
        [FieldAttr(nst: 32)] public bool _assignNewPlayersToTeams;
        [FieldAttr(nst: 40)] public CCameraList? _teamCameras;
        [FieldAttr(nst: 48)] public CCamera? _notOnATeamCamera;
        [FieldAttr(nst: 56)] public CTeamRingComponentData? _teamRingComponentData;
    }
}
