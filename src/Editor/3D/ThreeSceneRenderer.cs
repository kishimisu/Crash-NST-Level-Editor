using THREE;
using THREE.Silk;

namespace NST
{
    /// <summary>
    /// Base class for rendering 3D scenes using THREE.Silk
    /// </summary>
    public class ThreeSceneRenderer : ControlsContainer
    {
        protected GLRenderer _renderer;
        protected Scene _scene;
        protected Camera _camera;
        protected IControls _controls;

        private GLRenderTarget _renderTarget;
        protected EffectComposer _composer;
        protected OutlinePass _outlinePass;
    
        protected int _width;
        protected int _height;
        private bool _alwaysRender = false;

        public enum RebuildStatus { None, NeedsRebuild, Rebuild }
        public RebuildStatus RebuildState { get; set; } = RebuildStatus.None;
        public bool RenderNextFrame { get; set; } = true;

        public override THREE.Rectangle GetClientRectangle() => new THREE.Rectangle(0, 0, _width, _height);

        public ThreeSceneRenderer(int width = 1280, int height = 720, bool useEffectComposer = true, bool alwaysRender = true)
        {
            _width = width;
            _height = height;
            _alwaysRender = alwaysRender;

            _renderer = new GLRenderer(SilkWindow.instance._window, _width, _height);

            _renderTarget = new GLRenderTarget(_width, _height);

            THREE.Color backgroundColor = THREE.Color.Hex(0x0078b4);

            _scene = new Scene();
            _scene.Background = backgroundColor;
            _scene.Fog = new Fog(backgroundColor, 0.00004f);

            _camera = new PerspectiveCamera(60.0f, _width / (float)_height, 1.0f, 10000.0f);
            _camera.Position = new THREE.Vector3(0, 0, 5);
            _camera.LookAt(new THREE.Vector3(0, 0, 0));

            if (useEffectComposer)
            {
                _outlinePass = new OutlinePass(new THREE.Vector2(_width, _height), _scene, _camera);

                _composer = new EffectComposer(_renderer, _renderTarget);
                _composer.AddPass(new RenderPass(_scene, _camera));
                _composer.AddPass(new ShaderPass(new CopyShader()));
                _composer.AddPass(_outlinePass);
                _composer.RenderToScreen = false;
            }

            SilkWindow.instance.controls.Add(this);
        }

        /// <summary>
        /// Resize the renderer
        /// </summary>
        public void Resize(int width, int height)
        {
            _width = width;
            _height = height;

            _camera.Aspect = width / (float)height;
            _camera.UpdateProjectionMatrix();

            _renderTarget.Dispose();
            _renderTarget = new GLRenderTarget(width, height);

            _renderer.SetRenderTarget(_renderTarget);
            _renderer.SetSize(width, height);
            
            _composer?.Reset(_renderTarget);

            RenderNextFrame = true;

            base.OnResize(new ResizeEventArgs(width, height));
        }

        /// <summary>
        /// Render the scene to a texture
        /// </summary>
        public virtual void Render(double? deltaTime = null)
        {
            if (!_alwaysRender && !RenderNextFrame && !_controls.Focused()) return;

            if (CheckRebuildStatus()) return;

            SilkWindow.instance.SetViewport(0, 0, _width, _height);

            _controls.Update(deltaTime);

            if (_composer != null)
            {
                _composer.Render();
                _composer.SwapBuffers();
                _renderer.SetRenderTarget(null!);
            }
            else
            {
                _renderer.SetRenderTarget(_renderTarget);
                _renderer.SetClearColor(0xffffff, 1);
                _renderer.Render(_scene, _camera);
                _renderer.SetRenderTarget(null!);
            }

            RenderNextFrame = false;

            SilkWindow.instance.RestoreViewport();
        }

        /// <summary>
        /// Check if the current GL renderer should be rebuilt after another renderer has been disposed
        /// </summary>
        private bool CheckRebuildStatus()
        {
            if (RebuildState == RebuildStatus.NeedsRebuild)
            {
                RenderNextFrame = true;
                RebuildState = RebuildStatus.Rebuild;
                return true;
            }

            if (RebuildState == RebuildStatus.Rebuild)
            {
                _renderer.Dispose();
                _renderer.InitGLContext();
                RebuildState = RebuildStatus.None;
            }

            return false;
        }

        /// <summary>
        /// Draw the rendered image to the screen
        /// </summary>
        public System.Numerics.Vector4 DrawImage(float heightRatio = 1.0f, System.Numerics.Vector4? tint = null)
        {
            uint renderTargetTextureId = _composer == null
                ? (uint)_renderer.properties.Get(_renderTarget.Texture)["glTexture"]!
                : (uint)_renderer.properties.Get(_composer.RenderTarget1.Texture)["glTexture"]!;

            return TextureHelper.RenderImageFittingParentWidth((int)renderTargetTextureId, _width, _height, heightRatio, tint);
        }

        public override void Dispose()
        {
            base.Dispose();
            _renderTarget?.Dispose();
            _renderer?.Dispose();
            SilkWindow.instance.RestoreViewport();
        }
    }
}