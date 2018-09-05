using ScreenTester.TestingModes;
using System;
using System.Collections.Generic;
using ScreenTester.KeyboardBindings;

namespace ScreenTester
{
    class Game
    {
        [STAThread]
        static void Main()
        {
            PrintInfo();
            ExitIfReuired(Console.ReadKey());
            using (TestingWindow game = new TestingWindow(new KeyboardBinding(), GetModes()))
            {
                game.Run(60.0);
            }
        }

        private static void ExitIfReuired(ConsoleKeyInfo consoleKeyInfo)
        {
            var key = consoleKeyInfo.Key;
            if (key == ConsoleKey.Escape || key == ConsoleKey.Q)
            {
                Environment.Exit(0);
            }
        }

        private static void PrintInfo()
        {
            Console.Write(
                "ScreenTester\n"
                + "This tool draws testing screens to allow you test your display.\n"
                + "Tool supports several modes: blinking zebra, chess, inversed chess and white, black, red, green, blue solid colors.\n\n"
                + "Navigation:\n"
                + "[esc] or [q]\t- exit\n"
                + "[spacebar]\t- next mode\n\n"
                + "               increase animation period\n"
                + "                        [ up ] \n"
                + "previous mode    [left] [down] [rigth]    next mode\n"
                + "               decrease animation period\n\n"
                + "Press any key to start.");
        }

        static private IEnumerable<ITestingMode> GetModes()
        {

            return new List<ITestingMode>()
            {
                new ZebraMode(),
                new ChessMode(),
                new InverseChessMode(),
                new SolidWhiteMode(),
                new SolidBlackMode(),
                new SolidRedMode(),
                new SolidGreenMode(),
                new SolidBlueMode()
            };
        }
    }
}