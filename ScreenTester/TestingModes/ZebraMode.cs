using System;
using OpenTK.Graphics.OpenGL;
using ScreenTester.KeyboardBindings;

namespace ScreenTester.TestingModes
{
    class ZebraMode : ITestingMode
    {
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
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(1.0, 1.0, 1.0);
            for (int offset = GetOffset(time);
                offset < height;
                offset += (lineWidth * 2))
            {
                DrawRectangle(width, lineWidth, offset);
            }
            GL.End();
        }

        private int GetOffset(double time)
        {
            return time % animationPeriod * 2 < animationPeriod ? 0 : lineWidth;
        }

        private void DrawRectangle(int width, int height, int topOffset)
        {
            GL.Vertex2(0, topOffset);
            GL.Vertex2(width, topOffset);
            GL.Vertex2(width, topOffset + height);
            GL.Vertex2(0, topOffset + height);
        }

        private void DecreaseAnimationPeriod()
        {
            animationPeriod -= 0.1;
            if (animationPeriod < 0.5)
            {
                animationPeriod = 0.5;
            }
        }

        private void IncreaseAnimationPeriod()
        {
            animationPeriod += 0.1;
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
