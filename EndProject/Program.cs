using EndProject.Controllers;
using EndProject.Helpers;
using EndProject.Helpers.Enums;
DepartmentController departmentController = new();
Helper.MainMenu();
while (true)
{
    Enter: string choice = Console.ReadLine();
    int result;
    bool isConvertable = int.TryParse(choice, out result);

    switch (result)
    {
        case (int)EmployeeMenu.CreateEmployee:
            departmentController.CreateDepartment();
            break;
        default:
            Helper.Print("Wrong Option", ConsoleColor.Red);
            goto Enter;
    }
}