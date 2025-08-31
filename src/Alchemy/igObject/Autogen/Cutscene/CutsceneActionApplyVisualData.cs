namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CutsceneActionApplyVisualData : CCutsceneAction
    {
        [FieldAttr(24)] public float _duration = 2.0f;
        [FieldAttr(32)] public CVisualDataGroup? _data;
    }
}
