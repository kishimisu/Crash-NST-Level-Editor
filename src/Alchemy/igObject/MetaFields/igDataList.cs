using System.Collections;

namespace Alchemy
{
    [ObjectAttr(40, 8)]
    public class igDataList : igContainer
    {
        [FieldAttr(16)] public int _count;
        [FieldAttr(20)] public int _capacity;

        public override void Write(IgzWriter writer)
        {
            CachedFieldAttr? dataField = AttributeUtils.GetAttributes(GetType()).GetField("_data");

            if (dataField != null && dataField.GetValue(this) is IMemoryRef mem)
            {
                _count = _capacity = mem.Count;
            }

            base.Write(writer);
        }
    }
}
