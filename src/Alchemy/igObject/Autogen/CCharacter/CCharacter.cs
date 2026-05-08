namespace Alchemy
{
    [ObjectAttr(nst: 48, ctr: 40, align: 8)]
    public class CCharacter : igObject
    {
        public enum EState
        {
            eS_Invalid = 0,
            eS_Loading = 1,
            eS_Unloading = 2,
            eS_Ready = 3,
        }

        [FieldAttr(nst: 16, ctr: 12)] public EState _state;
        [FieldAttr(nst: 24, ctr: 16)] public string? _name = null;
        [FieldAttr(nst: 32, ctr: 24)] public int _loadCount;
        [FieldAttr(nst: 40, ctr: 32)] public igObject? _chunk;
    }
}
