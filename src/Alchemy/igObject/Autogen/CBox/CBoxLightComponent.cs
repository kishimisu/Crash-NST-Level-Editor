namespace Alchemy
{
    [ObjectAttr(nst: 56, ctr: 56, align: 8)]
    public class CBoxLightComponent : igComponent
    {
        [FieldAttr(nst: 40, ctr: 40)] public CBoxLight? _light;
        [FieldAttr(nst: 48, ctr: 48)] public bool _lightState = true;
        [FieldAttr(nst: 49, ctr: 49)] public bool _lightComponentEnabled = true;
    }
}
