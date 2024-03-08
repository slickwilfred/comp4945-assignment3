using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
    }
}