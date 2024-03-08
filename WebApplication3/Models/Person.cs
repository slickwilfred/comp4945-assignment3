using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("People")]
    public abstract class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public FullName Name { get; set; }
        public FullAddress Address { get; set; }
    }
}