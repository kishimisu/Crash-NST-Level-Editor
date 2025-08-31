namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CSoundBankListComponentData : igComponentData
    {
        [FieldAttr(24)] public CAudioArchiveHandleList? _soundBankHandleList;
    }
}
