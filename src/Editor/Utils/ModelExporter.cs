using NST;
using Alchemy;
using Assimp;
using System.Text.Json.Nodes;

public static class ModelExporter
{
    private static Dictionary<string, Dictionary<string, dynamic>> _materialProperties = [];

    private static void AddMaterialProperty(Material material, string property, dynamic value)
    {
        if (!_materialProperties.TryGetValue(material.Name, out var properties))
        {
            properties = [];
            _materialProperties.Add(material.Name, properties);
        }

        if (!properties.TryAdd(property, value))
        {
            properties[property] = value;
        }
    }

    public static void Export(IgArchive archive, NSTModel model)
    {
        string? directory = FileExplorer.SelectFolder();
        if (directory == null) return;

        ModalRenderer.ShowLoadingModal($"Exporting {model.Name}.gltf...");

        CrashHandler.TryRunTask($"exporting .gltf file", () =>
        {
            string outputDir = Path.Combine(directory, model.Name);

            Export(archive, [(model, new(), "")], model.Name, outputDir);

            ModalRenderer.CloseLoadingModal();
        });
    }

    public static void Export(LevelExplorer explorer)
    {
        string? directory = FileExplorer.SelectFolder();
        if (directory == null) return;

        string archiveName = SanitizeFilePath(explorer.Archive.GetName(false));

        CrashHandler.TryRunTask($"exporting .gltf file", () =>
        {
            List<(NSTModel, THREE.Matrix4, string)> objects = [];

            foreach (var entity in explorer.InstanceManager.AllEntities)
            {
                if (entity.Model == null || !entity.IsSpawned) continue;
                objects.Add((entity.Model, entity.ObjectToWorld(true), entity.Object.ObjectName!));
            }

            string outputDir = Path.Combine(directory, archiveName);

            Export(explorer.Archive, objects, archiveName, outputDir);

            ModalRenderer.CloseLoadingModal();
        });
    }

