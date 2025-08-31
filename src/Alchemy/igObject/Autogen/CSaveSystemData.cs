namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSaveSystemData : igObject
    {
        [FieldAttr(16)] public bool _allowSavingCheckpoints = true;
        [FieldAttr(20)] public int _autoSaveSlot;
        [FieldAttr(24)] public string? _mostRecentSaveSlotKey = "most_recent_save_slot";
    }
}
