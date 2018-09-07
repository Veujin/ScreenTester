using System;
using OpenTK.Graphics.OpenGL;
using ScreenTester.KeyboardBindings;

namespace ScreenTester.TestingModes
{
    class ZebraMode : ITestingMode
    {
        private double sec = 0.1;
        private double animationPeriod = 2;
        private int lineWidth = 200;
        public IKeyboardBinding ModeKeyboardBinding { get; set; }


        public ZebraMode(IZebraModeKeyboardBinding keyboardBinding)
        {
            this.ModeKeyboardBinding = keyboardBinding;
            keyboardBinding.OnIncreaseAnimationPeriod = IncreaseAnimationPeriod;
            keyboardBinding.OnDecreaseAnimationPeriod = DecreaseAnimationPeriod;
            keyboardBinding.OnIncreaseLinesWidth = IncreaseLineWidth;
            keyboardBinding.OnDecreaseLinesWidth = DecreaseLineWidth;
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

        private void DecreaseAnimationPeriod()
        {
            animationPeriod -= sec;
            if (animationPeriod < 0.5)
            {
                animationPeriod = 0.5;
            }
        }

        private void IncreaseAnimationPeriod()
        {
            animationPeriod += sec;
        }
        private void DecreaseLineWidth()
        {
            lineWidth -= 2;
            if (lineWidth < 2)
            {
                lineWidth = 2;
            }
        }

        private void IncreaseLineWidth()
        {
            lineWidth += 2;
        }
    }
}
