using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class SolidWhiteMode : SolidColorMode
    {
        protected override void SetColor()
        {
            GL.Color3(1.0, 1.0, 1.0);
        }
    }
}
