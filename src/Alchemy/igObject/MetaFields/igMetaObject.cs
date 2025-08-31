namespace Alchemy
{
    public class igMetaObject : igObject 
    {
        /// <summary>
        /// Get the parent class/type referenced by this MetaObject
        /// </summary>
        public Type GetMetaObjectType()
        {
            NamedReference? reference = GetReference();

            if (reference == null) throw new Exception("igMetaObject has no reference!");

            string typeName = reference.objectName.Replace(".", "_");

            return Type.GetType($"Alchemy.{typeName}")
                ?? Type.GetType($"Alchemy.{reference.namespaceName}_{typeName}")
                ?? throw new Exception($"Failed to find dynamic object of type {reference} ({typeName})");
        }
    }
}