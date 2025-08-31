namespace Alchemy
{
    [ObjectAttr(112, 8)]
    public class CScreenspaceTargetManager : CManager
    {
        public enum EScreenspaceTargetListType : uint
        {
            eSTLT_Default = 0,
            eSTLT_Gearbit = 1,
        }

        [FieldAttr(16)] public CScreenspaceTargetList? _defaultTargets;
        [FieldAttr(24)] public CScreenspaceTargetList? _gearbitTargets;
        [FieldAttr(32)] public int[] _defaultUpdateIndices = new int[2];
        [FieldAttr(40)] public int[] _gearbitUpdateIndices = new int[4];
        [FieldAttr(56)] public bool _debugDrawBoxesEnabled;
        [FieldAttr(64)] public igAABox? _tempWorldBox;
        [FieldAttr(72)] public igAABox? _tempScreenBox;
        [FieldAttr(80)] public float _maxDefaultTargetRange = 15000.0f;
        [FieldAttr(84)] public float _maxGearbitTargetRange = 1.0f;
        [FieldAttr(88)] public int _numberOfTargetsOnScreen;
        [FieldAttr(96)] public COnScreenspaceTargetManagerPostUpdateDelegate? _onPostUpdate;
        [FieldAttr(104)] public COnScreenspaceTargetManagerPostUpdateEventList? _onPostUpdateEventList;
    }
}
