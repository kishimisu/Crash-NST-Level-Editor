namespace Alchemy
{
    [ObjectAttr(152, 8)]
    public class CScriptTriggerEntityData : CGameEntityData
    {
        public enum EAabbMode : uint
        {
            eAM_Never = 0,
            eAM_Auto = 1,
            eAM_Always = 2,
        }

        [FieldAttr(128)] public uint _actFlags;
        [FieldAttr(132)] public uint _scriptTriggerFlags = 128;
        [FieldAttr(136)] public bool _attachedPlayersCanTrigger;
        [FieldAttr(140)] public EAabbMode _aabbMode = CScriptTriggerEntityData.EAabbMode.eAM_Auto;
        [FieldAttr(144)] public bool _networkEnabled;
    }
}
