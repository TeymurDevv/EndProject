using EndProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndProject.Domain
{
    public class Employee:BaseEntity
    {
        public string SurName { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public Department Department { get; set; }
    }
}
