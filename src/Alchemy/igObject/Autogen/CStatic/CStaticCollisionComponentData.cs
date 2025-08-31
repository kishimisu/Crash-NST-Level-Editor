namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class CStaticCollisionComponentData : igComponentData
    {
        [ObjectAttr(4)]
        public class FlagsBitfield : igBitFieldMetaField
        {
            [FieldAttr(0, size: 1)] public bool _disableCollision;
            [FieldAttr(1, size: 1)] public bool _enableNavMesh;
        }

        [FieldAttr(24)] public FlagsBitfield _flagsBitfield = new();
        [FieldAttr(32)] public igHandleMetaField _collisionMaterial = new();
    }
}
