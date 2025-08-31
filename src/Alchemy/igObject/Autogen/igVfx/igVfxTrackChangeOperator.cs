namespace Alchemy
{
    [ObjectAttr(32, 4)]
    public class igVfxTrackChangeOperator : igVfxOperator
    {
        [FieldAttr(24)] public EReferenceFrame _track = EReferenceFrame.eRF_Track1;
    }
}
