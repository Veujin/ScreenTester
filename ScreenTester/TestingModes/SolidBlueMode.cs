using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class SolidBlueMode : SolidColorMode
    {
        protected override void SetColor()
        {
            GL.Color3(0.0, 0.0, 1.0);
        }
    }
}
