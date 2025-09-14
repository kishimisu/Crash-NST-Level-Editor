using THREE;
using THREE.Silk;
using Silk.NET.Input;
using MouseEventArgs = THREE.Silk.MouseEventArgs;

namespace NST
{
    public interface IControls
    {
        void Update(double? deltaTime = null);
        void SetFocus(bool focused);
        bool Focused();
    }

    /// <summary>
    /// Orbit camera controls
    /// </summary>
    public class OrbitControls : IControls
    {
        private const float SENSITIVITY = 0.01f;
        private const float SCROLL_SENSITIVITY = 0.0005f;

        private readonly Camera _camera;

        private float _yaw = -0.6f;
        private float _pitch = MathF.PI * 0.5f - 0.3f;
        private float _radius;

        private int _lastX, _lastY;
        private bool _firstMouse = true;
        private bool _startedFocused = false;
        private bool _currentlyFocused = false;

        public bool Focused() => _currentlyFocused;
        public void SetFocus(bool focused) => _currentlyFocused = focused;

        public OrbitControls(IControlsContainer control, Camera camera, float radius)
        {
            _camera = camera;
            _camera.Up = new THREE.Vector3(0, 0, -1); // Z up

            _radius = radius;

            control.MouseUp += OnMouseUp;
            control.MouseDown += OnMouseDown;
            control.MouseMove += OnMouseMove;
            control.MouseWheel += OnMouseWheel;
        }

        /// <summary>
        /// Recompute the camera position and orientation
        /// </summary>
        public void Update(double? deltaTime)
        {
            _camera.Position.X = _radius * (float)Math.Sin(_pitch) * (float)Math.Cos(_yaw);
            _camera.Position.Y = _radius * (float)Math.Sin(_pitch) * (float)Math.Sin(_yaw);
            _camera.Position.Z = _radius * (float)Math.Cos(_pitch);
            _camera.LookAt(THREE.Vector3.Zero());
        }
        
        /// <summary>
        /// Update camera orientation
        /// </summary>
        private void OnMouseMove(object? sender, MouseEventArgs e)
        {
            if (!_startedFocused) return;

            if (_firstMouse) {
                _lastX = e.X;
                _lastY = e.Y;
                _firstMouse = false;
            }

            if (e.Button == MouseButton.Left || e.Button == MouseButton.Right)
            {
                int deltaX = e.X - _lastX;
                int deltaY = e.Y - _lastY;

                _yaw -= deltaX * SENSITIVITY;
                _pitch -= deltaY * SENSITIVITY;
                _pitch = System.Math.Clamp(_pitch, 0.01f, MathF.PI * 0.99f);
            }

            _lastX = e.X;
            _lastY = e.Y;
        }

        /// <summary>
        /// Update camera radius
        /// </summary>
        private void OnMouseWheel(object? sender, MouseEventArgs e)
        {
            if (!_currentlyFocused) return;
            _radius -= e.Delta * SCROLL_SENSITIVITY * _radius;
        }

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            _startedFocused = _firstMouse = _currentlyFocused;
        }
        private void OnMouseUp(object? sender, MouseEventArgs e)
        {
            _startedFocused = false;
        }
    }
}