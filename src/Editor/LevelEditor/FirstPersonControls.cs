using THREE.Silk;
using Silk.NET.Input;

namespace NST
{
    public class FirstPersonControls : IControls
    {
        private const float YAW_INIT = 90.0f;
        private const float PITCH_INIT = 0.0f;
        private const float MOVE_SPEED = 400.0f;
        private const float VELOCITY_DAMPING = 15.0f;
        private const float SENSITIVITY = 0.25f;

        private readonly THREE.Camera _camera;

        private float _yaw = YAW_INIT;
        private float _pitch = PITCH_INIT;
        private THREE.Vector3 _worldUp = new THREE.Vector3(0, 0, -1);
        private THREE.Vector3 _velocity = new THREE.Vector3(0, 0, 0);

        private int _lastX;
        private int _lastY;
        private bool _firstMouse = true;

        private bool _focused = false;
        public bool Focused() => _focused || _velocity.X != 0 || _velocity.Y != 0 || _velocity.Z != 0;
        public void SetFocus(bool focused) => _focused = focused;
        public void ResetMousePos() => _firstMouse = true;

        public FirstPersonControls(IControlsContainer control, THREE.Camera camera)
        {
            _camera = camera;

            _camera.Front = new THREE.Vector3(0, 0, 1); // Inverted Z axis
            _camera.Up = new THREE.Vector3(0, 0, -1);   // Scene's custom up direction

            control.MouseMove += OnMouseMove;
            control.MouseWheel += OnMouseWheel;
        }

        public void Update(double? deltaTime)
        {
            float dt = MathF.Min((float)(deltaTime ?? 0.01f), 0.1f);

            if (_focused)
            {
                UpdateKeyboard(dt);
                UpdateCameraVectors();
            }

            _camera.Position.AddScaledVector(_velocity, dt);
            _camera.LookAt(_camera.Position + _camera.Front);

            float decay = MathF.Exp(-VELOCITY_DAMPING * dt);
            _velocity.MultiplyScalar(decay);

            if (_velocity.LengthSq() < 0.0001f) _velocity.Set(0, 0, 0);
        }

        private void UpdateKeyboard(float deltaTime)
        {
            var keyboard = SilkWindow.instance._input.Keyboards[0];
            if (keyboard == null) return;

            float moveSpeed = MOVE_SPEED * 100.0f;

            if (keyboard.IsKeyPressed(Key.ShiftLeft)) moveSpeed *= 6.0f;

            THREE.Vector3 input = THREE.Vector3.Zero();

            if (keyboard.IsKeyPressed(Key.W)) input += _camera.Front;
            if (keyboard.IsKeyPressed(Key.S)) input -= _camera.Front;
            if (keyboard.IsKeyPressed(Key.A)) input += _camera.Right;
            if (keyboard.IsKeyPressed(Key.D)) input -= _camera.Right;
            if (keyboard.IsKeyPressed(Key.Q)) input += _camera.Up;
            if (keyboard.IsKeyPressed(Key.E)) input -= _camera.Up;

            if (input.LengthSq() > 0)
            {
                _velocity.AddScaledVector(input.Normalize(), moveSpeed * deltaTime);
            }
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

                _pitch = Math.Clamp(_pitch, -89.0f, 89.0f);
            }

            _lastX = e.X;
            _lastY = e.Y;
        }

        private void OnMouseWheel(object? sender, THREE.Silk.MouseEventArgs e)
        {
            if (!_focused) return;
            
            _camera.Position += _camera.Front.MultiplyScalar(e.Delta * 0.5f);
        }

        private void UpdateCameraVectors()
        {
            THREE.Vector3 front = THREE.Vector3.Zero();

            front.X = MathF.Cos(THREE.MathUtils.DegToRad(_yaw)) * MathF.Cos(THREE.MathUtils.DegToRad(_pitch));
            front.Y = MathF.Sin(THREE.MathUtils.DegToRad(_yaw)) * MathF.Cos(THREE.MathUtils.DegToRad(_pitch)); // Y = yaw
            front.Z = MathF.Sin(THREE.MathUtils.DegToRad(_pitch)); // Z = pitch (instead of Y)

            _camera.Front = front.Normalize();
            _camera.Right = _camera.Front.Clone().Cross(_worldUp).Normalize();
            _camera.Up = _camera.Right.Clone().Cross(_camera.Front).Normalize();
        }

        public void LookAt(THREE.Vector3 target)
        {
            THREE.Vector3 direction = target.Clone().Sub(_camera.Position).Normalize();

            _pitch = THREE.MathUtils.RadToDeg(MathF.Asin(direction.Z));
            _yaw = THREE.MathUtils.RadToDeg(MathF.Atan2(direction.Y, direction.X));

            UpdateCameraVectors();

            _camera.LookAt(_camera.Position + _camera.Front);
        }
    }
}