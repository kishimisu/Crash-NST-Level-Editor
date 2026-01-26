using Alchemy;
using ImGuiNET;
using SkiaSharp;
using System.Runtime.InteropServices;

namespace NST
{
    /// <summary>
    /// Convenience wrapper around an igFxMaterial to have access to all properties at once and build THREE materials
    /// </summary>
    public class NSTMaterial
    {
        public Type type; // Material type
        public NamedReference? materialHandle; // igFxMaterial reference
        public NamedReference? diffuseTexture = null; // igImage2 reference
        public THREE.Texture? texture = null; // GPU diffuse texture

        public string shaderName = "";

        public EigDrawType drawType = EigDrawType.kDrawTypeOpaque;

        public bool alphaTest = false;
        public float alphaRef = 0.5f;

        public bool blending = false;
        public EIG_GFX_BLENDING_FUNCTION srcBlend = EIG_GFX_BLENDING_FUNCTION.SOURCE_ALPHA;
        public EIG_GFX_BLENDING_FUNCTION dstBlend = EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_SOURCE_ALPHA;
        public EIG_GFX_BLENDING_EQUATION blendEquation = EIG_GFX_BLENDING_EQUATION.ADD;

        public bool culling = true;
        public EIG_GFX_CULL_FACE_MODE cullFace = EIG_GFX_CULL_FACE_MODE.BACK;

        public bool depthTest = true;
        public bool depthWrite = true;

        public EIG_GFX_TEXTURE_WRAP wrapS = EIG_GFX_TEXTURE_WRAP.REPEAT;
        public EIG_GFX_TEXTURE_WRAP wrapT = EIG_GFX_TEXTURE_WRAP.REPEAT;

        public EIG_GFX_TEXTURE_FILTER minFilter = EIG_GFX_TEXTURE_FILTER.LINEAR_MIPMAP_LINEAR;
        public EIG_GFX_TEXTURE_FILTER magFilter = EIG_GFX_TEXTURE_FILTER.LINEAR;

        public bool editorOnly = false;

        public THREE.Vector4 color = new THREE.Vector4(1, 1, 1, 1);

        public static float DefaultShininess = 5.0f;

        private static readonly Dictionary<EIG_GFX_BLENDING_FUNCTION, int> _BLENDING_FACTOR_MAP = new()
        {
            { EIG_GFX_BLENDING_FUNCTION.DESTINATION_ALPHA, THREE.Constants.DstAlphaFactor },
            { EIG_GFX_BLENDING_FUNCTION.DESTINATION_COLOR, THREE.Constants.DstColorFactor },
            { EIG_GFX_BLENDING_FUNCTION.ONE, THREE.Constants.OneFactor },
            { EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_DESTINATION_ALPHA, THREE.Constants.OneMinusDstAlphaFactor },
            { EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_DESTINATION_COLOR, THREE.Constants.OneMinusDstColorFactor },
            { EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_SOURCE_ALPHA, THREE.Constants.OneMinusSrcAlphaFactor },
            { EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_SOURCE_COLOR, THREE.Constants.OneMinusSrcColorFactor },
            { EIG_GFX_BLENDING_FUNCTION.SOURCE_ALPHA, THREE.Constants.SrcAlphaFactor },
            { EIG_GFX_BLENDING_FUNCTION.SOURCE_ALPHA_SATURATE, THREE.Constants.SrcAlphaSaturateFactor },
            { EIG_GFX_BLENDING_FUNCTION.SOURCE_COLOR, THREE.Constants.SrcColorFactor },
            { EIG_GFX_BLENDING_FUNCTION.ZERO, THREE.Constants.ZeroFactor },
        };

        private static readonly Dictionary<EIG_GFX_BLENDING_EQUATION, int> _BLENDING_EQUATION_MAP = new()
        {
            { EIG_GFX_BLENDING_EQUATION.ADD, THREE.Constants.AddEquation },
            { EIG_GFX_BLENDING_EQUATION.MAX, THREE.Constants.MaxEquation },
            { EIG_GFX_BLENDING_EQUATION.MIN, THREE.Constants.MinEquation },
            { EIG_GFX_BLENDING_EQUATION.SUBTRACT, THREE.Constants.SubtractEquation },
            { EIG_GFX_BLENDING_EQUATION.REVERSE_SUBTRACT, THREE.Constants.ReverseSubtractEquation },
        };

        private static readonly Dictionary<EIG_GFX_CULL_FACE_MODE, int> _CULL_FACE_MAP = new()
        {
            { EIG_GFX_CULL_FACE_MODE.BACK, THREE.Constants.FrontSide },
            { EIG_GFX_CULL_FACE_MODE.FRONT, THREE.Constants.BackSide },
        };

