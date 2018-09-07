using OpenTK.Graphics.OpenGL;
using ScreenTester.KeyboardBindings;

namespace ScreenTester.TestingModes
{
    abstract class SolidColorMode : ITestingMode
    {
        public IKeyboardBinding ModeKeyboardBinding { get; set; }

        public void RednerFrame(double time, int width, int height)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Begin(PrimitiveType.Quads);
            this.SetColor();
            GL.Vertex2(0, 0);
            GL.Vertex2(width, 0);
            GL.Vertex2(width, height);
            GL.Vertex2(0, height);
            GL.End();
        }

        abstract protected void SetColor();
    }
}
