using NorthwindModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.ViewModels
{
    public class EmployeeViewModel
    {
        public ICollection<Employee> Employees { get; set; }
        public string SearchPhrase { get; set; }
    }
}
