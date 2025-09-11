using ImGuiNET;
using THREE.Silk;
using Silk.NET.GLFW;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGLES;
using Silk.NET.OpenGLES.Extensions.ImGui;
using MouseButton = Silk.NET.Input.MouseButton;

namespace NST
{
    /// <summary>
    /// Main window and input handling.
    /// See `App` for the main application logic.
    /// </summary>
    public class SilkWindow
    {
        public static SilkWindow instance;

        public GL _gl;
        public IWindow _window;

        public IInputContext _input;

        private ImGuiController _imgui;
        private ImGuiIOPtr _io;

        public List<ControlsContainer> controls = new List<ControlsContainer>();

        public void Run() => _window.Run();

        public SilkWindow()
        {
            WindowOptions options = WindowOptions.Default;
            options.Size = new Vector2D<int>(1600, 900);
            options.Title = "Crash NST Editor v1.0";
            options.API = new GraphicsAPI(ContextAPI.OpenGL, ContextProfile.Compatability, ContextFlags.Default, new APIVersion(3, 3));

            options.VSync = false;
            // options.FramesPerSecond = 600;
            
            _window = Window.Create(options);

            _window.Load += OnLoad;
            _window.Render += OnRender;
            _window.FramebufferResize += OnResize;
            _window.Closing += OnClose;

            instance = this;
        }

        private void OnLoad()
        {
            // _gl = GL.GetApi(_window);
            _gl = _window.CreateOpenGLES();

            SetupInputs();

            SetupImGUI();

            OnResize(new Vector2D<int>(_window.Size.X, _window.Size.Y));

            App.Initialize();
        }

        private void SetupInputs()
        {
            _input = _window.CreateInput();

            // Init keyboard
            for (int i = 0; i < _input.Keyboards.Count; i++)
            {
                _input.Keyboards[i].KeyDown += KeyDown;
                _input.Keyboards[i].KeyUp += KeyUp;
            }
            
            // Init mouse
            for (int i = 0; i < _input.Mice.Count; i++)
            {
                _input.Mice[i].Cursor.CursorMode = CursorMode.Hidden;

                _input.Mice[i].MouseMove += OnMouseMove;
                _input.Mice[i].Scroll += OnMouseWheel;
                _input.Mice[i].MouseDown += OnMouseDown;
                _input.Mice[i].MouseUp += OnMouseUp;
            }
        }

        private unsafe void SetupImGUI()
        {
            _imgui = new ImGuiController(_gl, _window, _input, null, LoadIconFont);

            _io = ImGui.GetIO();
            _io.MouseDrawCursor = true;
            _io.ConfigWindowsMoveFromTitleBarOnly = true;
            _io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;

            ImGui.PushStyleVar(ImGuiStyleVar.IndentSpacing, 12);
        }

        private unsafe static void LoadIconFont()
        {
            ushort[] range = new ushort[3] { 0x0020, 0xFFFF, 0x00 };

            fixed (ushort* rangePtr = &range[0])
            {
                ImFontConfigPtr config = ImGuiNative.ImFontConfig_ImFontConfig();
                config.MergeMode = true;

                ImGui.GetIO().Fonts.AddFontDefault();
                ImGui.GetIO().Fonts.AddFontFromFileTTF("assets/icomoon.ttf", 10.0f, config, new IntPtr(rangePtr));
            }
        }

        private void OnRender(double deltaTime)
        {
            // _window.MakeCurrent();

            _imgui.Update((float)deltaTime);

            _gl.ClearColor(0, 0, 0, 1);
            _gl.Clear(ClearBufferMask.ColorBufferBit);

            App.Render(deltaTime);

            _imgui.Render();
        }

        private void OnResize(Vector2D<int> newSize)
        {
            _gl.Viewport(newSize);
        }

        public void SetViewport(int x, int y, int width, int height)
        {
            _gl.Viewport(x, y, (uint)width, (uint)height);
        }

        public void RestoreViewport()
        {
            _gl.Viewport(0, 0, (uint)_window.Size.X, (uint)_window.Size.Y);
        }

        // Inputs

        public virtual void KeyDown(IKeyboard keyboard, Key key, int arg)
        {
            UpdateModKey(key, true);

            foreach (ControlsContainer control in controls)
            {
                control.OnKeyDown(key, (int)key, (KeyModifiers)arg);
            }
        }

        public virtual void KeyUp(IKeyboard keyboard,Key key,int arg)
        {
            UpdateModKey(key, false);

            foreach (ControlsContainer control in controls)
            {
                control.OnKeyUp(key, (int)key, (KeyModifiers)arg);
            }
        }

        private void UpdateModKey(Key key, bool down)
        {
            if (key == Key.ControlLeft || key == Key.ControlRight)
            {
                _io.AddKeyEvent(ImGuiKey.ModCtrl, down);
            }
            else if (key == Key.AltLeft || key == Key.AltRight)
            {
                _io.AddKeyEvent(ImGuiKey.ModAlt, down);
            }
            else if (key == Key.ShiftLeft || key == Key.ShiftRight)
            {
                _io.AddKeyEvent(ImGuiKey.ModShift, down);
            }
            else if (key == Key.SuperLeft || key == Key.SuperRight)
            {
                _io.AddKeyEvent(ImGuiKey.ModSuper, down);
            }
            else if (key == Key.Q) // Fix Ctrl+A not working on text inputs on azerty keyboards
            {
                _io.AddKeyEvent(ImGuiKey.A, down);
            }
        }

        public virtual void OnMouseMove(IMouse mouse,System.Numerics.Vector2 position)
        {
            foreach (ControlsContainer control in controls)
            {
                control.OnMouseMove(0, (int)position.X, (int)position.Y);
            }
        }

        public virtual void OnMouseWheel(IMouse mouse,ScrollWheel scrollWheel)
        {
            foreach (ControlsContainer control in controls)
            {
                control.OnMouseWheel((int)mouse.Position.X, (int)mouse.Position.Y, (int)scrollWheel.Y * 120);
            }
        }

        public virtual void OnMouseDown(IMouse mouse, MouseButton button)
        {
            foreach (ControlsContainer control in controls)
            {
                control.OnMouseDown(button, (int)mouse.Position.X, (int)mouse.Position.Y);
            }
        }

        public virtual void OnMouseUp(IMouse mouse, MouseButton button)
        {
            foreach (ControlsContainer control in controls)
            {
                control.OnMouseUp(button, (int)mouse.Position.X, (int)mouse.Position.Y);
            }
        }

        private void OnClose()
        {
            _imgui.Dispose();
            _input.Dispose();
            _gl.Dispose();
        }
    }
}