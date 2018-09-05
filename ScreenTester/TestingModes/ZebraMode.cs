using System;
using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class ZebraMode : ITestingMode
    {
        double animationPeriod = 2;
        int lineWidth = 200;

        public void DecreaseAnimationPeriodFor(double sec)
        {
            animationPeriod -= sec;
            if (animationPeriod < 0.5)
            {
                animationPeriod = 0.5;
            }
        }

        public void IncreaseAnimationPeriodFor(double sec)
        {
            animationPeriod += sec;
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
                    if (j % lineWidth * 2 < lineWidth ^ time % animationPeriod < animationPeriod * 0.5)
                    {
                        GL.Vertex2(i, j);
                    }
                }
            }
            GL.End();
        }
    }
}
