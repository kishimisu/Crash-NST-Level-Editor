namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class igCommandStreamEncoder : igObject
    {
        [FieldAttr(16)] public igSortKeyCommandInterpreter? _interpreter;
        [FieldAttr(24)] public igObject[] _stream = new igObject[2];
        [FieldAttr(40)] public igBitMask? _setEncoderFunctions;
        [FieldAttr(48)] public igVectorMetaField<igRawRefMetaField> _encoderFunctionsVector = new();
        [FieldAttr(72)] public igRawRefMetaField _encoderFunctions = new();
        [FieldAttr(80)] public int _encoderFunctionsCount;
        [FieldAttr(88)] public igCommandStreamEncoderPassState? _defaultPassState;
        [FieldAttr(96)] public igCommandStreamEncoderPassState? _passState;
        [FieldAttr(104, false)] public igGraphicsMaterial? _lastMaterial;
        [FieldAttr(112, false)] public igGraphicsEffect? _lastEffect;
        [FieldAttr(120)] public int _lastTechnique = -1;
        [FieldAttr(124)] public u16 _lastTechniqueFlags;
    }
}
