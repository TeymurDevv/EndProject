using EndProject.Business.Interfaces;
using EndProject.DataContext.Repositories;
using EndProject.Domain;
using EndProject.Helpers;

namespace EndProject.Business.Services
{
    public class EmployeeService:IEmployee
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly DepartmentRepository _departmentRepository;
        private static int Count = 1;
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _departmentRepository = new DepartmentRepository();
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public List<Employee> GetEmployeesByDepartment(string departmentName)
        {
            return _employeeRepository.GetAll(e=>e.Department.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Employee> GetAll(string name)
        {
            return _employeeRepository.GetAll(e=>e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public List<Employee> GetAll(int age)
        {
            return _employeeRepository.GetAll(e=>e.Age==age);
        }

        public List<Employee> GetAllEmployeesByDepartmentId(int departmentId)
        {
           return _employeeRepository.GetAll(e=>e.Department.Id==departmentId);
        }

        public Employee Create(Employee employee, string departmentName)
        {
            Department existDepartment = _departmentRepository
                .Get(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (existDepartment is null)
            {
                Helper.Print("The Employee with This name is not found", ConsoleColor.Red);
                return null;
            }
            employee.Id = Count;
            employee.Department = existDepartment;
            bool result = _employeeRepository.Create(employee);
            if (!result) return null;
            Count++;
            return employee;
        }

        public Employee Get(int id)
        {
            Employee existEmployee = _employeeRepository.Get(e=>e.Id==id);
            if (existEmployee is null) return null;
            return existEmployee;
        }

        public Employee Update(int id, Employee employee, string? departmentName)
        {
            var existEmployee = _employeeRepository.Get(e => e.Id == id);
            if (existEmployee is null) return null;
            var existDepartment = _departmentRepository.Get(d => d.Name == departmentName);
            if (existDepartment is null) return null;
            if (!string.IsNullOrEmpty(employee.Name))
            {
                existEmployee.Name = employee.Name;
            }
            if (!string.IsNullOrEmpty(employee.SurName))
            {
                existEmployee.SurName = employee.SurName;
            }
            if (!string.IsNullOrEmpty(employee.Adress))
            {
                existEmployee.Adress = employee.Adress;
            }
            existEmployee.Department = existDepartment;
            if (_employeeRepository.Update(existEmployee))
            {
                return existEmployee;
            }
            else
            {
                return null;
            }
        }

        public Employee Delete(int id)
        {
            Employee existEmployee  =_employeeRepository.Get(e=>e.Id==id);
            if (existEmployee is null) return null;
            bool result = _employeeRepository.Delete(existEmployee);
            if (result) return existEmployee;
            return null;
        }

    }
}