        private static readonly Dictionary<EIG_GFX_TEXTURE_WRAP, int> _TEXTURE_WRAP_MAP = new()
        {
            { EIG_GFX_TEXTURE_WRAP.CLAMP, THREE.Constants.ClampToEdgeWrapping },
            { EIG_GFX_TEXTURE_WRAP.REPEAT, THREE.Constants.RepeatWrapping },
            { EIG_GFX_TEXTURE_WRAP.BORDER, THREE.Constants.ClampToEdgeWrapping },
            { EIG_GFX_TEXTURE_WRAP.REGION_CLAMP, THREE.Constants.ClampToEdgeWrapping },
            { EIG_GFX_TEXTURE_WRAP.REGION_REPEAT, THREE.Constants.MirroredRepeatWrapping },
        };

        private static readonly Dictionary<EIG_GFX_TEXTURE_FILTER, int> _TEXTURE_FILTER_MAP = new()
        {
            { EIG_GFX_TEXTURE_FILTER.NEAREST, THREE.Constants.NearestFilter },
            { EIG_GFX_TEXTURE_FILTER.LINEAR, THREE.Constants.LinearFilter },
            { EIG_GFX_TEXTURE_FILTER.NEAREST_MIPMAP_NEAREST, THREE.Constants.NearestMipmapNearestFilter },
            { EIG_GFX_TEXTURE_FILTER.NEAREST_MIPMAP_LINEAR, THREE.Constants.NearestMipmapLinearFilter },
            { EIG_GFX_TEXTURE_FILTER.LINEAR_MIPMAP_NEAREST, THREE.Constants.LinearMipmapNearestFilter },
            { EIG_GFX_TEXTURE_FILTER.LINEAR_MIPMAP_LINEAR, THREE.Constants.LinearMipmapLinearFilter },
            { EIG_GFX_TEXTURE_FILTER.ANISOTROPIC, THREE.Constants.LinearFilter },
            { EIG_GFX_TEXTURE_FILTER.ANISOTROPIC_MIPMAP_NEAREST, THREE.Constants.LinearMipmapNearestFilter },
            { EIG_GFX_TEXTURE_FILTER.ANISOTROPIC_MIPMAP_LINEAR, THREE.Constants.LinearMipmapLinearFilter },
        };

        public NSTMaterial() { }
        public NSTMaterial(igFxMaterial igMaterial)
        {
            SetupFromIgFxMaterial(igMaterial);
        }

        /// <summary>
        /// Initializes the material properties from an igFxMaterial
        /// </summary>
        private void SetupFromIgFxMaterial(igFxMaterial igMaterial)
        {
            alphaRef       = igMaterial._alphaRefValue;
            alphaTest      = igMaterial._customMaterialBitfield._alphaTestState;
            blending       = igMaterial._customMaterialBitfield._blendingState;
            srcBlend       = igMaterial._customMaterialBitfield._blendingSource;
            dstBlend       = igMaterial._customMaterialBitfield._blendingDestination;
            blendEquation  = igMaterial._customMaterialBitfield._blendingEquation;
            culling        = igMaterial._customMaterialBitfield._cullFaceState;
            cullFace       = igMaterial._customMaterialBitfield._cullFaceMode;
            depthTest      = igMaterial._customMaterialBitfield._depthTestState;
            depthWrite     = igMaterial._customMaterialBitfield._depthWriteState;
            wrapS          = igMaterial._customMaterialBitfield._wrapS;
            wrapT          = igMaterial._customMaterialBitfield._wrapT;
            minFilter      = igMaterial._customMaterialBitfield2._minificationFilter;
            magFilter      = igMaterial._customMaterialBitfield2._magnificationFilter;
            drawType       = igMaterial._graphicsMaterial?._materialBitField._drawType ?? EigDrawType.kDrawTypeOpaque;
            editorOnly     = igMaterial is CUnlitMaterial unlit && unlit._onlyDrawInTools;
            shaderName     = igMaterial._fxFilename ?? "";
            type           = igMaterial.GetType();
            color          = igMaterial.FindColor();
            diffuseTexture = igMaterial.FindDiffuseTexture();
        }

        /// <summary>
        /// Finds the material's diffuse texture
        /// </summary>
        /// <param name="archive">The parent archive if open (searched first to improve performance)</param>
        /// <returns>The texture's data</returns>
        private TextureData? FindDiffuseTexture(IgArchive? archive = null)
        {
            if (diffuseTexture == null) return null;

            igImage2? image = (igImage2?)AlchemyUtils.FindObjectInArchives(diffuseTexture, archive);

            if (image == null || !image.HasPixels())
            {
                if (image == null) Console.Error.WriteLine($"Warning: igImage2 object not found for {diffuseTexture}.");
                else if (!image.HasPixels()) Console.Error.WriteLine($"Warning: No pixels found for {diffuseTexture}.");
                return null;
            }

            TextureData data = new TextureData()
            {
                pixels = image.GetPixels(),
                width = image._width,
                height = image._height,
            };

            return data;
        }

