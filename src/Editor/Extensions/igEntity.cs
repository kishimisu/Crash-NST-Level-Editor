using Alchemy;

namespace NST
{
    /// <summary>
    /// Extension methods for igEntity objects
    /// </summary>
    public static class igEntityExtensions
    {
        /// <summary>
        /// Find the first child component of type T
        /// </summary>
        public static T? GetComponent<T>(this igEntity entity) where T : igComponentData
        {
            return (T?)entity._entityData?._componentData?._values.Find(e => e is T);
        }
    }
}