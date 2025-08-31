namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CutsceneLightsAction : CCutsceneAction
    {
        [FieldAttr(24)] public igEntityHandleList? _lights;
    }
}
