using EndProject.Business.Interfaces;
using EndProject.Business.Services;
using EndProject.DataContext.Repositories;
using EndProject.Domain;
using EndProject.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        public void GetAllDepartmentsInNotepad()
        {
            Console.Clear();
            StringBuilder departmentsStr = new();
            departmentsStr.AppendLine("Departments List:");
            foreach (Department department in departmentService.GetAll())
            {
                departmentsStr.Append($"{department} \n");
            }
            string path = "C:\\Users\\TeymurDevv\\Desktop\\C# Projects\\EndProject\\Assets\\Departments.txt";
            File.WriteAllText(path,departmentsStr.ToString());
            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Helper.Print("There was a Problem while i was trying to open the txt Document: " + ex.Message, ConsoleColor.Red);
            }
        }
        public void GetAllDepartMentsInNotepad()
        {
            Console.Clear();
            string size = Console.ReadLine();
            bool result = int.TryParse(size, out int givenCapacity);
            if (result)
            {
                StringBuilder departmentsStr = new();
                departmentsStr.AppendLine("Filtered Departments List:");
                foreach (Department department in departmentService.GetAll(givenCapacity))
                {
                    departmentsStr.Append($"{department} \n");
                }
            }
        }
    }
}