        /// <summary>
        /// Initializes the material and its textures from the material handle
        /// </summary>
        /// <param name="archive"></param>
        public void InititializeMaterialAndTextures(IgArchive? archive = null)
        {
            if (materialHandle == null)
            {
                Console.Error.WriteLine("Warning: Cannot initialize material, handle is null.");
                return;
            }

            InitializeMaterial(materialHandle, archive);
            InitializeTexture(archive);
        }

        /// <summary>
        /// Initializes the material using a named reference
        /// </summary>
        /// <param name="materialHandle">The reference to the igFxMaterial</param>
        /// <param name="archive">The parent archive if open (searched first to improve performance)</param>
        private void InitializeMaterial(NamedReference materialHandle, IgArchive? archive = null)
        {
            igObject obj = AlchemyUtils.FindObjectInArchives(materialHandle, archive);

            if (obj is not igFxMaterial igMaterial)
            {
                Console.Error.WriteLine("Warning: Material is not a igFxMaterial: " + obj.GetType());
                return;
            }
            
            SetupFromIgFxMaterial(igMaterial);
        }

        /// <summary>
        /// Initializes the material's diffuse texture for GPU rendering
        /// </summary>
        /// <param name="archive">The parent archive if open (searched first to improve performance)</param>
        private void InitializeTexture(IgArchive? archive = null)
        {
            TextureData? textureData = FindDiffuseTexture(archive);

            if (textureData == null)
            {
                Console.Error.WriteLine($"Warning: Diffuse texture not found for material {materialHandle}.");
                return;
            }

            CreateThreeTexture(textureData);
        }

        /// <summary>
        /// Create a THREE.Texture using the provided textureData
        /// </summary>
        public THREE.Texture CreateThreeTexture(TextureData textureData)
        {
            SKBitmap bitmap = new SKBitmap(textureData.width, textureData.height, SKColorType.Rgba8888, SKAlphaType.Unpremul);
            Marshal.Copy(textureData.pixels, 0, bitmap.GetPixels(), textureData.pixels.Length);

            texture = new THREE.Texture(bitmap) { NeedsUpdate = true };

            return texture;
        }

        /// <summary>
        /// Create a THREE.Material using the current material properties
        /// </summary>
        public THREE.Material CreateThreeMaterial(int drawCallIndex = 0)
        {
            if (type == null) // Drawcall has no material
                return new THREE.MeshPhongMaterial() { Shininess = DefaultShininess };

            THREE.Material material = type.IsAssignableTo(typeof(CUnlitMaterial)) || type == typeof(CCloudParticleSortedMaterial)
                ? new THREE.MeshBasicMaterial()
                : new THREE.MeshPhongMaterial();

            if (blending)
            {
                material.Transparent = true;
                material.Opacity = Math.Clamp(color.W * 1.5f, 0, 1);
                material.BlendEquation = _BLENDING_EQUATION_MAP[blendEquation];
                material.BlendSrc = _BLENDING_FACTOR_MAP[srcBlend];
                material.BlendDst = _BLENDING_FACTOR_MAP[dstBlend];
            }
            else
            {
                material.BlendEquation = THREE.Constants.AddEquation;
                material.BlendSrc = THREE.Constants.OneFactor;
                material.BlendDst = THREE.Constants.ZeroFactor;
            }

            material.Blending = THREE.Constants.CustomBlending;
            material.BlendEquationAlpha = THREE.Constants.AddEquation;
            material.BlendSrcAlpha = THREE.Constants.ZeroFactor;
            material.BlendDstAlpha = THREE.Constants.OneFactor;

            material.Side = !culling ? THREE.Constants.DoubleSide : _CULL_FACE_MAP[cullFace];

            material.DepthTest = depthTest;
            material.DepthWrite = depthWrite;

            if (alphaTest) 
            {
                material.AlphaTest = alphaRef;
            }

            material.Metalness = 0;
            material.Roughness = 0;
            material.Shininess = DefaultShininess;
            material.Color = new THREE.Color(color.X, color.Y, color.Z);

            if (type.IsAssignableTo(typeof(CBlendedDecalMaterial))) 
            {
                material.PolygonOffset = true;
                material.PolygonOffsetFactor = -1.0f * (drawCallIndex+1);
                material.PolygonOffsetUnits = 1.0f;
            }

            if (type == typeof(CFlowWaterMaterial) || type == typeof(CWaterMaterial))
            {
                material.Opacity = 0.5f;
                material.Transparent = true;
                material.BlendSrc = THREE.Constants.SrcAlphaFactor;
                material.BlendDst = THREE.Constants.OneMinusSrcAlphaFactor;
            }
            else if (type == typeof(CUnlitRimMaterial))
            {
                material.Opacity = 0.5f;
            }

            if (texture != null)
            {
                material.Map = (THREE.Texture)texture.Clone();
                material.Map.WrapS = _TEXTURE_WRAP_MAP[wrapS];
                material.Map.WrapT = _TEXTURE_WRAP_MAP[wrapT];
                material.Map.MinFilter = _TEXTURE_FILTER_MAP[minFilter];
                material.Map.MagFilter = _TEXTURE_FILTER_MAP[magFilter];
            }

            if (editorOnly) material.Visible = false;

            return material;
        }

