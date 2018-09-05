using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class SolidRedMode : SolidColorMode
    {
        protected override void SetColor()
        {
            GL.Color3(1.0, 0.0, 0.0);
        }
    }
}
