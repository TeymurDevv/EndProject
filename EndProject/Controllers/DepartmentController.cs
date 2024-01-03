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
        public void GetAllDepartments()
        {
            Console.Clear();
            Helper.Print("Department list :", ConsoleColor.Red);
            List<Department> departments = departmentService.GetAll();
            if (departments.Count > 0)
            {
                foreach (Department department in departments)
                {
                    Helper.Print($"{department}", ConsoleColor.Green);

                }
            }
            else
            {
                Helper.Print("Empty list", ConsoleColor.Red);

            }
            Thread.Sleep(3000);
            Helper.MainMenu();

        }
        public void UpdateDepartment()
        {
            Helper.Print("Enter Id",ConsoleColor.Yellow);
            int id = int.Parse(Console.ReadLine());
            Helper.Print("Enter capacity:",ConsoleColor.Yellow);
            int capacity = int.Parse(Console.ReadLine());
            Helper.Print("Enter Department Name: ",ConsoleColor.Yellow);
            string departmentName = Console.ReadLine();
            Department existDepartment = departmentService.Get(id);
            if (existDepartment is not null) 
            {
                Department newDepartment = new() { Name = departmentName, Capacity = capacity };
                departmentService.Update(id, newDepartment);
                Helper.Print($"Department {existDepartment.Name} was Successfully Updated", ConsoleColor.Green);
            }
            else
            {
                Helper.Print("There is no Department to update in this Id", ConsoleColor.Red);
            }


        }
        public void DeleteDepartment()
        {
            Console.Clear();
            Helper.Print("Enter Id:", ConsoleColor.Yellow);
            IdInput: string givenId = Console.ReadLine();
            bool result = int.TryParse(givenId, out int id);
            Department existDepartment = departmentService.Get(id);
            if (result && existDepartment is not null)
            {
               departmentService.Delete(id);
               Helper.Print("Department Deleted", ConsoleColor.Green);
               Thread.Sleep(1000);
               Helper.MainMenu();
            }
            else if (result && existDepartment is null)
            {
                Helper.Print("There is no Department to delete with this Id", ConsoleColor.Red);
                Thread.Sleep(1000);
                Helper.MainMenu();
            }
            else
            {
                Helper.Print("The Format of Id is not valid", ConsoleColor.Red);
                goto IdInput;
            }
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
            Thread.Sleep(1000);
            Helper.MainMenu();
        }
        public void GetAllFilteredDepartmentsInNotepad()
        {
            Console.Clear();
            Helper.Print("Enter Capacity", ConsoleColor.Yellow);
            SizeInput: string size = Console.ReadLine();
            bool result = int.TryParse(size, out int givenCapacity);
            if (result)
            {
                StringBuilder departmentsStr = new();
                departmentsStr.AppendLine("Filtered Departments List:");
                foreach (Department department in departmentService.GetAll(givenCapacity))
                {
                    departmentsStr.Append($"{department} \n");
                }
                string path = "C:\\Users\\TeymurDevv\\Desktop\\C# Projects\\EndProject\\Assets\\FilteredDepartments.txt";
                File.WriteAllText(path, departmentsStr.ToString());
                try
                {
                    Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    Helper.Print("There was a Problem while i was trying to open the txt Document: " + ex.Message, ConsoleColor.Red);
                }
                Thread.Sleep(1000);
                Helper.MainMenu();
            }
            else
            {
                Helper.Print("Please enter the Size Properly", ConsoleColor.Red);
                goto SizeInput;
            }
        }

    }
}
