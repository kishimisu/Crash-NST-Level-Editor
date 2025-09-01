﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace THREE
{
    [Serializable]
    public class Material : IDisposable, ICloneable
    {
        private static int materialIdCount;

        public int Id = materialIdCount++;

        public Guid Uuid = Guid.NewGuid();

        public Hashtable Defines = new Hashtable();

        public string Name;

        public string type = "Material";

        public bool Fog = true;

        public int Blending = Constants.NormalBlending;

        public int Side = Constants.FrontSide;

        public bool FlatShading = false;

        public bool VertexTangents = false;

        public bool VertexColors = false;

        public float Opacity = 1;

        public bool Transparent = false;

        public Color? Color;

        public Color Specular;

        public int BlendSrc = Constants.SrcAlphaFactor;

        public int BlendDst = Constants.OneMinusSrcAlphaFactor;

        public int BlendEquation = Constants.AddEquation;

        public int? BlendSrcAlpha;

        public int? BlendDstAlpha;

        public int? BlendEquationAlpha;

        public int DepthFunc = Constants.LessEqualDepth;

        public bool DepthTest = true;

        public bool DepthWrite = true;

        public int StencilWriteMask = 0xff;

        public int StencilFunc = Constants.AlwaysStencilFunc;

        public int StencilRef = 0;

        public int StencilFuncMask = 0xff;

        public int StencilFail = Constants.KeepStencilOp;

        public int StencilZFail = Constants.KeepStencilOp;

        public int StencilZPass = Constants.KeepStencilOp;

        public bool StencilWrite = false;

        public List<Plane> ClippingPlanes = new List<Plane>();

        public bool ClipIntersection = false;

        public bool ClipShadows = false;

        public int? ShadowSide;

        public bool ColorWrite = true;

        public string Precision = null;

        public bool PolygonOffset = false;

        public float PolygonOffsetFactor = 0.0f;

        public float PolygonOffsetUnits = 0.0f;

        public bool Dithering = false;

        public float AlphaTest = 0;

        public bool PremultipliedAlpha = false;

        public bool Visible = true;

        public bool ToneMapped = true;

        public Dictionary<string,object> UserData = new Dictionary<string,object>();

        private bool needsUpdate;



        public bool NeedsUpdate
        {
            get
            {
                return needsUpdate;
            }
            set
            {
                needsUpdate = value;
                if (needsUpdate) this.Version++;
            }
        }

        public string glslVersion = "";

        public string IndexOAttributeName;

        public bool MorphTargets;

        public bool MorphNormals;

        public Texture Map;

        public Texture AlphaMap;

        public Texture SpecularMap;

        public Texture EnvMap;

        public Texture NormalMap;

        public int NormalMapType = -1;

        public Vector2 NormalScale;

        public Texture BumpMap;

        public float BumpScale;

        public Texture LightMap;

        public Texture AoMap;

        public Texture EmissiveMap;

        public Texture DisplacementMap;

        public float DisplacementScale;

        public float DisplacementBias;

        public float Clearcoat;

        public Texture ClearcoatMap;

        public float ClearcoatRoughness;

        public Texture ClearcoatRoughnessMap;

        public Vector2 ClearcoatNormalScale;

        public Texture ClearcoatNormalMap;

        public Texture RoughnessMap;

        public Texture MetalnessMap;

        public Texture GradientMap;

        public Texture TransmissionMap;

        public Color? Sheen;

        public Color? Emissive;

        public float EmissiveIntensity = 1;

        public int Combine;

        public bool SizeAttenuation;

        public bool Skinning;

        public int DepthPacking = Constants.BasicDepthPacking;

        public IGLProgram Program;

        public int numSupportedMorphTargets = 0;

        public int numSupportedMorphNormals = 0;

        public bool Clipping = false;

        public float Rotation = 0;

        public float Reflectivity = 1;

        public float RefractionRatio;

        public float LightMapIntensity = 1;

        public float AoMapIntensity = 1;

        public float EnvMapIntensity = 1;

        public float LineWidth = 1;

        public bool Wireframe;

        public float WireframeLineWidth = 1;

        public string WireframeLineCap;

        public string WireframeLineJoin;

        public float Shininess;

        public int Version = 0;

        public float Roughness = 0.5f;

        public float Metalness = 0.5f;

        public float Transmission = 0.0f;

        public float Thickness = 0.01f;

        public Texture ThicknessMap = null;

        public float AttenuationDistance = 0.0f;

        public Color AttenuationColor = new Color(1, 1, 1);

        public event EventHandler<EventArgs> Disposed;

        public Action<Hashtable, IGLRenderer> OnBeforeCompile;
        public Action<Hashtable, IGLRenderer> OnBuild;

        public Material()
        {
        }
        public Material(SerializationInfo info, StreamingContext context) { }

        protected Material(Material source) : base()
        {
            Copy(source);
        }


        public virtual object Clone()
        {
            var material = new Material();
            material.Copy(this);

            return material;
        }
        public virtual object Copy(Material source)
        {
            type = source.type;

            Defines = source.Defines.Clone() as Hashtable;

            Name = source.Name;

            Fog = source.Fog;

            Blending = source.Blending;

            Side = source.Side;

            FlatShading = source.FlatShading;

            VertexTangents = source.VertexTangents;

            VertexColors = source.VertexColors;

            Opacity = source.Opacity;

            Transparent = source.Transparent;

            if (source.Color != null) Color = source.Color.Value;

            Specular = source.Specular;



            BlendSrc = source.BlendSrc;

            BlendDst = source.BlendDst;

            BlendEquation = source.BlendEquation;

            if (source.BlendSrcAlpha != null) BlendSrcAlpha = source.BlendSrcAlpha.Value;
            if (source.BlendDstAlpha != null) BlendDstAlpha = source.BlendDstAlpha.Value;
            if (source.BlendEquationAlpha != null) BlendEquationAlpha = source.BlendEquationAlpha.Value;


            DepthFunc = source.DepthFunc;

            DepthTest = source.DepthTest;

            DepthWrite = source.DepthWrite;

            StencilWriteMask = source.StencilWriteMask;

            StencilFunc = source.StencilFunc;

            StencilRef = source.StencilRef;

            StencilFuncMask = source.StencilRef;

            StencilFail = source.StencilFail;

            StencilZFail = source.StencilZFail;

            StencilZPass = source.StencilZPass;

            StencilWrite = source.StencilWrite;

            ClippingPlanes = source.ClippingPlanes.ToList();

            ClipIntersection = source.ClipIntersection;

            ClipShadows = source.ClipShadows;

            ShadowSide = source.ShadowSide;

            ColorWrite = source.ColorWrite;

            Precision = source.Precision;

            PolygonOffset = source.PolygonOffset;

            PolygonOffsetFactor = source.PolygonOffsetFactor;

            PolygonOffsetUnits = source.PolygonOffsetUnits;

            Dithering = source.Dithering;

            AlphaTest = source.AlphaTest;

            PremultipliedAlpha = source.PremultipliedAlpha;

            Visible = source.Visible;

            ToneMapped = source.ToneMapped;

            UserData = source.UserData.DeepCopy();

            NeedsUpdate = source.NeedsUpdate;

            glslVersion = source.glslVersion;

            IndexOAttributeName = source.IndexOAttributeName;

            MorphTargets = source.MorphTargets;

            MorphNormals = source.MorphNormals;

            if (source.Map != null)
                Map = (Texture)source.Map.Clone();

            if (source.AlphaMap != null)
                AlphaMap = (Texture)source.AlphaMap.Clone();

            if (source.SpecularMap != null)
                SpecularMap = (Texture)source.SpecularMap.Clone();

            if (source.EnvMap != null)
                EnvMap = (Texture)source.EnvMap.Clone();

            if (source.NormalMap != null)
                NormalMap = (Texture)source.NormalMap.Clone();

            NormalMapType = source.NormalMapType;

            if (source.NormalScale != null)
                NormalScale = source.NormalScale.Clone();

            if (source.BumpMap != null)
                BumpMap = (Texture)source.BumpMap.Clone();

            BumpScale = source.BumpScale;

            if (source.LightMap != null)
                LightMap = (Texture)source.LightMap.Clone();

            if (source.AoMap != null)
                AoMap = (Texture)source.AoMap.Clone();

            if (source.EmissiveMap != null)
                EmissiveMap = (Texture)source.EmissiveMap.Clone();

            if (source.DisplacementMap != null)
                DisplacementMap = (Texture)source.DisplacementMap.Clone();

            DisplacementScale = source.DisplacementScale;

            DisplacementBias = source.DisplacementBias;

            Clearcoat = source.Clearcoat;

            if (source.ClearcoatMap != null)
                ClearcoatMap = (Texture)source.ClearcoatMap.Clone();

            ClearcoatRoughness = source.ClearcoatRoughness;

            if (source.ClearcoatRoughnessMap != null)
                ClearcoatRoughnessMap = (Texture)source.ClearcoatRoughnessMap.Clone();

            if (source.ClearcoatNormalScale != null)
                ClearcoatNormalScale = source.ClearcoatNormalScale.Clone();

            if (source.ClearcoatNormalMap != null)
                ClearcoatNormalMap = (Texture)source.ClearcoatNormalMap.Clone();

            if (source.RoughnessMap != null)
                RoughnessMap = (Texture)source.RoughnessMap.Clone();

            if (source.MetalnessMap != null)
                MetalnessMap = (Texture)source.MetalnessMap.Clone();

            if (source.GradientMap != null)
                GradientMap = (Texture)source.GradientMap.Clone();

            if (source.TransmissionMap != null)
                TransmissionMap = (Texture)source.TransmissionMap.Clone();

            Sheen = source.Sheen;

            Emissive = source.Emissive;

            EmissiveIntensity = source.EmissiveIntensity;

            Combine = source.Combine;

            SizeAttenuation = source.SizeAttenuation;

            Skinning = source.Skinning;

            DepthPacking = source.DepthPacking;

            numSupportedMorphTargets = source.numSupportedMorphTargets;

            numSupportedMorphNormals = source.numSupportedMorphNormals;

            Clipping = source.Clipping;

            Rotation = source.Rotation;

            Reflectivity = source.Reflectivity;

            RefractionRatio = source.RefractionRatio;

            LightMapIntensity = source.LightMapIntensity;

            AoMapIntensity = source.AoMapIntensity;

            EnvMapIntensity = source.EnvMapIntensity;

            LineWidth = source.LineWidth;

            Wireframe = source.Wireframe;

            WireframeLineWidth = source.WireframeLineWidth;

            WireframeLineCap = source.WireframeLineCap;

            WireframeLineJoin = source.WireframeLineJoin;

            Shininess = source.Shininess;

            Version = source.Version;

            Roughness = source.Roughness;

            Metalness = source.Metalness;

            return this;
        }
        protected void SetValues(Hashtable values)
        {
            if (values == null)
                return;

            foreach (DictionaryEntry item in values)
            {
                var newValue = item.Value;
                var key = item.Key as string;

                var type = this.GetType();
                var propertyInfo = type.GetProperty(key, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(this, newValue);
                }
                else
                {
                    var fieldInfo = type.GetField(key, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.IgnoreCase);
                    if (fieldInfo != null)
                    {
                        fieldInfo.SetValue(this, newValue);
                    }
                    else
                    {
                        Trace.TraceWarning("attribute {0} not found", key);
                    }
                }
            }
        }

        ~Material()
        {
            this.Dispose(false);
        }
        public string customProgramCacheKey;
        public virtual void Dispose()
        {
            Dispose(disposed);
        }
        protected virtual void RaiseDisposed()
        {
            var handler = this.Disposed;
            if (handler != null)
                handler(this, new EventArgs());
        }

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
            try
            {
                this.RaiseDisposed();
                this.disposed = true;
            }
            finally
            {

            }
            this.disposed = true;
        }
    }
}
