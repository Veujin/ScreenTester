using System;
using OpenTK.Input;

namespace ScreenTester.KeyboardBindings
{
    internal interface IKeyboardBinding
    {
        Action OnNextMode { get; set; }
        Action OnPreviousMode { get; set; }
        Action OnIncreaseAnimationPeriod { get; set; }
        Action OnDecreaseAnimationPeriod { get; set; }
        Action OnExit { get; set; }
        Action OnSwitchWindowState { get; set; }

        void InvokeAction(Key key);
    }
}