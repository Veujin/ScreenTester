using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class SolidGreenMode : SolidColorMode
    {
        protected override void SetColor()
        {
            GL.Color3(0.0, 1.0, 0.0);
        }
    }
}
