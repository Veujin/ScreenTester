using System;
using OpenTK.Input;

namespace ScreenTester.KeyboardBindings
{
    class KeyboardBinding : IKeyboardBinding
    {
        public Action OnNextMode { get; set; }
        public Action OnPreviousMode { get; set; }
        public Action OnIncreaseAnimationPeriod { get; set; }
        public Action OnDecreaseAnimationPeriod { get; set; }
        public Action OnExit { get; set; }

        public void InvokeAction(Key key)
        {
            switch (key)
            {
                case Key.Q:
                case Key.Escape:
                    this.OnExit?.Invoke();
                    break;
                case Key.Up:
                    this.OnIncreaseAnimationPeriod?.Invoke();
                    break;
                case Key.Down:
                    this.OnDecreaseAnimationPeriod?.Invoke();
                    break;
                case Key.Space:
                case Key.Right:
                    this.OnNextMode?.Invoke();
                    break;
                case Key.Left:
                    this.OnPreviousMode?.Invoke();
                    break;
            }
        }
    }
}
