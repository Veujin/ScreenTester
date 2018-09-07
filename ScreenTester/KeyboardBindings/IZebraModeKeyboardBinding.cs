using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenTester.KeyboardBindings
{
    interface IZebraModeKeyboardBinding : IKeyboardBinding
    {
        Action OnIncreaseAnimationPeriod { get; set; }
        Action OnDecreaseAnimationPeriod { get; set; }
        Action OnIncreaseLinesWidth { get; set; }
        Action OnDecreaseLinesWidth { get; set; }
    }
}
