namespace Alchemy
{
    [ObjectAttr(88, 8, metaType: typeof(CVehicleVfxHandler))]
    public class CVehicleVfxHandler : CBehaviorLogic
    {
        [FieldAttr(80)] public CVehicleVfxHandlerDataList? _effects;
    }
}
