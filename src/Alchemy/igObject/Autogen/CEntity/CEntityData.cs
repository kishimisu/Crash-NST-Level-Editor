namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class CEntityData : igEntityData
    {
        public enum EEntityTeam : uint
        {
            eET_None = 0,
            eET_Hero = 1,
            eET_Enemy = 2,
            eET_AltEnemy = 3,
        }

        public enum EEntityTeamFaction : uint
        {
            eETF_None = 0,
            eETF_Faction_1 = 1,
            eETF_Faction_2 = 2,
            eETF_Faction_3 = 3,
            eETF_Faction_4 = 4,
            eETF_Faction_5 = 5,
            eETF_Faction_6 = 6,
            eETF_Faction_7 = 7,
            eETF_Faction_8 = 8,
            eETF_Faction_9 = 9,
            eETF_Faction_10 = 10,
            eETF_Faction_11 = 11,
            eETF_Faction_12 = 12,
        }

        [FieldAttr(32)] public uint _entityFlags = 2879492;
        [FieldAttr(36)] public uint _actionEntityFlags = 32;
        [FieldAttr(40)] public EEntityTeam _team;
        [FieldAttr(44)] public EEntityTeamFaction _teamFaction;
        [FieldAttr(48)] public CEntityTagSet? _tags;
    }
}
