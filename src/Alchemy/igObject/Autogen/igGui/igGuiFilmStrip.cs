namespace Alchemy
{
    [ObjectAttr(88, 16)]
    public class igGuiFilmStrip : igGuiSprite
    {
        [FieldAttr(64)] public float _rows = 1.0f;
        [FieldAttr(68)] public float _columns = 1.0f;
        [FieldAttr(72)] public float _fps = 30.0f;
        [FieldAttr(76)] public EigGuiAnimationLoopMode _loopMode;
        [FieldAttr(80)] public float _frame;
        [FieldAttr(84)] public float _velocity = 1.0f;
    }
}
