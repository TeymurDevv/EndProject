﻿using EndProject.Controllers;
using EndProject.Helpers;
using EndProject.Helpers.Enums;
DepartmentController departmentController = new();
EmployeeController employeeController = new();
Helper.MainMenu();
while (true)
{
    Enter: string choice = Console.ReadLine();
    int result;
    bool isConvertable = int.TryParse(choice, out result);

    switch (result)
    {
        case (int)DepartmentMenu.CreateDepartment:
            departmentController.CreateDepartment();
            break;
        case (int)DepartmentMenu.GetDepartmentById:
            departmentController.GetDepartmentById();
            break;
        case (int)DepartmentMenu.GetAllDepartments:
            departmentController.GetAllDepartments();
            break;
        case (int)DepartmentMenu.GetAllFilteredDepartments:
            departmentController.GetAllFilteredDepartments();
            break;
        case (int)DepartmentMenu.UpdateDepartment:
            departmentController.UpdateDepartment();
            break;
        case (int)DepartmentMenu.DeleteDepartment:
            departmentController.DeleteDepartment();
            break;
        case (int)DepartmentMenu.GetAllDepartmentsInNotepad:
            departmentController.GetAllDepartmentsInNotepad();
            break;
        case (int)DepartmentMenu.GetAllFilteredDepartmentsInNotepad:
            departmentController.GetAllFilteredDepartmentsInNotepad();
            break;
        case (int)EmployeeMenu.CreateEmployee:
            employeeController.CreateEmployee();
            break;
        case (int)EmployeeMenu.GetEmployeeById:
            employeeController.GetEmployeeById();
            break;
        case (int)EmployeeMenu.UpdateEmployee:
            employeeController.UpdateEmployee();
            break;
        case (int)EmployeeMenu.DeleteEmployee:
            employeeController.DeleteEmployee();
            break;
        case (int)EmployeeMenu.GetEmployeesByAge:
            employeeController.GetAllEmployeesByAge();
            break;
        case (int)EmployeeMenu.GetEmployeesByDepartmentId:
            employeeController.GetAllEmployeesByDepartmentId();
            break;
        case (int)EmployeeMenu.GetEmployeesByDepartmentName:
            employeeController.GetAllEmployeesByDepartmentName();
            break;
        case (int)EmployeeMenu.GetEmployeesByName:
            employeeController.GetAllEmployeesByName();
            break;
        case (int)EmployeeMenu.GetEmployeesCount:
            employeeController.GetAllEmployeesCount();
            break;
        case (int)DepartmentMenu.Exit:
            Environment.Exit(0);
            break;
        default:
            Helper.Print("Wrong Option", ConsoleColor.Red);
            goto Enter;
    }
}