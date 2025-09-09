using Alchemy;
using System.Reflection;

namespace NST
{
    /// <summary>
    /// Extensions for igFxMaterial objects
    /// </summary>
    public static class igFxMaterialExtensions
    {
        /// <summary>
        /// Find the path of the material's diffuse texture file
        /// </summary>
        /// <returns></returns>
        public static NamedReference? FindDiffuseTexture(this igFxMaterial igMaterial)
        {
            if (igMaterial.GetType() == typeof(CWaterMaterial) || igMaterial.GetType() == typeof(CFlowWaterMaterial))
            {
                return null;
            }

            const string fieldName = "_textureName_diffuse";

            FieldInfo? field = igMaterial.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

            if (field == null)
            {
                Console.Error.WriteLine($"Warning: Diffuse texture field not found on type {igMaterial.GetType().Name}.");
                return null;
            }

            string diffusePath = (string)field.GetValue(igMaterial)!;
            string formattedPath = diffusePath.Replace(":", "@").Replace("\\", "!").Replace(".", "`");

            List<NamedReference>? diffuseFileNames = igMaterial._graphicsMaterial?._graphicsObjects?._objects
                .Select(e =>
                {
                    if (e is not igGraphicsTexture attr) return null;
                    
                    string? fileName = attr._imageHandle.GetNamespaceName();
                    
                    if (fileName?.Contains(formattedPath) == true) // || fileName?.StartsWith("CavityBakedColorMap") == true)
                    {
                        return attr._imageHandle.GetReference();
                    }

                    return null;
                })
                .Where(e => e != null)
                .Cast<NamedReference>()
                .ToList();

            if (diffuseFileNames == null || diffuseFileNames.Count == 0)
            {
                Console.Error.WriteLine($"Warning: No igGraphicsTexture attribute found on type {igMaterial.GetType().Name} for path {diffusePath}.");
                return null;
            }

            return diffuseFileNames[0]; //.FirstOrDefault(e => e.StartsWith("CavityBakedColorMap")) ?? diffuseFileNames[0];
        }

        /// <summary>
        /// Find the material's color attribute
        /// </summary>
        public static THREE.Vector4 FindColor(this igFxMaterial igMaterial)
        {
            string fieldName = "_color";

            if (igMaterial.GetType() == typeof(CWaterMaterial) || igMaterial.GetType() == typeof(CFlowWaterMaterial))
            {
                fieldName = "_deepWaterColor";
            }

            FieldInfo? field = igMaterial.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

            if (field == null)
            {
                Console.Error.WriteLine($"Warning: Color field not found on type {igMaterial.GetType().Name}.");
                return new THREE.Vector4(1, 1, 1, 1);
            }

            igVec4fMetaField color = (igVec4fMetaField)field.GetValue(igMaterial)!;

            return new THREE.Vector4(color._x, color._y, color._z, color._w);
        }
    }
}
