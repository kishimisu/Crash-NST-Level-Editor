namespace Alchemy
{
    [ObjectAttr(96, 8)]
    public class igGuiVisualizer : igObject
    {
        [FieldAttr(16)] public bool _drawEnable;
        [FieldAttr(17)] public bool _drawFontNames;
        [FieldAttr(18)] public bool _drawScreenSafe;
        [FieldAttr(19)] public bool _fitToScreen;
        [FieldAttr(20)] public bool _printEnable;
        [FieldAttr(24, false)] public igGuiContext? _context;
        [FieldAttr(32)] public igAABox? _globalBoundMain;
        [FieldAttr(40)] public igAABox? _globalBoundSub;
        [FieldAttr(48)] public igVectorMetaField<igGuiPlaceable> _placeables = new();
        [FieldAttr(72)] public igVec3fMetaField _scaleMain = new();
        [FieldAttr(84)] public igVec3fMetaField _scaleSub = new();
    }
}
