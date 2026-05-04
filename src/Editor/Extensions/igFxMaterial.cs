using Alchemy;
using System.Reflection;

namespace NST
{
    /// <summary>
    /// Extensions for igMaterial objects
    /// </summary>
    public static class igMaterialExtensions
    {
        /// <summary>
        /// Find the path of the material's diffuse texture file
        /// </summary>
        public static NamedReference? FindDiffuseTexture(this igMaterial material)
        {
            if (material.GetType() == typeof(CWaterMaterial) || material.GetType() == typeof(CFlowWaterMaterial))
            {
                return null;
            }

            const string fieldName = "_textureName_diffuse";

            FieldInfo? field = material.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
            string? formattedPath = null;

            if (field != null)
            {
                string diffusePath = (string)field.GetValue(material)!;
                formattedPath = diffusePath.Replace(":", "@").Replace("\\", "!").Replace("/", "!").Replace(".", "`");
            }

            igGraphicsMaterial? graphicsMaterial = material as igGraphicsMaterial ?? (material as igFxMaterial)?._graphicsMaterial;

            List<NamedReference>? diffuseFileNames = graphicsMaterial?._graphicsObjects?._objects
                .Select(e =>
                {
                    if (e is not igGraphicsTexture attr) return null;
                    
                    string? fileName = attr._imageHandle.Reference?.namespaceName;

                    if (string.IsNullOrEmpty(formattedPath))
                    {
                        if (fileName?.StartsWith("ColorMap") == true)
                        {
                            return attr._imageHandle.Reference;
                        }
                    }
                    else if (fileName?.Contains(formattedPath) == true) // || fileName?.StartsWith("CavityBakedColorMap") == true)
                    {
                        return attr._imageHandle.Reference;
                    }

                    return null;
                })
                .Where(e => e != null)
                .Cast<NamedReference>()
                .ToList();

            if (diffuseFileNames == null || diffuseFileNames.Count == 0)
            {
                Console.Error.WriteLine($"No igGraphicsTexture attribute found on type {material.GetType().Name} for path: {formattedPath}.");
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
                // Console.Error.WriteLine($"Warning: Color field not found on type {igMaterial.GetType().Name}.");
                return new THREE.Vector4(1, 1, 1, 1);
            }

            igVec4fMetaField color = (igVec4fMetaField)field.GetValue(igMaterial)!;

            return new THREE.Vector4(color._x, color._y, color._z, color._w);
        }

        public static THREE.Vector4 FindColor(this igGraphicsMaterial igMaterial)
        {
            if (igMaterial._commonState == null || igMaterial._commonState._memory.Count < 28 * 4 || igMaterial._commonState._memory[16 * 4] != 30) 
                return new THREE.Vector4(1, 1, 1, 1);

            byte[] data = igMaterial._commonState._memory.ToArray();

            float r = BitConverter.ToSingle(data, 24 * 4);
            float g = BitConverter.ToSingle(data, 25 * 4);
            float b = BitConverter.ToSingle(data, 26 * 4);
            float a = BitConverter.ToSingle(data, 27 * 4);

            return new THREE.Vector4(r, g, b, a);
        }
    }
}
