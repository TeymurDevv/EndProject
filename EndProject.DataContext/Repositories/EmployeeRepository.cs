using EndProject.DataContext.Interfaces;
using EndProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndProject.DataContext.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                DbContext.Employees.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                DbContext.Employees.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee Get(Predicate<Employee> filter)
        {
            return DbContext.Employees.Find(filter);
        }

        public List<Employee> GetAll(Predicate<Employee> filter = null)
        {
            return filter is null ? DbContext.Employees : DbContext.Employees.FindAll(filter);
        }

        public bool Update(Employee entity)
        {
            try
            {
                Employee existEmployee = Get(e=>e.Id == entity.Id);
                existEmployee = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
