using EndProject.DataContext.Interfaces;
using EndProject.Domain;

namespace EndProject.DataContext.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        public bool Create(Department entity)
        {
            try
            {
                DbContext.Departments.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Department entity)
        {
            try
            {
                DbContext.Departments.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Department Get(Predicate<Department> filter)
        {
            return DbContext.Departments.Find(filter);
        }

        public List<Department> GetAll(Predicate<Department> filter = null)
        {
            return filter is null ? DbContext.Departments : DbContext.Departments.FindAll(filter);
        }

        public bool Update(Department entity)
        {
            try
            {
                Department existDepartment = DbContext.Departments.Find(d=>d.Id == entity.Id);
                existDepartment = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
