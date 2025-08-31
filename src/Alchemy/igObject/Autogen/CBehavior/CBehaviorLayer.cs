namespace Alchemy
{
    [ObjectAttr(32, 8)]
    public class CBehaviorLayer : igNamedObject
    {
        [FieldAttr(24)] public int _layerIndex = -1;
        [FieldAttr(28)] public bool _registeredWithLayerGenerator;
    }
}
