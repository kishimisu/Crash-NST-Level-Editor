using THREE;
using THREE.Silk;
using Silk.NET.Input;

namespace NST
{
    public class FirstPersonControls : IControls
    {
        private const float YAW_INIT = 90.0f;
        private const float PITCH_INIT = 0.0f;
        private const float MOVE_SPEED = 80.0f;
        private const float SENSITIVITY = 0.25f;
        private const float FOV = 70.0f;

        private readonly Camera _camera;

        private float _yaw = YAW_INIT;
        private float _pitch = PITCH_INIT;
        private THREE.Vector3 _worldUp = new THREE.Vector3(0, 0, -1);
        private THREE.Vector3 _velocity = new THREE.Vector3(0, 0, 0);

        private int _lastX;
        private int _lastY;
        private bool _firstMouse = true;

        private bool _focused = false;
        public void SetFocus(bool focused) => _focused = focused;
        public bool Focused() => _focused;

        public FirstPersonControls(IControlsContainer control, Camera camera)
        {
            _camera = camera;

            _camera.Front = new THREE.Vector3(0, 0, 1); // Inverted Z axis
            _camera.Up = new THREE.Vector3(0, 0, -1);   // Scene's custom up direction

            control.MouseMove += OnMouseMove;
            // control.MouseWheel += OnMouseWheel;
        }

        public void Update(double? deltaTime)
        {
            if (!_focused) return;

            UpdateKeyboard(deltaTime ?? 0.01f);
            UpdateCameraVectors();

            _camera.Position.Add(_velocity);
            _camera.LookAt(_camera.Position + _camera.Front);

            const float damping = 15.0f;
            // _velocity *= 0.95f;
            // _velocity = _velocity * (float)Math.Pow(0.001, dt * damping);
            _velocity *= 1.0f / (1.0f + damping * (float)(deltaTime ?? 0.01f));
        }

        private void UpdateKeyboard(double deltaTime)
        {
            var keyboard = SilkWindow.instance._input.Keyboards[0];
            if (keyboard == null) return;

            float moveSpeed = MOVE_SPEED;

            if (keyboard.IsKeyPressed(Key.ShiftLeft))
                moveSpeed *= 6.0f;

            if (keyboard.IsKeyPressed(Key.W))
                _velocity.AddScaledVector(_camera.Front, moveSpeed * (float)deltaTime);
            if (keyboard.IsKeyPressed(Key.S))
                _velocity.AddScaledVector(_camera.Front, -moveSpeed * (float)deltaTime);
            if (keyboard.IsKeyPressed(Key.A))
                _velocity.AddScaledVector(_camera.Right, moveSpeed * (float)deltaTime);
            if (keyboard.IsKeyPressed(Key.D))
                _velocity.AddScaledVector(_camera.Right, -moveSpeed * (float)deltaTime);
        }

        private void OnMouseMove(object? sender, THREE.Silk.MouseEventArgs e)
        {
            if (!_focused) return;
            
            if (_firstMouse) {
                _lastX = e.X;
                _lastY = e.Y;
                _firstMouse = false;
            }

            if (SilkWindow.instance._input.Mice[0].IsButtonPressed(MouseButton.Right))
            {
                int deltaX = e.X - _lastX;
                int deltaY = e.Y - _lastY;

                _yaw -= deltaX * SENSITIVITY;
                _pitch -= deltaY * SENSITIVITY;

                _pitch = System.Math.Clamp(_pitch, -89.0f, 89.0f);
            }

            _lastX = e.X;
            _lastY = e.Y;
        }

        // private void OnMouseWheel(object? sender, MouseEventArgs e)
        // {
        // }

        private void UpdateCameraVectors()
        {
            THREE.Vector3 front = THREE.Vector3.Zero();

            front.X = (float)System.Math.Cos(THREE.MathUtils.DegToRad(_yaw)) * (float)System.Math.Cos(THREE.MathUtils.DegToRad(_pitch));
            front.Y = (float)System.Math.Sin(THREE.MathUtils.DegToRad(_yaw)) * (float)System.Math.Cos(THREE.MathUtils.DegToRad(_pitch)); // Y = yaw
            front.Z = (float)System.Math.Sin(THREE.MathUtils.DegToRad(_pitch)); // Z = pitch (instead of Y)

            // _camera.Front = front.Normalize();

            _camera.Front = front.Normalize();
            _camera.Right = _camera.Front.Clone().Cross(_worldUp).Normalize();
            _camera.Up = _camera.Right.Clone().Cross(_camera.Front).Normalize();
        }

        public void LookAt(Vector3 target)
        {
            Vector3 direction = target.Clone().Sub(_camera.Position).Normalize();

            _pitch = THREE.MathUtils.RadToDeg(MathF.Asin(direction.Z));
            _yaw = THREE.MathUtils.RadToDeg(MathF.Atan2(direction.Y, direction.X));

            UpdateCameraVectors();

            _camera.LookAt(_camera.Position + _camera.Front);
        }
    }
}