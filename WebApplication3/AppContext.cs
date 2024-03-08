using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Default Connection")
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Service> Services { get; set; }
        
    }
}