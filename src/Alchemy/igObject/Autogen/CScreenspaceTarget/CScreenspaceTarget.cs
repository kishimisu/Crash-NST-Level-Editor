namespace Alchemy
{
    [ObjectAttr(72, 8)]
    public class CScreenspaceTarget : igObject
    {
        public enum EScreenspaceTargetShape : uint
        {
            eSSTS_Box = 0,
            eSSTS_Circle = 1,
        }

        [FieldAttr(16)] public CScreenspaceTargetShape? _shape;
        [FieldAttr(24)] public float _depth;
        [FieldAttr(32)] public igHandleMetaField _entity = new();
        [FieldAttr(40)] public bool _isVisible;
        [FieldAttr(41)] public bool _isOnScreen;
        [FieldAttr(42)] public bool _isObscured;
        [FieldAttr(43)] public bool _isInRange;
        [FieldAttr(44)] public igVec3fMetaField _cachedEntityCenter = new();
        [FieldAttr(56)] public uint _updateIndex;
        [FieldAttr(64, false)] public CHavokQuery? _obscuredQuery;
    }
}
