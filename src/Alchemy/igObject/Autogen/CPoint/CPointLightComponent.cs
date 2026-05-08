namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 56, align: 8)]
    public class CPointLightComponent : igComponent
    {
        [ObjectAttr(size: 4)]
        public class Flags : igBitFieldMetaField
        {
            [FieldAttr(offset: 0, size: 1)] public bool _lightState = true;
            [FieldAttr(offset: 1, size: 1)] public bool _lightModified;
        }

        [FieldAttr(nst: 40, ctr: 40)] public igRenderPointLight? _light;
        [FieldAttr(nst: 48, ctr: 48)] public Flags _flags = new();
        [FieldAttr(nst: 52, ctr: 52)] public bool _lightComponentEnabled = true;
    }
}
