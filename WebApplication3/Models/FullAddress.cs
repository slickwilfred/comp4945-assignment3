using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    [System.ComponentModel.DataAnnotations.Schema.Table("FullAddresses")]
    public class FullAddress
    {
        [Key, ForeignKey("Person")] // Same key for the Person and the same key for the Address, Fullname, etc
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }
        public String Street { get; set; }
        public String City { get; set; }    
        public String Province { get; set; }
        public virtual Person Person { get; set; } // user doesn't konw its enttity framework - user goes to a student 
        // lets suppose you have link to their haddress -- click on it and new form comes up with that
        // we want to find whose address this is
        // this decarlation will create a pointer that will be a back reference - if you don't you wont be able ot go from address to person
        // this means the full address has a pointer to student
        // when you have accesss to this you can access the student pointer
    }
}