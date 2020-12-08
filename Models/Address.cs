using BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeckITEjendomsmæglerApplikation.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string Street { get; set; }
        public int Zipcode { get; set; }
        public int? PersonId { get; set; }
        [ForeignKey("PersonId")]
        public User User { get; set; }
        public int? BoligaID { get; set; }
        [ForeignKey("BoligaID")]
        public BoligaAddress Boliga { get; set; }
        public int? BoligsidenID { get; set; }
        [ForeignKey("BoligsidenID")]
        public BoligsidenAddress Boligsiden { get; set; }

    }
}

