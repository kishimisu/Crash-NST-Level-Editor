namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CFootIKHandler))]
    public class CFootIKHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public bool _lockFeetAdvancedControl = true;
        [FieldAttr(84)] public float _lockFeetStationaryDelay = 0.25f;
    }
}
