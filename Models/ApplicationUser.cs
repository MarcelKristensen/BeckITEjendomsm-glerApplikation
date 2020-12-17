using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string City { get; set; }

        public List<int> Zipcodes = new List<int>();
        //IdentityRole
    }
}
