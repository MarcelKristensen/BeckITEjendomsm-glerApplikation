using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class ApplicationUser : IdentityUser
    {
       // [Column("Id")]
       // public string UserId { get; set; }
        public string Name { get; set; }

        public string City { get; set; }

        public List<int> Zipcodes = new List<int>();
    }
}
