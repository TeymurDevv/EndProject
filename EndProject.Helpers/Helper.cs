using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndProject.Helpers
{
    public class Helper
    {
        public static void Print(string value,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }
        public static void MainMenu()
        {
            Console.Clear();
            Print("  ______               _   _____                     _                 _                   _____   __  __    _____ \r\n |  ____|             | | |  __ \\                   (_)               | |                 / ____| |  \\/  |  / ____|\r\n | |__     _ __     __| | | |__) |  _ __    ___      _    ___    ___  | |_     ______    | |      | \\  / | | (___  \r\n |  __|   | '_ \\   / _` | |  ___/  | '__|  / _ \\    | |  / _ \\  / __| | __|   |______|   | |      | |\\/| |  \\___ \\ \r\n | |____  | | | | | (_| | | |      | |    | (_) |   | | |  __/ | (__  | |_               | |____  | |  | |  ____) |\r\n |______| |_| |_|  \\__,_| |_|      |_|     \\___/    | |  \\___|  \\___|  \\__|               \\_____| |_|  |_| |_____/ \r\n                                                   _/ |                                                            \r\n                                                  |__/                                                             ", ConsoleColor.Yellow);
            Print("1, CreateDepartment\n" +
                  "2. GetAllDepartments\n"+
                  "3. GetAllFilteredDepartments \n"+
                  "4. UpdateDepartment\n" +
                  "5. DeleteDepartment\n" +
                  "6. GetAllDepartmentsInNotepad\n" +
                  "7. GetAllFilteredDepartmentsInNotepad\n" +
                  "8. Exit EndProject-CMS", ConsoleColor.Yellow);
        }
    }
}
