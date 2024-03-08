using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Employee : Person
    {
        public virtual Service Service { get; set; }

    }
}