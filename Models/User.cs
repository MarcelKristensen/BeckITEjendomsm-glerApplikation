using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class User 
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "First Name cannot exceed 30 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Last Name cannot exceed 30 characters")]
        public string LastName { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z0-9_.+-]+@[a-zA-z0-9-]+\.[a-zA-z0-9-.]+$", ErrorMessage = "Invalid Email format")]
        [MaxLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        public string Email { get; set; }

        public IList<Address> Address { get; set; }

    }
}
