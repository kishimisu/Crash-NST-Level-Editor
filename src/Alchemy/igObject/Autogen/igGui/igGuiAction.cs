namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class igGuiAction : igObject
    {
        [FieldAttr(16)] public bool _critical;
        [FieldAttr(20)] public float _preInvokeTime;
        [FieldAttr(24)] public float _invokeTime;
        [FieldAttr(28)] public bool _infiniteInvokeTime;
        [FieldAttr(29)] public bool _executing;
        [FieldAttr(30)] public bool _hasInvoked;
        [FieldAttr(32)] public float _executionTime;
        [FieldAttr(40)] public igHandleMetaField _ownerProject = new();
    }
}
