using THREE;
using THREE.Silk;

namespace NST
{
    /// <summary>
    /// Base class for rendering 3D scenes using THREE.Silk
    /// </summary>
    public class ThreeSceneRenderer : ControlsContainer
    {
        static protected GLRenderer _renderer;

        protected Scene _scene;
        protected Camera _camera;
        protected IControls _controls;

        private GLRenderTarget _renderTarget;
        protected EffectComposer _composer;
        protected OutlinePass _outlinePass;
    
        private int _width;
        private int _height;
        private bool _firstFrame = true;
        private bool _alwaysRender = false;

        public override THREE.Rectangle GetClientRectangle() => new THREE.Rectangle(0, 0, _width, _height);

        public ThreeSceneRenderer(int width = 1280, int height = 720, bool useEffectComposer = true, bool alwaysRender = true)
        {
            _width = width;
            _height = height;
            _alwaysRender = alwaysRender;

            if (_renderer == null) {
                _renderer = new GLRenderer(SilkWindow.instance._window, _width, _height);
            }

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

            base.OnResize(new ResizeEventArgs(width, height));
        }

        /// <summary>
        /// Render the scene to a texture
        /// </summary>
        public virtual void Render(double? deltaTime = null)
        {
            // if (!_alwaysRender && !_firstFrame && !_controls.Focused()) return;

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

            _firstFrame = false;

            SilkWindow.instance.RestoreViewport();
        }

        /// <summary>
        /// Draw the rendered image to the screen
        /// </summary>
        public System.Numerics.Vector4 DrawImage(float heightRatio = 1.0f)
        {
            uint renderTargetTextureId = _composer == null
                ? (uint)_renderer.properties.Get(_renderTarget.Texture)["glTexture"]!
                : (uint)_renderer.properties.Get(_composer.RenderTarget1.Texture)["glTexture"]!;

            return TextureHelper.RenderImageFittingParentWidth((int)renderTargetTextureId, _width, _height, heightRatio);
        }

        public override void Dispose()
        {
            OnDispose();
        }
        public virtual void OnDispose()
        {
            Unload();
        }
        public virtual void Unload()
        {
            _renderer.Dispose();
            _renderTarget.Dispose();
        }
    }
}