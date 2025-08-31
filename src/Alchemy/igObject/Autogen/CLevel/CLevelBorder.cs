namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CLevelBorder : igObject
    {
        [FieldAttr(16)] public CLevelBorderWaypointListList? _borderPoints;
        [FieldAttr(24)] public float _topOffset = 150.0f;
        [FieldAttr(28)] public float _bottomOffset = 50.0f;
        [FieldAttr(32)] public bool _reverseDirection;
    }
}
