using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;

namespace ScreenTester.KeyboardBindings
{
    class ZebraKeyboardBinding : IZebraModeKeyboardBinding
    {
        public Action OnIncreaseAnimationPeriod { get; set; }
        public Action OnDecreaseAnimationPeriod { get; set; }
        public Action OnIncreaseLinesWidth { get; set; }
        public Action OnDecreaseLinesWidth { get; set; }

        public void InvokeAction(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    this.OnIncreaseAnimationPeriod?.Invoke();
                    break;
                case Key.Down:
                    this.OnDecreaseAnimationPeriod?.Invoke();
                    break;
                case Key.PageUp:
                    this.OnIncreaseLinesWidth?.Invoke();
                    break;
                case Key.PageDown:
                    this.OnDecreaseLinesWidth?.Invoke();
                    break;
            }
        }
    }
}
