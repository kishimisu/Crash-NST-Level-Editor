namespace Alchemy
{
    [ObjectAttr(48, 8)]
    public class JuiceActionKeyframe : JuiceKeyframe
    {
        [FieldAttr(24)] public JuiceAction? _action;
        [FieldAttr(32)] public igCinematicObject? _object;
        [FieldAttr(40)] public igObject? _actionRuntimeData;
    }
}
