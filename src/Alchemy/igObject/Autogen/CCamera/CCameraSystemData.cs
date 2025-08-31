namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CCameraSystemData : igObject
    {
        [FieldAttr(16)] public CEntityData? _dummyEntityData;
        [FieldAttr(24)] public CCameraZoomSystem? _cameraZoomSystem;
    }
}
