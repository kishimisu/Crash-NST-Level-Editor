namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class CHeroShadowData : igObject
    {
        [FieldAttr(16)] public float _blendDistance = 96.0f;
        [FieldAttr(20)] public float _volumeSlack = 6.0f;
    }
}
