namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CFilterMethod : igObject
    {
        public enum EQueryFilterType : uint
        {
            EQFT_OnlyKeepResultsInQuery = 0,
            EQFT_RemoveResultsFromQuery = 1,
        }

        [FieldAttr(16)] public EQueryFilterType _filterType;
    }
}
