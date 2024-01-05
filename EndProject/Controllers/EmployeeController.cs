using EndProject.Business.Services;
using EndProject.Domain;
using EndProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    internal class EmployeeController
    {
        DepartmentService departmentService = new();
        EmployeeService employeeService = new();
        public void CreateEmployee()
        {
            Console.Clear();
            Helper.Print("Enter Employee Name", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            Helper.Print("Enter Employee Surname", ConsoleColor.Yellow);
            string surName = Console.ReadLine();
            Helper.Print("Enter Employee Age", ConsoleColor.Yellow);
            string givenAge = Console.ReadLine();
            bool result = int.TryParse(givenAge, out int age);
            Helper.Print("Enter Employee Adress:", ConsoleColor.Yellow);
            string adres = Console.ReadLine();
            Helper.Print("Enter Department Name:", ConsoleColor.Yellow);
            string departmentName = Console.ReadLine();
            if (result && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surName) && !string.IsNullOrEmpty(adres) && !string.IsNullOrEmpty(departmentName))
            {
                Employee employee = new() {Name = name, SurName = surName,Adress = adres, Age = age,CreatedAt = DateTime.Now};
                Employee newEmployee = employeeService.Create(employee,departmentName);
                if (newEmployee is not null)
                {
                    Helper.Print($"Employee: {employee.Name} {employee.SurName} Was Sucessfully created", ConsoleColor.Green);
                }
            }
            else
            {
                Helper.Print("The Input Fields is not in Correct Format", ConsoleColor.Red);
            }
            Thread.Sleep(1000);
            Helper.MainMenu();
        }
    }
}
