namespace Alchemy
{
    [ObjectAttr(24)]
    public class igVectorMetaField<T> : igRefMetaField
    {
        [FieldAttr(0)] public int _elementCount;
        [FieldAttr(8)] public igMemoryRef<T> _data  = new();

        public T this[int index]
        {
            get => _data[index];
            set => _data[index] = value;
        }
        public int Count => _data.Count;
        public List<T> FindAll(Predicate<T> predicate) => _data.FindAll(predicate);
        public IEnumerable<TOut> Select<TOut>(Func<T, TOut> selector) => _data.Select(selector);
        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
    }
}
