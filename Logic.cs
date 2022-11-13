using ConsoleGUI;

namespace MyConsoleGUI
{
    [SupportedOSPlatform("windows")]

    public sealed class Logic
    {
        private bool quit = false;

        #region Singleton Instantiation
        public static Logic Instance { get { return Initializer.instance; } }

        private class Initializer
        {
            static Initializer() { }
            internal static readonly Logic instance = new();
        }
        #endregion

        #region Logic Initialization
        private Logic()
        {
            // Initialization of app logic here
            LoadContent();
            DrawGUI();
            CreateContent();

            // TODO: Something that makes sure the selected textbox is rendered as such
            //if (textBoxes.Count > 0)
            //    textBoxes[0].Render();
        }

        /// <summary>
        /// Loads any necessary data from external files
        /// </summary>
        private void LoadContent()
        {

        }

        /// <summary>
        /// Draws static/non-updating GUI elements such as boxes, lines, and columns.
        /// </summary>
        private void DrawGUI()
        {
            GUI.DrawBox(0, 0, GUI.GetGUIWidth, 9, GUI.BorderStyle.Double, 0, 0, 0, 0, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            GUI.DrawLine(1, 6, GUI.GetGUIWidth - 2, 0, 0, 0, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            GUI.DrawBox(0, GUI.GetGUIHeight - 7, GUI.GetGUIWidth, 7, GUI.BorderStyle.Double, 0, 0, 0, 0, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            GUI.DrawLineZigzag(1, 9, GUI.GetGUIWidth - 2, GUI.BorderStyle.Single, true, false, ConsoleColor.DarkRed, ConsoleColor.White);
            GUI.DrawLineZigzag(1, 39, GUI.GetGUIWidth - 2, GUI.BorderStyle.Single, true, true, ConsoleColor.DarkRed, ConsoleColor.White);
            GUI.DrawColumnZigzag(0, 9, 32, GUI.BorderStyle.Single, false, false, ConsoleColor.DarkRed, ConsoleColor.White);
            GUI.DrawColumnZigzag(GUI.GetGUIWidth - 3, 9, 32, GUI.BorderStyle.Single, false, true, ConsoleColor.DarkRed, ConsoleColor.White);
        }

        /// <summary>
        /// Creates static text fields and interactable, scrolling text boxes on top of previously drawn GUI elements.
        /// </summary>
        private void CreateContent()
        {
            GUI.CreateTextbox(2, 1, 76, 5, Data.logo, ConsoleColor.DarkBlue, ConsoleColor.Cyan);
            GUI.CreateTextbox(GUI.GetGUIWidth - 27, 1, 25, 5, Data.name + "\n" + Data.addressStore, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            GUI.CreateTextbox(27, 7, 75, 1, Data.slogan, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            GUI.CreateTextbox(GUI.GetGUIWidth - 27, GUI.GetGUIHeight - 6, 25, 5, "BILLING ADDRESS:" + "\n" + Data.name + "\n" + Data.addressBilling, ConsoleColor.DarkBlue, ConsoleColor.Yellow);
            GUI.CreateTextbox(2, GUI.GetGUIHeight - 3, 30, 1, Data.copyright, ConsoleColor.DarkBlue, ConsoleColor.Yellow);

            GUI.PrintInfo("Press enter/return to 'add' an item to your cart.");
            GUI.PrintInfo("Left and right arrow keys let you switch between textboxes, and up and down scroll through items.");
            GUI.PrintInfo("Press 'Q' to quit. 'Page Down' and 'Page Up' to scroll through this log. :)");
        }
        #endregion

        #region Logic Loop
        public void RunLoop()
        {
            while (quit is not true)
            {
                Input();
            }
        }

        /// <summary>
        /// Handles all user input.
        /// </summary>
        private void Input()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:              quit = true; break;

                case ConsoleKey.PageUp:         GUI.Controls.LogBox.ScrollUp(); break;
                case ConsoleKey.PageDown:       GUI.Controls.LogBox.ScrollDown(); break;
                case ConsoleKey.UpArrow:        GUI.Controls.PrevTextbox(); break;
                case ConsoleKey.DownArrow:      GUI.Controls.NextTextbox(); break;
                case ConsoleKey.LeftArrow:      GUI.Controls.PrevTextbox(); break;
                case ConsoleKey.RightArrow:     GUI.Controls.NextTextbox(); break;
                case ConsoleKey.Enter:          GUI.Controls.UseSelection(); break;
                case ConsoleKey.Delete:         GUI.Controls.ClearTextbox(); break;
                case ConsoleKey.Insert:         GUI.Controls.InsertIntoTextbox("Here comes a new challenger!"); break;
            }
        }
        #endregion
    }
}
