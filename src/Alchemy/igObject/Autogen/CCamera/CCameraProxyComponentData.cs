namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CCameraProxyComponentData : CEntityComponentData
    {
        [FieldAttr(24)] public CCameraBase? _camera;
        [FieldAttr(32)] public bool _activateOnEnable;
    }
}
