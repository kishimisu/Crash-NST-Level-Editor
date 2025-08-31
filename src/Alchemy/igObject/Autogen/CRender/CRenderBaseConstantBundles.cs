namespace Alchemy
{
    [ObjectAttr(128, 8)]
    public class CRenderBaseConstantBundles : igObject
    {
        [FieldAttr(16)] public igObject[] _cameraConstantBundle = new igObject[2];
        [FieldAttr(32)] public igObject[] _colorAdjustmentBundle = new igObject[2];
        [FieldAttr(48)] public igObject[] _environmentLightingBundle = new igObject[2];
        [FieldAttr(64)] public igObject[] _globalWindConstantBundle = new igObject[2];
        [FieldAttr(80)] public igObject[] _nextGenStateBundle = new igObject[2];
        [FieldAttr(96)] public igObject[] _fourkStateBundle = new igObject[2];
        [FieldAttr(112)] public igObject[] _outdoorLightConstantBundle = new igObject[2];
    }
}
