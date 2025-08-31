namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CBehaviorLogic))]
    public class Scripts_CollisionHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public bool CollideWithEnemies = true;
        [FieldAttr(81)] public bool CollideWithAltEnemies = true;
        [FieldAttr(82)] public bool CollideWithHeroes = true;
        [FieldAttr(83)] public bool CollideWithPlayers = true;
        [FieldAttr(84)] public bool CollideWithProjectiles = true;
    }
}
