using EndProject.Domain;

namespace EndProject.Business.Interfaces
{
    public interface  IEmployee
    {
        List<Employee> GetAll();
        List<Employee> GetEmployeesByDepartment(string departmentName);
        List<Employee> GetAll(string name);
        List<Employee> GetAll(int age);
        List<Employee> GetAllEmployeesByDepartmentId(int departmentId);

        Employee Create(Employee employee, string departmentName);
        Employee Get(int id);
        Employee Update(int id, Employee employee, string? departmentName);
        Employee Delete(int id);

    }
}
