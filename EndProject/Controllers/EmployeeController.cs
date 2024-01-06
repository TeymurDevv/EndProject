using EndProject.Business.Services;
using EndProject.DataContext;
using EndProject.Domain;
using EndProject.Helpers;

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
                Employee employee = new() {Name = name, SurName = surName,Adress = adres, Age = (byte)age,CreatedAt = DateTime.Now};
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
        public void GetEmployeeById()
        {
            Console.Clear();
            Helper.Print("Enter Employee Id", ConsoleColor.Yellow);
            IdInput: string givenId = Console.ReadLine();
            bool result = int.TryParse(givenId, out int id);
            if (result)
            {
                Employee existEmployee = employeeService.Get(id);
                if (existEmployee is not null)
                {
                    Helper.Print($"{existEmployee}", ConsoleColor.Green);
                }
                else
                {
                    Helper.Print("Employee with this Id is not found", ConsoleColor.Red);
                }
                Thread.Sleep(1000);
                Helper.MainMenu();

            }
            else
            {
                Helper.Print("Id Format is not valid", ConsoleColor.Red);
                goto IdInput;
            }
        }
        public void UpdateEmployee()
        {
            Console.Clear();
            Helper.Print("Enter Id", ConsoleColor.Yellow);
            IdInput: string givenId = Console.ReadLine();
            bool result = int.TryParse(givenId, out int id);
            Helper.Print("Enter Age:", ConsoleColor.Yellow);
            string givenAge = Console.ReadLine();
            bool aResult = int.TryParse(givenAge, out int age);
            Helper.Print("Enter Employee Name:", ConsoleColor.Yellow);
            string name = Console.ReadLine();
            Helper.Print("Enter Employee  SurName: ", ConsoleColor.Yellow);
            string surName = Console.ReadLine();
            Helper.Print("Enter Employee Adress: ", ConsoleColor.Yellow);
            string adress = Console.ReadLine();
            Helper.Print("Enter Employee Department: ", ConsoleColor.Yellow);
            string departmentName = Console.ReadLine();
            if (result && aResult && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surName) && !string.IsNullOrEmpty(adress) && !string.IsNullOrEmpty(departmentName))
            {
                Employee existEmployee = employeeService.Get(id);
                if (existEmployee is not null)
                {
                    Employee newEmployee = new() { Name = name, SurName = surName,Adress = adress,Age = (byte)age,UpdatedAt=DateTime.Now};
                    Employee updatedEmployee = employeeService.Update(id, newEmployee,departmentName);
                    if (updatedEmployee is not null)
                    {
                        Helper.Print($"Employee {existEmployee.Name} was Successfully Updated", ConsoleColor.Green);
                    }
                }
                else
                {
                    Helper.Print("There is no Employee to update in this Id", ConsoleColor.Red);
                }
            }
            else
            {
                Helper.Print("Input Fields Format is Invalid", ConsoleColor.Red);
            }
            Thread.Sleep(1000);
            Helper.MainMenu();
        }
        public void DeleteEmployee() 
        {
            Console.Clear();
            Helper.Print("Enter Id:", ConsoleColor.Yellow);
            IdInput: string givenId = Console.ReadLine();
            bool result = int.TryParse(givenId, out int id);
            Employee existEmployee = employeeService.Get(id);
            if (result && existEmployee is not null)
            {
                departmentService.Delete(id);
                Helper.Print("Employee Deleted", ConsoleColor.Green);
                Thread.Sleep(1000);
                Helper.MainMenu();
            }
            else if (result && existEmployee is null)
            {
                Helper.Print("There is no Employee to delete with this Id", ConsoleColor.Red);
                Thread.Sleep(1000);
                Helper.MainMenu();
            }
            else
            {
                Helper.Print("The Format of Id is not valid", ConsoleColor.Red);
                goto IdInput;
            }
        }
        public void GetAllEmployeesByAge()
        {
            Console.Clear();
            Helper.Print("Enter Employee Age", ConsoleColor.Yellow);
            AgeInput: string givenAge = Console.ReadLine();
            bool result = int.TryParse(givenAge, out int age);
            if (result)
            {
                List<Employee> employees = employeeService.GetAll(age);
                if (employees.Count > 0)
                {
                    foreach (Employee employee in employees)
                    {
                        Helper.Print($"{employee}", ConsoleColor.Green);
                    }
                }
                else
                {
                    Helper.Print("Empty List",ConsoleColor.Red);
                }
            }
            else
            {
                Helper.Print("Input Fields is not in Correct Format", ConsoleColor.Red);
                goto AgeInput;
            }
            Thread.Sleep(5000);
            Helper.MainMenu();
        }
        public void GetAllEmployeesByDepartmentId() 
        {
            Console.Clear();
            Helper.Print("Enter Department Id:", ConsoleColor.Yellow);
            IdInput: string givenId = Console.ReadLine();
            bool result = int.TryParse(givenId, out int id);
            if (result)
            {
                Department existDepartment = departmentService.Get(id);
                if (existDepartment is not null)
                {
                    List<Employee> employeesList = employeeService.GetAllEmployeesByDepartmentId(1);
                    if (employeesList.Count > 0)
                    {
                        foreach (Employee employee in employeesList)
                        {
                            Helper.Print($"{employee}", ConsoleColor.Green);
                        }
                    }
                    else
                    {
                        Helper.Print("Empty List", ConsoleColor.Red);
                    }
                }
                else
                {
                    Helper.Print("Department with this Id is not Found", ConsoleColor.Red);
                }
            }          else
            {
                Helper.Print("The Input Fields Format is not valid", ConsoleColor.Red);
                goto IdInput;
            }
            Thread.Sleep(1000);
            Helper.MainMenu();
        }
        public void GetAllEmployeesByDepartmentName() 
        {
            Console.Clear();
            Helper.Print("Enter Department Name:", ConsoleColor.Yellow);
            departmentNameInput: string departmentName = Console.ReadLine();
            if (!string.IsNullOrEmpty(departmentName))
            {
                Department existDepartment = departmentService.Get(departmentName);
                if (existDepartment is not null ) 
                {
                    List<Employee> employeesList = employeeService.GetEmployeesByDepartment(departmentName);
                    if (employeesList.Count>0)
                    {
                        foreach (Employee employee in employeesList)
                        {
                            Helper.Print($"{employee}", ConsoleColor.Green);
                        }
                    }
                    else
                    {
                        Helper.Print("Empty List", ConsoleColor.Red);
                    }
                }
                else
                {
                    Helper.Print("Department with this Name is not found", ConsoleColor.Red);
                }
            }
            else
            {
                Helper.Print("Input Fields is not in Correct Format", ConsoleColor.Red);
                goto departmentNameInput;
            }
            Thread.Sleep(5000);
            Helper.MainMenu();
        }
        public void GetAllEmployeesByName() 
        {
            Console.Clear();
            Helper.Print("Enter Employee Name", ConsoleColor.Yellow);
            nameInput: string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                List<Employee> employeeslist = employeeService.GetAll(name);
                if (employeeslist.Count > 0)
                {
                    foreach (Employee employee in employeeslist)
                    {
                        Helper.Print($"{employee}", ConsoleColor.Green);
                    }
                }
                else
                {
                    Helper.Print("Empty List", ConsoleColor.Red);
                }
            }
            else
            {
                Helper.Print("Input Fields Format is not valid",ConsoleColor.Red);
                goto nameInput;
            }
            Thread.Sleep(5000);
            Helper.MainMenu();
        }
        public void GetAllEmployeesCount()
        {
            Helper.Print($"{DbContext.Employees.Count} Employees Have Registered in the System", ConsoleColor.Green);
        }
    }
}
