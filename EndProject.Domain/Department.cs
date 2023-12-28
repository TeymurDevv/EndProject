using EndProject.Domain.Common;

namespace EndProject.Domain
{
    public class Department:BaseEntity
    {
        public int Capacity { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Capacity: {Capacity}";
        }
    }
}
