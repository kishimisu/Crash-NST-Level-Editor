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
        /// Find all textures referenced by this material (diffuse, normal, gloss, metal, height...)
        /// </summary>
        /// <param name="references">The dictionary to add new texture references to</param>
        public static void FindTextureReferences(this igMaterial material, Dictionary<string, NamedReference> references)
        {
            var graphicsMaterial = material as igGraphicsMaterial ?? (material as igFxMaterial)?._graphicsMaterial;
            if (graphicsMaterial?._graphicsObjects == null) return;

            Dictionary<NamedReference, List<string>> graphicsTextures = [];

            foreach (var obj in graphicsMaterial._graphicsObjects._objects._data)
            {
                if (obj is not igGraphicsTexture attr || attr._imageHandle.Reference == null) continue;

                string? fileName = attr._imageHandle.Reference.namespaceName;
                if (fileName == null) continue;

                graphicsTextures.Add(attr._imageHandle.Reference, ExpandFileNames(fileName));
            }

            if (graphicsTextures.Count == 0) return;

            const string prefix = "_textureName_";

            var textureFields = material
                .GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Instance)
                .Where(f => f.Name.StartsWith(prefix));

            if (!textureFields.Any()) // CTR:NF support
            {
                var diffuseRef = graphicsTextures.Keys.FirstOrDefault(e => e.namespaceName.StartsWith("ColorMap"));

                if (diffuseRef != null)
                {
                    references.Add("diffuse", diffuseRef);
                }

                return;
            }

            foreach (var field in textureFields)
            {
                string? texturePath = (string?)field.GetValue(material);
                if (string.IsNullOrEmpty(texturePath)) continue;

                string textureName = NamespaceUtils.GetFileName(texturePath, false);
                if (textureName.StartsWith("default_")) continue;

                string textureType = field.Name.Substring(prefix.Length);

                foreach (var (textureRef, parts) in graphicsTextures)
                {
                    if (parts.Any(p => p.Contains(textureName, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        references.Add(textureType, textureRef);
                        break;
                    }
                }
            }
        }

        private static List<string> ExpandFileNames(string input)
        {
            int open = input.LastIndexOf('{');

            if (open == -1)
                return [ input ];

            int close = input.IndexOf('}', open);
            if (close == -1)
            {
                Console.WriteLine("Warning: unmatched '{'.");
                return [ input ];
            }

            string prefix = input[..open];
            string suffix = input[(close + 1)..];

            string contents = input[(open + 1)..close];
            string[] parts = contents.Split(',');

            var result = new List<string>();

            foreach (string part in parts)
            {
                string expanded = prefix + part + suffix;
                result.AddRange(ExpandFileNames(expanded));
            }

            return result;
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
