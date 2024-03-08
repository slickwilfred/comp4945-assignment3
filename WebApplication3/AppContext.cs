using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication3
{
    public class AppContext : DbContext
    {
        public AppContext() : base("Default Connection")
        {
        }
    }
}