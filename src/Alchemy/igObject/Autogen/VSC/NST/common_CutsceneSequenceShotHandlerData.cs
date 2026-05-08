namespace Alchemy
{
    [ObjectAttr(nst: 168, ctr: 160, align: 4, metaType: typeof(CVscComponentData))]
    public class common_CutsceneSequenceShotHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public bool _IsFadeInEnable;
        [FieldAttr(nst: 41, ctr: 33)] public bool _IsFadeOutEnable;
        [FieldAttr(nst: 42, ctr: 34)] public bool _IsUseDialog;
        [FieldAttr(nst: 43, ctr: 35)] public bool _IsDialogOverrideSequenceDuration;
        [FieldAttr(nst: 44, ctr: 36)] public bool _IsCloseDialogOnSequenceShotDone;
        [FieldAttr(nst: 45, ctr: 37)] public bool _IsCameraActiveGameplayCamera;
        [FieldAttr(nst: 48, ctr: 40)] public igHandleMetaField _Camera = new();
        [FieldAttr(nst: 56, ctr: 48)] public EigEaseMode _CameraEaseMode;
        [FieldAttr(nst: 60, ctr: 52)] public EigEaseType _CameraEaseType;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _DialogSpeaker = new();
        [FieldAttr(nst: 72, ctr: 64)] public igHandleMetaField _FadeInPreset = new();
        [FieldAttr(nst: 80, ctr: 72)] public igHandleMetaField _FadeOutPreset = new();
        [FieldAttr(nst: 88, ctr: 80)] public float _SequenceDuration;
        [FieldAttr(nst: 92, ctr: 84)] public float _DialogCadence;
        [FieldAttr(nst: 96, ctr: 88)] public float _DelayDialogStart;
        [FieldAttr(nst: 100, ctr: 92)] public float _CameraBlendInTime;
        [FieldAttr(nst: 104, ctr: 96)] public igHandleMetaField _DialogLine = new();
        [FieldAttr(nst: 112, ctr: 104)] public bool _Bool;
        [FieldAttr(nst: 120, ctr: 112)] public igHandleMetaField _Entity_0x78 = new();
        [FieldAttr(nst: 128, ctr: 120)] public igHandleMetaField _Entity_0x80 = new();
        [FieldAttr(nst: 136, ctr: 128)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 140, ctr: 132)] public float _Float_0x8c;
        [FieldAttr(nst: 144, ctr: 136)] public float _Float_0x90;
        [FieldAttr(nst: 148, ctr: 140)] public float _Float_0x94;
        [FieldAttr(nst: 152, ctr: 144)] public igKeyboardInputDevice.ESignal _Keyboard_Input_Device_Signal_0x98;
        [FieldAttr(nst: 156, ctr: 148)] public igKeyboardInputDevice.ESignal _Keyboard_Input_Device_Signal_0x9c;
        [FieldAttr(nst: 160, ctr: 152)] public float _Float_0xa0;
    }
}
