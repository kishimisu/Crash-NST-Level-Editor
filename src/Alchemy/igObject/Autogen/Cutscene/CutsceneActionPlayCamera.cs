namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class CutsceneActionPlayCamera : CCutsceneAction
    {
        [FieldAttr(24)] public CCutsceneCamera? _camera;
        [FieldAttr(32)] public int _shotNumber;
        [FieldAttr(36)] public float _shotStartTime;
        [FieldAttr(40)] public float _shotDuration;
    }
}
