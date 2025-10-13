namespace Alchemy
{
    [ObjectAttr(16, 8)]
    public class igQuaternionfMetaField : igVec4fMetaField
    {
        public igQuaternionfMetaField() : base(0, 0, 0, 1) { }
        public igQuaternionfMetaField(float x = 0, float y = 0, float z = 0, float w = 1) : base(x, y, z, w) { }
    }
}
