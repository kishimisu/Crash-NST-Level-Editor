namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class CVfxEnvironmentColorOperator : igVfxOperator
    {
        [ObjectAttr(4)]
        public class EnvironmentColorFlags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 3)] public EModulation _colorModulation = EModulation.kModulate;
            [FieldAttr(3, size: 1)] public bool _useEnvironmentColor = false;
            [FieldAttr(4, size: 1)] public bool _useSunColor = false;
            [FieldAttr(5, size: 1)] public bool _useOverrideCamera;
            [FieldAttr(6, size: 3)] public igVfxManager.EVfxCamera _overrideCamera;
        }

        [FieldAttr(24)] public EnvironmentColorFlags _environmentColorFlags = new();
    }
}
