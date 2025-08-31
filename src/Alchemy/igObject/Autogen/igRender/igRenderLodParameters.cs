namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class igRenderLodParameters : igObject
    {
        [FieldAttr(16)] public float _shaderLodDistance = -1.0f;
        [FieldAttr(20)] public float _shaderLodFadeAmount = 0.3f;
    }
}
