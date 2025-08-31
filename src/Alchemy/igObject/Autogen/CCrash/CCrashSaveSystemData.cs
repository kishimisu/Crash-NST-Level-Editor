namespace Alchemy
{
    [ObjectAttr(64, 8)]
    public class CCrashSaveSystemData : CSaveSystemData
    {
        [FieldAttr(32)] public int _saveSlotsPerGame = 4;
        [FieldAttr(40)] public string? _mostRecentSaveSlotKeyCrash1 = "most_recent_save_slot_crash1";
        [FieldAttr(48)] public string? _mostRecentSaveSlotKeyCrash2 = "most_recent_save_slot_crash2";
        [FieldAttr(56)] public string? _mostRecentSaveSlotKeyCrash3 = "most_recent_save_slot_crash3";
    }
}
