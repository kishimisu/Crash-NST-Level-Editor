namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CScreenspaceTargetCircle : CScreenspaceTargetShape
    {
        [FieldAttr(16)] public igVec2fMetaField _center = new();
        [FieldAttr(24)] public float _radius;
        [FieldAttr(28)] public float _scale = 1.0f;
    }
}
