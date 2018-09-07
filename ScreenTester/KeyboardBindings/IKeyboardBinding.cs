using System;
using OpenTK.Input;

namespace ScreenTester.KeyboardBindings
{
    interface IKeyboardBinding
    {
        void InvokeAction(Key key);
    }
}
