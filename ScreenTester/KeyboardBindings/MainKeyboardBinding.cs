using System;
using OpenTK.Input;

namespace ScreenTester.KeyboardBindings
{
    class MainKeyboardBinding : IMainKeyboardBinding
    {
        public Action OnNextMode { get; set; }
        public Action OnPreviousMode { get; set; }
        public Action OnExit { get; set; }
        public Action OnSwitchWindowState { get; set; }
        public Action<Key> InvokeForeignKeyboardBinding { get; set; }

        public void InvokeAction(Key key)
        {
            switch (key)
            {
                case Key.Q:
                case Key.Escape:
                    this.OnExit?.Invoke();
                    break;
                case Key.Space:
                case Key.Right:
                    this.OnNextMode?.Invoke();
                    break;
                case Key.Left:
                    this.OnPreviousMode?.Invoke();
                    break;
                case Key.F:
                    this.OnSwitchWindowState?.Invoke();
                    break;
                default:
                    this.InvokeForeignKeyboardBinding?.Invoke(key);
                    break;
            }
        }
    }
}