        /// <summary>
        /// Renders the material using ImGui
        /// </summary>
        public void Render(IgzRenderer renderer, IgzTreeNode node, bool renderName)
        {
            if (renderName)
            {
                if (ImGui.Selectable("##OpenNode" + GetHashCode()))
                {
                    renderer.TreeView.SetSelectedNode(node); // Select parent node (drawcall / material)
                }
                ImGui.SameLine();
                node.RenderObjectName();
            }

            if (node.Object is igModelDrawCallData drawCallData) // Model file
            {
                NamedReference? reference = drawCallData._materialHandle.Reference;

                if (reference != null)
                {
                    if (ImGui.Selectable("##OpenMaterial" + GetHashCode()))
                    {
                        App.FocusObject(reference, renderer); // (Model file only) Open material file
                    }
                    ImGui.SameLine();

                    ImGui.Text($"> Material:");
                    ImGui.SameLine();

                    ImGui.TextColored(MathUtils.UIntToVector4Numerics(type.GetUniqueColor()), type.Name);
                    ImGui.SameLine();

                    ImGui.Text(reference?.objectName ?? "");
                }
                else
                {
                    ImGui.Indent();
                    ImGui.Text("> No material");
                    ImGui.Unindent();
                }
            }

            if (diffuseTexture != null)
            {
                if (ImGui.Selectable("##OpenTexture" + GetHashCode()))
                {
                    App.FocusObject(diffuseTexture, renderer); // Open diffuse texture file
                }
                ImGui.SameLine();
                ImGui.Text($"> Diffuse:");
                ImGui.SameLine();
                ImGui.TextColored(MathUtils.UIntToVector4Numerics(0xffff90f4), diffuseTexture.namespaceName);
            }

            if (alphaTest && alphaRef != 0.5f)
                ImGui.BulletText($"Alpha Clip Threshold: {alphaRef}");

            if (blending && (srcBlend != EIG_GFX_BLENDING_FUNCTION.SOURCE_ALPHA || dstBlend != EIG_GFX_BLENDING_FUNCTION.ONE_MINUS_SOURCE_ALPHA || blendEquation != EIG_GFX_BLENDING_EQUATION.ADD))
                ImGui.BulletText($"Blending | src: {srcBlend}, dst: {dstBlend}, func: {blendEquation}");

            if (!culling)
                ImGui.BulletText($"Culling: {culling}");
            else if (cullFace != EIG_GFX_CULL_FACE_MODE.BACK)
                ImGui.BulletText($"Culling | Cull Face: {cullFace}");

            if (drawType != EigDrawType.kDrawTypeOpaque)
                ImGui.BulletText($"Draw Type: {drawType}");

            if (!depthTest)
                ImGui.BulletText($"Depth Test: {depthTest}");

            if (!depthWrite && drawType != EigDrawType.kDrawTypeTransparent)
                ImGui.BulletText($"Depth Write: {depthWrite}");

            if (wrapS != EIG_GFX_TEXTURE_WRAP.REPEAT || wrapT != EIG_GFX_TEXTURE_WRAP.REPEAT)
                ImGui.BulletText($"Wrap S: {wrapS} | Wrap T: {wrapT}");

            if (minFilter != EIG_GFX_TEXTURE_FILTER.LINEAR_MIPMAP_LINEAR || magFilter != EIG_GFX_TEXTURE_FILTER.LINEAR)
                ImGui.BulletText($"Min Filter: {minFilter} | Mag Filter: {magFilter}");

            if (editorOnly)
                ImGui.BulletText($"Only draw in editor: {editorOnly}");

            if (color.X != 1 || color.Y != 1 || color.Z != 1 || color.W != 1)
            {
                ImGui.BulletText($"Color:");
                ImGui.SameLine();
                ImGui.ColorButton("##" + GetHashCode(), new System.Numerics.Vector4(color.X, color.Y, color.Z, color.W));
            }

            ImGui.Separator();
            ImGui.Spacing();
        }
    }
}