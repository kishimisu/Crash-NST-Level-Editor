namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGuiEventInput : igGuiEvent
    {
        [FieldAttr(24)] public igGuiInput.ESignal _signal;
        [FieldAttr(28)] public igGuiInput.EController _control;
    }
}
