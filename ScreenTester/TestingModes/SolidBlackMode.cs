﻿using OpenTK.Graphics.OpenGL;

namespace ScreenTester.TestingModes
{
    class SolidBlackMode : SolidColorMode
    {
        protected override void SetColor()
        {
            GL.Color3(0.0, 0.0, 0.0);
        }
    }
}
