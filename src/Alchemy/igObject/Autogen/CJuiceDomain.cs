namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CJuiceDomain : igObject
    {
        public enum EJuiceDomain : uint
        {
            eJD_Permanent = 0,
            eJD_FrontEnd = 1,
            eJD_Story = 2,
            eJD_Town = 3,
            eJD_HeroicChallenges = 4,
            eJD_Multiplayer = 5,
            eJD_PVP = 6,
            eJD_RingOut = 7,
            eJD_Survival = 8,
            eJD_DRC = 9,
            eJD_ActionPacks = 10,
            eJD_MultiplayerPrototype = 11,
            eJD_Mobile = 12,
            eJD_AP_Matchmaking = 13,
        }

        [FieldAttr(16)] public EJuiceDomain _id;
        [FieldAttr(24)] public igStringRefList? _juiceProjectList;
        [FieldAttr(32)] public igStringRefList? _soundBankList;
        [FieldAttr(40)] public igStringRefList? _materialList;
    }
}
