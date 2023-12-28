using EndProject.Business.Interfaces;
using EndProject.Business.Services;
using EndProject.DataContext.Repositories;
using EndProject.Domain;
using EndProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EndProject.Controllers
{
    internal class DepartmentController
    {
        DepartmentService departmentService = new();
        public void CreateDepartment()
        {
            Console.Clear();
            Helper.Print("Enter Department Name", ConsoleColor.Green);
            string departmentName = Console.ReadLine();
            Helper.Print("Enter Department Capacity", ConsoleColor.Green);
            string size = Console.ReadLine();
            bool result = int.TryParse(size, out int departmentCapacity);
            if (result && !string.IsNullOrEmpty(departmentName))
            {
                Department department = new();
                department.Name = departmentName;
                department.Capacity = departmentCapacity;
                Department createdDepartment = departmentService.Create(department);
                if (createdDepartment is not null)
                {
                    Helper.Print($"{department.Name} is created succesfully", ConsoleColor.Yellow);

                }
            }
            else
            {
                Helper.Print("Capacity or Name format is wrong", ConsoleColor.Red);

            }
            Thread.Sleep(2000);
            Helper.MainMenu();
        }
    }
}
