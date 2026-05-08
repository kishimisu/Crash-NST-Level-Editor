namespace Alchemy
{
    [ObjectAttr(nst: 112, ctr: 104, align: 4, metaType: typeof(CVscComponentData))]
    public class common_CutsceneSequencePlayerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsSkipFadeOn;
        [FieldAttr(nst: 41, ctr: 33)] public bool _IsDebugCameraHoldForeverOn;
        [FieldAttr(nst: 42, ctr: 34)] public bool _ExcludeStartingCheckpoint;
        [FieldAttr(nst: 43, ctr: 35)] public bool _IsPlayOnStart;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Starting_Checkpoint = new();
        [FieldAttr(nst: 56, ctr: 48)] public igHandleMetaField _CutscenePreset = new();
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _DesignCutsceneIdentifier = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _CutsceneSequenceShotList = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _FadeInPreset = new();
        [FieldAttr(nst: 88, ctr: 80)] public igHandleMetaField _SkipFadePreset = new();
        [FieldAttr(nst: 96, ctr: 88)] public float _OnCutsceneDoneCameraBlendOutTime;
        [FieldAttr(nst: 100, ctr: 92)] public igKeyboardInputDevice.ESignal _DebugKeyboardGoNextCameraShot;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _Sound = new();
    }
}
