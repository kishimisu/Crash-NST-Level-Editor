namespace Alchemy
{
    // VSC object extracted from: common_CutsceneSequenceShotHandler_c.igz

    [ObjectAttr(168, metaType: typeof(CVscComponentData))]
    public class common_CutsceneSequenceShotHandlerData : CVscComponentData
    {
        [FieldAttr(40)] public bool _IsFadeInEnable;
        [FieldAttr(41)] public bool _IsFadeOutEnable;
        [FieldAttr(42)] public bool _IsUseDialog;
        [FieldAttr(43)] public bool _IsDialogOverrideSequenceDuration;
        [FieldAttr(44)] public bool _IsCloseDialogOnSequenceShotDone;
        [FieldAttr(45)] public bool _IsCameraActiveGameplayCamera;
        [FieldAttr(48)] public igHandleMetaField _Camera = new();
        [FieldAttr(56)] public EigEaseMode _CameraEaseMode;
        [FieldAttr(60)] public EigEaseType _CameraEaseType;
        [FieldAttr(64)] public igHandleMetaField _DialogSpeaker = new();
        [FieldAttr(72)] public igHandleMetaField _FadeInPreset = new();
        [FieldAttr(80)] public igHandleMetaField _FadeOutPreset = new();
        [FieldAttr(88)] public float _SequenceDuration;
        [FieldAttr(92)] public float _DialogCadence;
        [FieldAttr(96)] public float _DelayDialogStart;
        [FieldAttr(100)] public float _CameraBlendInTime;
        [FieldAttr(104)] public igHandleMetaField _DialogLine = new();
        [FieldAttr(112)] public bool _Bool;
        [FieldAttr(120)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(128)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(136)] public EigEaseType _Ease_Type;
        [FieldAttr(140)] public float _Float_0x8c;
        [FieldAttr(144)] public float _Float_0x90;
        [FieldAttr(148)] public float _Float_0x94;
        [FieldAttr(152)] public igKeyboardInputDevice.ESignal _Keyboard_Input_Device_Signal_0x98;
        [FieldAttr(156)] public igKeyboardInputDevice.ESignal _Keyboard_Input_Device_Signal_0x9c;
        [FieldAttr(160)] public float _Float_0xa0;
    }
}
