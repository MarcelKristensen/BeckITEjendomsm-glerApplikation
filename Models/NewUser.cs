using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class NewUser : ApplicationUser
    {
        public string UserRole { get; set; }
    }
}
