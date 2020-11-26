using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int Zipcode { get; set; }
        public string Hyperlink { get; set; }
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public User User { get; set; }
    }
}

