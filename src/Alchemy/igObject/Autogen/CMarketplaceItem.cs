namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CMarketplaceItem : igObject
    {
        [ObjectAttr(4)]
        public class Bitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 14)] public uint _id;
            [FieldAttr(14, size: 1)] public bool _isGameConsumable;
            [FieldAttr(15, size: 1)] public bool _isMarketplaceConsumable = false;
            [FieldAttr(16, size: 8)] public int _rarity;
        }

        [FieldAttr(16)] public Bitfield _bitfield = new();
        [FieldAttr(24)] public string? _name = null;
        [FieldAttr(32)] public string? _description = null;
    }
}
