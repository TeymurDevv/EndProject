using EndProject.Domain.Common;

namespace EndProject.Domain
{
    public class Employee:BaseEntity
    {
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public Department Department { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} SurName: {SurName} Age: {Age} Adress: {Adress} Department: {Department.Name}";
        }
    }
}
