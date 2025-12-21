namespace Alchemy
{
    [ObjectAttr(24)]
    public class igVectorMetaField<T> : igRefMetaField, IMemoryRef
    {
        [FieldAttr(0)] public int _elementCount;
        [FieldAttr(8)] public igMemoryRef<T> _data  = new();

        public T this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }
        public int Count => _data.Count;
        public MemoryPool MemoryPool { get => _data.MemoryPool; set => _data.MemoryPool = value; }
        public IEnumerable<TOut> Select<TOut>(Func<T, TOut> selector) => _data.Select(selector);
        public void Clear() => _data.Clear();

        public override void Write(IgzWriter writer)
        {
            _elementCount = _data.Count;
            base.Write(writer);
        }
    }
}
