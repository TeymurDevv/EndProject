using EndProject.Domain;

namespace EndProject.DataContext
{
    public static class DbContext
    {

        public static List<Employee> Employees { get; set; }
        public static List<Department> Departments { get; set; }

        static DbContext() 
        {
            
            Employees = new List<Employee>();
            Departments = new List<Department>();

        }
    }
}
