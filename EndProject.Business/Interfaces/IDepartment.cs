using EndProject.Domain;

namespace EndProject.Business.Interfaces
{
    public interface IDepartment
    {
        Department Create(Department department);
        Department Update(int id, Department department);
        Department Delete(int id);
        Department Get(int id);
        List<Department> GetAll();
        Department Get(string name);
        List<Department> GetAll(int capacity);

    }
}
