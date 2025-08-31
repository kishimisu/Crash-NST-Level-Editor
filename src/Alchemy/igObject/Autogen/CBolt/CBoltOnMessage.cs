namespace Alchemy
{
    [ObjectAttr(64, 8, metaType: typeof(CBoltOnMessage))]
    public class CBoltOnMessage : CEntityMessage
    {
        [FieldAttr(56)] public bool _bolt;
        [FieldAttr(60)] public EBoltonModels _boltonModels = EBoltonModels.EBOLTON_NONE;
    }
}
