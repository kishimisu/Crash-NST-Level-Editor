namespace Alchemy
{
    [ObjectAttr(40, 4)]
    public class CHavokLinearCastQueryParameters : igObject
    {
        [FieldAttr(16)] public uint _collisionFlags = 31;
        [FieldAttr(20)] public float _radius = 1.0f;
        [FieldAttr(24)] public int _maxResults = 1;
        [FieldAttr(28)] public bool _ignoreSourceEntityCollision = true;
        [FieldAttr(29)] public bool _alwaysFindClosestHit = true;
        [FieldAttr(30)] public bool _oneHitPerBody;
        [FieldAttr(31)] public bool _ignoreNoCollide;
        [FieldAttr(32)] public bool _useSourceEntityCollisionShape;
        [FieldAttr(33)] public bool _useSourceEntityCollisionFiltering;
        [FieldAttr(34)] public bool _useSourceEntityCollisionFilterAsMask;
        [FieldAttr(35)] public bool drawDebug;
    }
}
