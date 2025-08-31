namespace Alchemy
{
    [ObjectAttr(56, 8)]
    public class igTechniqueParameter : igObject
    {
        public enum EPARAMETER_TYPE : uint
        {
            PARAMETER_TYPE_MATRIX = 0,
            PARAMETER_TYPE_VECTOR = 1,
            PARAMETER_TYPE_INTEGER = 2,
            PARAMETER_TYPE_BOOL = 3,
            PARAMETER_TYPE_BOOL_ARRAY = 4,
            PARAMETER_TYPE_VECTORI = 5,
            PARAMETER_TYPE_MATRIX_ARRAY = 6,
            PARAMETER_TYPE_VECTOR_ARRAY = 7,
            PARAMETER_TYPE_INTEGER_ARRAY = 8,
            PARAMETER_TYPE_VECTORI_ARRAY = 9,
            PARAMETER_TYPE_FLOAT = 10,
            PARAMETER_TYPE_FLOAT_ARRAY = 11,
            PARAMETER_TYPE_UNKNOWN = 65535,
        }

        [FieldAttr(16)] public string? _shaderName = null;
        [FieldAttr(24)] public string? _engineName = null;
        [FieldAttr(32)] public bool _isEngine;
        [FieldAttr(36)] public EPARAMETER_TYPE _type = igTechniqueParameter.EPARAMETER_TYPE.PARAMETER_TYPE_UNKNOWN;
        [FieldAttr(40)] public int _vectorWidth = 4;
        [FieldAttr(44)] public int _elementIndex;
        [FieldAttr(48)] public int _elementSize = 1;
        [FieldAttr(52)] public int _elementCount = 1;
    }
}
