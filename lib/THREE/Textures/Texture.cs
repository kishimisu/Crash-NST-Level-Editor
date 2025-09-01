﻿using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace THREE
{
    [Serializable]
    public class MipMap
    {
        public byte[] Data;

        public int Width;

        public int Height;

        public MipMap() { }

        public MipMap(MipMap other)
        {
            if (other.Data.Length > 0)
                this.Data = other.Data.ToArray();
        }
        public MipMap Clone()
        {
            return new MipMap(this);
        }
    }

    [Serializable]
    public class Texture : DisposableObject,ICloneable
    {
        #region Static Fields

        protected static int TextureIdCount;

        #endregion

        #region Fields

        public int Id = TextureIdCount++;

        public Guid Uuid = Guid.NewGuid();

        public string Name = "";

        public Size Resolution { get; protected set; } // this fields are not existed in three.js

        //public TextureTarget TextureTarget { get; private set; }// this fields are not existed in three.js

        public int TextureAddress { get; protected set; }


        public SKBitmap Image;

        public Texture[] Images = new Texture[] { null, null, null, null, null, null };

        public List<MipMap> Mipmaps = new List<MipMap>();

        public Size ImageSize;

        public int Mapping = Constants.UVMapping;

        public int WrapS;
        public int WrapT;
        public int WrapR;

        public int MagFilter;
        public int MinFilter;
        public int MaxFilter;

        public float Anisotropy;

        public int Format = (int)Constants.RGBAFormat;
        public int Type;

        public Vector2 Offset = new Vector2(0, 0);
        public Vector2 Repeat = new Vector2(1, 1);
        public Vector2 Center = new Vector2(0, 0);
        public float Rotation = 0;

        public bool MatrixAutoUpdate = true;
        public Matrix3 Matrix = new Matrix3();

        public bool GenerateMipmaps = true;
        public bool PremultiplyAlpha = false;
        public bool flipY = true;
        public int UnpackAlignment = 4;

        private bool needsUpdate;

        public bool NeedsUpdate
        {
            get { return needsUpdate; }
            set
            {
                needsUpdate = value;
                if (value == true) version++;
            }
        }

        public string InternalFormat = null;

        public int Encoding = Constants.LinearEncoding;

        public int version = 0;

        public string SourceFilePath;


        private readonly int defaultMapping = Constants.UVMapping;

        public bool NeedsFlipEnvMap = false;
        #endregion


        //public bool __glInit = false;

        //public int __glTexture { get; set; }

        //public int __version;

        #region Constructors and Destructors

        public Texture()
        {
            this.Anisotropy = 1;

            this.WrapS = (int)Constants.ClampToEdgeWrapping;

            this.WrapT = (int)Constants.ClampToEdgeWrapping;

            this.MagFilter = (int)Constants.LinearFilter;

            this.MinFilter = (int)Constants.LinearMipMapLinearFilter;

            this.Type = (int)Constants.UnsignedByteType;

        }

        //public Texture(string bitmapPath, bool flipY = true)
        //{
        //    this.SourceFilePath = bitmapPath;

        //    using (var bitmap = Bitmap.FromFile(bitmapPath) as Bitmap)
        //    {
        //        HandleLoadingBitmapData(bitmap, flipY);
        //    }
        //}
        /// <summary>
        /// Constructor
        /// </summary>
        public Texture(SKBitmap image = null, int? mapping = null, int? wrapS = null, int? wrapT = null, int? magFilter = null, int? minFilter = null, int? format = null, int? type = null, int? anisotropy = null, int? encoding = null)
            : this()
        {

            this.Image = image;

            this.Mapping = mapping != null ? (int)mapping : this.defaultMapping;

            this.WrapS = wrapS != null ? (int)wrapS : Constants.ClampToEdgeWrapping;
            this.WrapT = wrapT != null ? (int)wrapT : Constants.ClampToEdgeWrapping;

            this.MagFilter = magFilter != null ? (int)magFilter : Constants.LinearFilter;
            this.MinFilter = minFilter != null ? (int)minFilter : Constants.LinearMipmapLinearFilter;

            this.Anisotropy = anisotropy != null ? (int)anisotropy : 1;

            this.Format = format != null ? (int)format : Constants.RGBAFormat;
            this.InternalFormat = null;
            this.Type = type != null ? (int)type : Constants.UnsignedByteType;

            this.Encoding = encoding != null ? (int)encoding : Constants.LinearEncoding;

        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="other"></param>
        protected Texture(Texture other) : this()
        {
            this.Image = other.Image;
            //this.Image = other.Image!=null ? (Bitmap)other.Image.Clone() : null;

            this.ImageSize = other.ImageSize;
            this.Images = other.Images;
            //if(other.Images.Length>0)
            //{
            //    for (int i = 0; i < other.Images.Length; i++)
            //        this.Images[i] = other.Images[i] != null ? (Texture)other.Images[i].Clone() : null;
            //}

            this.Mipmaps = other.Mipmaps;
            //this.Mipmaps = other.Mipmaps.Select(item => (MipMap)item.Clone()).ToList();

            this.Mapping = other.Mapping;

            this.WrapS = other.WrapS;
            this.WrapT = other.WrapT;

            this.MagFilter = other.MagFilter;
            this.MinFilter = other.MinFilter;

            this.Anisotropy = other.Anisotropy;

            this.Format = other.Format;
            this.InternalFormat = other.InternalFormat;
            this.Type = other.Type;

            this.Encoding = other.Encoding;

            this.version = other.version;
        }

        #endregion

        public void UpdateMatrix()
        {
            this.Matrix.SetUvTransform(this.Offset.X, this.Offset.Y, this.Repeat.X, this.Repeat.Y, this.Rotation, this.Center.X, this.Center.Y);
        }

        public virtual object Clone()
        {
            return new Texture(this);
        }
    }
}
