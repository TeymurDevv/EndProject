using EndProject.Business.Interfaces;
using EndProject.DataContext.Repositories;
using EndProject.Domain;

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
            throw new NotImplementedException();
        }

        public List<Employee> GetEmployeesByDepartment(string departmentName)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(string name)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(int age)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(byte departmentId)
        {
            throw new NotImplementedException();
        }

        public Employee Create(Employee employee, string departmentName)
        {
            Department existDepartment = _departmentRepository
                .Get(d => d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase));
            if (existDepartment is null) return null;
            employee.Id = Count;
            employee.Department = existDepartment;
            bool result = _employeeRepository.Create(employee);
            if (!result) return null;
            Count++;
            return employee;
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee employee, string? departmentName)
        {
            throw new NotImplementedException();
        }

        public Employee Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
