namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CGuiEventInfoMessage : igGuiEvent
    {
        public enum EInfoMessageState : uint
        {
            eIMS_None = 0,
            eIMS_Loading = 1,
            eIMS_SkipAttempt = 2,
            eIMS_SkipWait = 3,
            eIMS_Paused = 4,
        }

        [FieldAttr(24)] public EInfoMessageState _state;
    }
}
