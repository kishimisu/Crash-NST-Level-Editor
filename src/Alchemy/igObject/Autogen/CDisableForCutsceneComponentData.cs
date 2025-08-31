namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CDisableForCutsceneComponentData : igComponentData
    {
        [FieldAttr(24)] public EDisableInCutsceneBehavior _disableMode;
        [FieldAttr(32)] public igStringRefList? _cutsceneList;
    }
}
