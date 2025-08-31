namespace Alchemy
{
    [ObjectAttr(384, 16)]
    public class CForwardLitRenderPassData : igForwardLitRenderPassData
    {
        [FieldAttr(128)] public float _localShadowInfluence;
        [FieldAttr(132)] public igVfxRangedCurveMetaField _diffuseEnvColorRed = new();
        [FieldAttr(216)] public igVfxRangedCurveMetaField _diffuseEnvColorGreen = new();
        [FieldAttr(300)] public igVfxRangedCurveMetaField _diffuseEnvColorBlue = new();
    }
}
