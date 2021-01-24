using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class UserEdit
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Navn")]
        public string Name { get; set; }
        [DisplayName("By")]
        public string City { get; set; }
        [DisplayName("Tlf. nummer")]
        public string PhoneNumber { get; set; }
    }
}
