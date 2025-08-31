namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxCameraBaseOperator : igVfxOperator
    {
        [FieldAttr(24)] public float _startDistance = 500.0f;
        [FieldAttr(28)] public float _endDistance;
    }
}
