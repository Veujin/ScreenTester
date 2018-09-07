using System;
using System.Collections.Generic;
using System.Linq;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using ScreenTester.KeyboardBindings;
using ScreenTester.TestingModes;

namespace ScreenTester
{
    class TestingWindow : GameWindow
    {
        private double time = 0;
        private IMainKeyboardBinding keyboardBinding;
        private IList<ITestingMode> testingModes;
        private int currentTestingModeIndex = 0;

        public TestingWindow(
            IMainKeyboardBinding keyboardBinding,
            IEnumerable<ITestingMode> testingModes)
            : base(800, 600, GraphicsMode.Default, "Screen Tester")
        {
            this.VSync = VSyncMode.On;
            this.WindowState = WindowState.Fullscreen;
            this.CursorVisible = false;
            this.keyboardBinding = keyboardBinding;
            this.testingModes = testingModes.ToList();
            if (this.testingModes.Count < 1)
            {
                throw new ArgumentException("More than one testing mode is required");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitGL();
            this.InitWindow();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.InitGL();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            this.keyboardBinding.InvokeAction(e.Key);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            this.UpdateCurrentTime(e.Time);

            this
                .GetCurrentMode()
                .RednerFrame(this.GetCurrentTime(), this.Width, this.Height);

            base.SwapBuffers();
        }

        private double GetCurrentTime() => this.time;

        private void UpdateCurrentTime(double time) => this.time += time;

        private ITestingMode GetCurrentMode()
        {
            return testingModes[currentTestingModeIndex];
        }

        private void InitGL()
        {
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, this.Width, this.Height, 0, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        private void InitWindow()
        {
            this.keyboardBinding.OnExit = this.Exit;
            this.keyboardBinding.OnNextMode = this.SwitchToNextMode;
            this.keyboardBinding.OnPreviousMode = this.SwitchToPreviousMode;
            this.keyboardBinding.OnSwitchWindowState = this.SwitchWindowState;
            this.keyboardBinding.InvokeForeignKeyboardBinding = this.InvokeForeignBinding;
        }

        private void InvokeForeignBinding(Key key)
        {
            GetCurrentMode().ModeKeyboardBinding?.InvokeAction(key);
        }

        private void SwitchWindowState()
        {
            if (this.WindowState == WindowState.Fullscreen)
            {
                this.WindowState = WindowState.Normal;
                this.CursorVisible = true;
            }
            else
            {
                this.WindowState = WindowState.Fullscreen;
                this.CursorVisible = false;
            }
        }

        private void SwitchToPreviousMode()
        {
            this.currentTestingModeIndex--;
            this.currentTestingModeIndex += this.testingModes.Count;
            this.currentTestingModeIndex %= this.testingModes.Count;
        }

        private void SwitchToNextMode()
        {
            this.currentTestingModeIndex++;
            this.currentTestingModeIndex %= this.testingModes.Count;
        }
    }
}
