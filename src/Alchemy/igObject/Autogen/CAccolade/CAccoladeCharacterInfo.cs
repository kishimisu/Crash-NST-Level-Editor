namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CAccoladeCharacterInfo : igObject
    {
        public enum EAccoladeCharacterType : int
        {
            eACT_Invalid = -1,
            eACT_Hero = 0,
            eACT_Chompy = 1,
            eACT_Greeble = 2,
            eACT_Golem = 3,
            eACT_Horg = 4,
            eACT_Boss = 5,
            eACT_SpellPunk = 6,
            eACT_Cyclops = 7,
            eACT_Troll = 8,
            eACT_KangaRat = 9,
            eACT_Amadillo = 10,
            eACT_Bat = 11,
            eACT_ChillyDog = 12,
            eACT_FightingBird = 13,
            eACT_Hootie = 14,
            eACT_Sheep = 15,
            eACT_Turret = 16,
            eACT_Count = 17,
        }

        [FieldAttr(16)] public EAccoladeCharacterType _characterType;
        [FieldAttr(24)] public string? _characterName = null;
    }
}