    private static void Export(IgArchive archive, List<(NSTModel, THREE.Matrix4, string)> objects, string name, string outputDir)
    {
        string textureDir = Path.Combine(outputDir, "textures");

        Directory.CreateDirectory(textureDir);

        var scene = new Scene();
        var root = new Node(name)
        {
            Transform = ToMatrix4(new THREE.Matrix4().Set(
                1,  0,  0, 0,
                0,  0,  1, 0,
                0, -1,  0, 0,
                0,  0,  0, 1
            ))
        };

        Dictionary<NamedReference, int> materials = [];

        _materialProperties.Clear();

        for (int i = 0; i < objects.Count; i++)
        {
            (var model, var transform, var objectName) = objects[i];

            var group = root;

            if (objects.Count > 1)
            {
                ModalRenderer.ShowLoadingModal($"Exporting {name}.gltf ({i+1}/{objects.Count})...");

                group = new Node(objectName)
                {
                    Transform = ToMatrix4(transform, StaticCollisionsUtils.HAVOK_SCALE)
                };
                root.Children.Add(group);
            }

            foreach (var mesh in model.Meshes)
            {
                if (mesh.materialHandle == null) continue;
                if (materials.ContainsKey(mesh.materialHandle)) continue;

                var material = new Material()
                {
                    Name = SanitizeFilePath($"{mesh.materialHandle}"),
                    ColorDiffuse = new (mesh.Material.color.X, mesh.Material.color.Y, mesh.Material.color.Z, 1),
                };

                if (mesh.Material.blending)
                {
                    AddMaterialProperty(material, "alphaMode", "BLEND");
                }
                else if (mesh.Material.alphaTest)
                {
                    AddMaterialProperty(material, "alphaMode", "MASK");
                    AddMaterialProperty(material, "alphaCutoff", mesh.Material.alphaRef);
                }

                var SetupTexture = (TextureType textureType, string textureTypeName) =>
                {
                    if (!mesh.Material.textureReferences.TryGetValue(textureTypeName, out var textureRef))
                        return false;

                    string texturePath = Path.Combine(textureDir, SanitizeFilePath($"{textureRef}.png"));
                    string textureName = NamespaceUtils.GetFileName(texturePath);

                    if (textureType == TextureType.Emissive)
                    {
                        material.ColorEmissive = material.ColorDiffuse;
                    }
                    
                    if (!File.Exists(texturePath))
                    {
                        var data = NSTMaterial.FindTextureData(archive, textureRef);
                        if (data == null) return false;
                        
                        bool normal = textureType == TextureType.Normals;
                        bool roughness = textureType == TextureType.Unknown;

                        TextureHelper.SaveImageToFile(data.pixels, data.width, data.height, texturePath, true, normal, roughness);
                    }

                    material.AddMaterialTexture(new TextureSlot(
                        $"textures/{textureName}", textureType, 0, 
                        TextureMapping.FromUV, 0, 1, TextureOperation.Add, 
                        TextureWrapMode.Wrap, TextureWrapMode.Wrap, 
                        textureType == TextureType.Diffuse ? (int)TextureFlags.UseAlpha : 0
                    ));

                    return true;
                };

                SetupTexture(TextureType.Diffuse, "diffuse");
                SetupTexture(TextureType.Normals, "normal");
                SetupTexture(TextureType.Emissive, "emissive");
                bool pbrSetup = SetupTexture(TextureType.Unknown, "gloss");
                if (!pbrSetup)  SetupTexture(TextureType.Unknown, "metal");

                materials.Add(mesh.materialHandle, scene.Materials.Count);

                scene.Materials.Add(material);
            }

            foreach (var m in model.Meshes)
            {
                var mesh = new Mesh($"Mesh_{m.index}", PrimitiveType.Triangle);

                if (m.materialHandle == null || !materials.TryGetValue(m.materialHandle, out int materialId))
                {
                    var material = new Material
                    {
                        Name = "Material",
                        ColorDiffuse = new (1, 1, 1, 1),
                        ColorEmissive = new (0, 0, 0, 1)
                    };
                    materialId = scene.MaterialCount;
                    scene.Materials.Add(material);
                }

                foreach (var p in m.positions)
                    mesh.Vertices.Add(new (p.X * StaticCollisionsUtils.HAVOK_SCALE, p.Y * StaticCollisionsUtils.HAVOK_SCALE, p.Z * StaticCollisionsUtils.HAVOK_SCALE));

                foreach (var n in m.normals)
                    mesh.Normals.Add(new (n.X, n.Y, n.Z));

                foreach (var uv in m.uvs)
                    mesh.TextureCoordinateChannels[0].Add(new (uv.X, 1 - uv.Y, 0)); 

                for (int j = 0; j < m.indices.Count; j += 3)
                {
                    mesh.Faces.Add(new Face([
                        (int)m.indices[j + 0],
                        (int)m.indices[j + 1],
                        (int)m.indices[j + 2]
                    ]));
                }

                mesh.MaterialIndex = materialId;
                mesh.UVComponentCount[0] = 2;

                group.MeshIndices.Add(scene.MeshCount);
                scene.Meshes.Add(mesh);
            }
        }

        scene.RootNode = root;

        string outputPath = Path.Combine(outputDir, $"{name}.gltf");

        using var context = new AssimpContext();

        var result = context.ExportFile(scene, outputPath, "gltf2", PostProcessSteps.None);

        FixGLTF(outputPath);

        if (!result)
            throw new Exception("Failed to export to .gltf");

        FileExplorer.OpenFolderInExplorer(outputDir);
    }

    private static void FixGLTF(string gltfPath)
    {
        string json = File.ReadAllText(gltfPath);

        JsonNode? root = JsonNode.Parse(json);

        if (root is not JsonObject rootObject)
            throw new Exception("Invalid .gltf file");

        if (rootObject["materials"] is not JsonArray materials)
            return;

        foreach (JsonNode? materialNode in materials)
        {
            if (materialNode is not JsonObject material)
                continue;

            if (material["pbrMetallicRoughness"] is not JsonObject pbr)
                continue;

            pbr["metallicFactor"] = 1.0f;

            string? materialName = (string?)material["name"]?.AsValue();

            if (materialName != null && _materialProperties.TryGetValue(materialName, out var properties))
            {
                foreach (var (key, value) in properties)
                {
                    material[key] = value;
                }
            }
        }

        var options = new System.Text.Json.JsonSerializerOptions
        {
            WriteIndented = true
        };

        File.WriteAllText(gltfPath, rootObject.ToJsonString(options));
    }

    private static Matrix4x4 ToMatrix4(THREE.Matrix4 m, float positionScale = 1.0f)
    {
        return new (
            m.Elements[0], m.Elements[4], m.Elements[8],  m.Elements[12] * positionScale,
            m.Elements[1], m.Elements[5], m.Elements[9],  m.Elements[13] * positionScale,
            m.Elements[2], m.Elements[6], m.Elements[10], m.Elements[14] * positionScale,
            m.Elements[3], m.Elements[7], m.Elements[11], m.Elements[15]
        );
    }

    private static string SanitizeFilePath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return string.Empty;

        char[] invalidChars = Path.GetInvalidFileNameChars();

        return string.Join(
            "_",
            path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                .Select(part => new string(part.Where(c => !invalidChars.Contains(c)).ToArray()))
                .Where(part => !string.IsNullOrEmpty(part))
        );
    }
}