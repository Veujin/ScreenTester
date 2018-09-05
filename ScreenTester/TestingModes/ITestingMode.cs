namespace ScreenTester.TestingModes
{
    interface ITestingMode
    {
        void RednerFrame(double time, int width, int height);
        void IncreaseAnimationPeriodFor(double sec);
        void DecreaseAnimationPeriodFor(double sec);
    }
}
