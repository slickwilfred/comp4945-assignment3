using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("FullNames")]
    public class FullName
    {
        [Key, ForeignKey("Person")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public virtual Person Person { get; set; }
    }
}