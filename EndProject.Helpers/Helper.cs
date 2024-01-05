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
            Print("1. CreateDepartment\n" +
                  "2. GetDepartmentById\n"+
                  "3. GetAllDepartments\n"+
                  "4. GetAllFilteredDepartments\n"+
                  "5. UpdateDepartment\n" +
                  "6. DeleteDepartment\n" +
                  "7. GetAllDepartmentsInNotepad\n" +
                  "8. GetAllFilteredDepartmentsInNotepad\n" +
                  "9. CreateEmployee\n"+
                  "10. GetEmployeeById\n"+
                  "11. UpdateEmployee\n"+
                  "12. DeleteEmployee\n"+
                  "0. Exit EndProject-CMS", ConsoleColor.Yellow);
        }
    }
}
