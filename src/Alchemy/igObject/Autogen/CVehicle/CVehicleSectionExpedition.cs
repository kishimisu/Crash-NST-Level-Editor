namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class CVehicleSectionExpedition : CVehicleSection
    {
        [FieldAttr(72)] public bool _sea2dMovement = true;
        [FieldAttr(73)] public bool _playIntroAnimation = true;
        [FieldAttr(80)] public CEntityHandleList? _targetEntities;
        [FieldAttr(88)] public bool _disableWrongWay;
    }
}
