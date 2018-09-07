using System;
using OpenTK.Input;

namespace ScreenTester.KeyboardBindings
{
    internal interface IMainKeyboardBinding : IKeyboardBinding
    {
        Action OnNextMode { get; set; }
        Action OnPreviousMode { get; set; }
        Action OnExit { get; set; }
        Action OnSwitchWindowState { get; set; }
        Action<Key> InvokeForeignKeyboardBinding { get; set; }
    }
}