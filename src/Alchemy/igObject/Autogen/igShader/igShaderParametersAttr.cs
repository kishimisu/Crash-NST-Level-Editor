namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igShaderParametersAttr : igVisualAttribute
    {
        [FieldAttr(24)] public int _unitID = -1;
        [FieldAttr(32)] public igShaderConstantDataList? _dataList;
    }
}
