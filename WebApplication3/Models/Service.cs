using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace WebApplication3.Models
{
    public class Service
    {
        public Service()
        {
            this.Customers = new HashSet<Customer>();
            this.Employees = new HashSet<Employee>();

        }

        [Key]
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection <Employee> Employees { get; set; }
       
    }


    // [Key] used to set a key when not using Id keyword
}