namespace Alchemy
{
    [ObjectAttr(232, 8)]
    public class CDynamicClipEntity : CGameEntity
    {
        [ObjectAttr(2)]
        public class ClipTypeStorage : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _clipTeamHero = true;
            [FieldAttr(1, size: 1)] public bool _clipNPCEnemies = false;
            [FieldAttr(2, size: 1)] public bool _clipPlayers;
            [FieldAttr(3, size: 1)] public bool _clipNPCAltEnemies = false;
            [FieldAttr(4, size: 1)] public bool _clipWorld = false;
        }

        [FieldAttr(224)] public bool _clipEnabled = true;
        [FieldAttr(226)] public ClipTypeStorage _clipTypeStorage = new();
    }
}
