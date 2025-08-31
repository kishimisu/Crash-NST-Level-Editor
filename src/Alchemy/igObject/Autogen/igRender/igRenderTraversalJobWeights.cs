namespace Alchemy
{
    [ObjectAttr(24, 4)]
    public class igRenderTraversalJobWeights : igObject
    {
        [FieldAttr(16)] public int _minWeight = 100;
        [FieldAttr(20)] public int _maxWeight = 200;
    }
}
