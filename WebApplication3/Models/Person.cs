﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public abstract class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}