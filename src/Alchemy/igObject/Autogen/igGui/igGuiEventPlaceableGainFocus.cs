namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class igGuiEventPlaceableGainFocus : igGuiEvent
    {
        [FieldAttr(24)] public igGuiInput.EController _control = igGuiInput.EController.kController1 | igGuiInput.EController.kController2 | igGuiInput.EController.kController3 | igGuiInput.EController.kController4 | igGuiInput.EController.kController5 | igGuiInput.EController.kController6 | igGuiInput.EController.kController7 | igGuiInput.EController.kController8;
    }
}
