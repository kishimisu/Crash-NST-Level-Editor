namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CVehicleTutorialComponentData : CEntityComponentData
    {
        public enum EVehicleTutorialType : uint
        {
            eVTT_None = 0,
            eVTT_Sea = 1,
            eVTT_Air = 2,
            eVTT_Coop = 3,
        }

        [FieldAttr(24)] public EVehicleTutorialType _tutorialType;
        [FieldAttr(32)] public igHandleMetaField _pauseMenuFocusedOptionOverride = new();
    }
}
