namespace Alchemy
{
    [ObjectAttr(192, 16)]
    public class CIridescentParametersAttr : igVisualAttribute
    {
        [FieldAttr(32)] public igVec4fMetaField _oneDivKeyRange = new();
        [FieldAttr(48)] public igVec4fMetaField _startDivKeyRange = new();
        [FieldAttr(64)] public float _metalness = 1.0f;
        [FieldAttr(68)] public float _gloss = 0.8f;
        [FieldAttr(72)] public float _emissive;
        [FieldAttr(76)] public float _distance;
        [FieldAttr(80)] public igVec4fMetaField[] _keyFrameColors = new igVec4fMetaField[5];
        [FieldAttr(160)] public float _falloffScale = 1.0f;
        [FieldAttr(164)] public float _falloffBias;
        [FieldAttr(168)] public float _falloff;
        [FieldAttr(172)] public float _overallContribution;
        [FieldAttr(176)] public bool _useNormalMap = true;
        [FieldAttr(177)] public bool _useHalfAngle = true;
        [FieldAttr(178)] public bool _useFixedHalfAngle = true;
    }
}
