namespace Alchemy
{
    // VSC object extracted from: common_CutsceneSequencePlayer_c.igz

    [ObjectAttr(112, metaType: typeof(CVscComponentData))]
    public class common_CutsceneSequencePlayerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsSkipFadeOn;
        [FieldAttr(41)] public bool _IsDebugCameraHoldForeverOn;
        [FieldAttr(42)] public bool _ExcludeStartingCheckpoint;
        [FieldAttr(43)] public bool _IsPlayOnStart;
        [FieldAttr(48)] public igHandleMetaField _Starting_Checkpoint = new();
        [FieldAttr(56)] public igHandleMetaField _CutscenePreset = new();
        [FieldAttr(64)] public igHandleMetaField _DesignCutsceneIdentifier = new();
        [FieldAttr(72)] public igHandleMetaField _CutsceneSequenceShotList = new();
        [FieldAttr(80)] public igHandleMetaField _FadeInPreset = new();
        [FieldAttr(88)] public igHandleMetaField _SkipFadePreset = new();
        [FieldAttr(96)] public float _OnCutsceneDoneCameraBlendOutTime;
        [FieldAttr(100)] public igKeyboardInputDevice.ESignal _DebugKeyboardGoNextCameraShot;
        [FieldAttr(104)] public igHandleMetaField _Sound = new();
    }
}
