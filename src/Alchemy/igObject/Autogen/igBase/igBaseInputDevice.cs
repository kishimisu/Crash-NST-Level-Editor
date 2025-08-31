namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igBaseInputDevice : igObject
    {
        [FieldAttr(16)] public int _id = -1;
        [FieldAttr(20)] public bool _anySignalsChanged;
        [FieldAttr(24)] public igFloatList? _signals;
        [FieldAttr(32)] public igBoolList? _signalsChanged;
    }
}
