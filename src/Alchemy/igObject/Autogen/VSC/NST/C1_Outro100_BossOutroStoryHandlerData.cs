namespace Alchemy
{
    [ObjectAttr(nst: 72, ctr: 64, align: 4, metaType: typeof(CVscComponentData))]
    public class C1_Outro100_BossOutroStoryHandlerData : CVscComponentData
    {
        [FieldAttr(nst: 40, ctr: 32)] public igHandleMetaField _Camera_Base = new();
        [FieldAttr(nst: 48, ctr: 40)] public float _Float;
        [FieldAttr(nst: 52, ctr: 44)] public EigEaseType _Ease_Type;
        [FieldAttr(nst: 56, ctr: 48)] public EigEaseMode _Ease_Mode;
        [FieldAttr(nst: 64, ctr: 56)] public igHandleMetaField _Localized_String = new();
    }
}
