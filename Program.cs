global using System.Runtime.Versioning;
using ConsoleGUI;

namespace MyConsoleGUI
{
    [SupportedOSPlatform("windows")]

    internal class Program
    {        
        static void Main()
        {
            GUI.Initialize(Data.name);

            Logic logic = Logic.Instance;

            logic.RunLoop();
        }
    }
}