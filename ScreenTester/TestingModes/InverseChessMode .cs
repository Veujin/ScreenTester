using System;
using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class InverseChessMode : ITestingMode
    {
        public void DecreaseAnimationPeriodFor(double sec)
        {
        }

        public void IncreaseAnimationPeriodFor(double sec)
        {
        }

        public void RednerFrame(double time, int width, int height)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(1.0, 1.0, 1.0);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (!(i % 2 == 0 ^ j % 2 == 0))
                    {
                        GL.Vertex2(i, j);
                    }
                }
            }
            GL.End();
        }
    }
}
