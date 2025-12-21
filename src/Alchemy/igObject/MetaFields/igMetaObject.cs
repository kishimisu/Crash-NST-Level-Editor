namespace Alchemy
{
    public class igMetaObject : igObject 
    {
        /// <summary>
        /// Get the parent class/type referenced by this MetaObject
        /// </summary>
        public Type GetMetaObjectType()
        {
            if (Reference == null) throw new Exception("igMetaObject has no reference!");

            string typeName = Reference.objectName.Replace(".", "_");

            return Type.GetType($"Alchemy.{typeName}")
                ?? Type.GetType($"Alchemy.{Reference.namespaceName}")
                ?? Type.GetType($"Alchemy.{Reference.namespaceName}_{typeName}")
                ?? throw new Exception($"Failed to find dynamic object of type {Reference} ({typeName})");
        }
    }
}