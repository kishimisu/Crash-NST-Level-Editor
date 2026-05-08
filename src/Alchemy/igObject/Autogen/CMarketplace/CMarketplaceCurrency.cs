namespace Alchemy
{
    [ObjectAttr(nst: 32, ctr: 24, align: 8)]
    public class CMarketplaceCurrency : igObject
    {
        [FieldAttr(nst: 16, ctr: 12)] public uint _id;
        [FieldAttr(nst: 24, ctr: 16)] public string? _currencyCode = null;
    }
}
