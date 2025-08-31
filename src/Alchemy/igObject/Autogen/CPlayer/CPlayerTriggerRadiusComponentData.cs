namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CPlayerTriggerRadiusComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public float _radius = 1.0f;
        [FieldAttr(28)] public bool _allPlayersMustEnter;
        [FieldAttr(29)] public bool _allPlayersMustExit;
    }
}
