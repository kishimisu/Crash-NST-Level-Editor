namespace Alchemy
{
    [ObjectAttr(296, 4)]
    public class igVfxAnimatedFrame : igObject
    {
        public enum EAnimatedFrameLoopMode : uint
        {
            kLoopNone = 0,
            kLoopLoop = 1,
            kLoopPingPong = 2,
            kLoopReverse = 3,
        }

        public enum EAnimatedFrameRotation : uint
        {
            kRotationNone = 0,
            kRotation90 = 1,
            kRotation180 = 2,
            kRotation270 = 3,
            kRotationRandom = 4,
        }

        public enum EAnimatedFrameMirror : uint
        {
            kMirrorNone = 0,
            kMirrorReverse = 1,
            kMirrorRandom = 2,
        }

        [ObjectAttr(2)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(0, size: 2)] public igVfxAnimatedFrame.EAnimatedFrameLoopMode _loopMode = igVfxAnimatedFrame.EAnimatedFrameLoopMode.kLoopLoop;
            [FieldAttr(2, size: 3)] public igVfxAnimatedFrame.EAnimatedFrameRotation _uvRotation;
            [FieldAttr(5, size: 2)] public igVfxAnimatedFrame.EAnimatedFrameMirror _uMirror;
            [FieldAttr(7, size: 2)] public igVfxAnimatedFrame.EAnimatedFrameMirror _vMirror;
            [FieldAttr(9, size: 1)] public bool _enabled;
            [FieldAttr(10, size: 1)] public bool _randomStart;
            [FieldAttr(11, size: 1)] public bool _uvScrollEnabled;
        }

        [FieldAttr(16)] public Flags _flags = new();
        [FieldAttr(20)] public igVfxRangedCurveMetaField _framesPerSecond = new();
        [FieldAttr(104)] public u8 _rows = 1;
        [FieldAttr(105)] public u8 _columns = 1;
        [FieldAttr(108)] public float _scrollTime;
        [FieldAttr(112)] public igVfxRangedCurveMetaField _uScrollOffset = new();
        [FieldAttr(196)] public igVfxRangedCurveMetaField _vScrollOffset = new();
        [FieldAttr(280)] public bool _useFrameRange;
        [FieldAttr(284)] public uint _startFrame;
        [FieldAttr(288)] public uint _endFrame;
    }
}
