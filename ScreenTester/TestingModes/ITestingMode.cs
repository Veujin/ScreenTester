using ScreenTester.KeyboardBindings;

namespace ScreenTester.TestingModes
{
    interface ITestingMode
    {
        IKeyboardBinding ModeKeyboardBinding { get; set; }
        void RednerFrame(double time, int width, int height);
    }
}
