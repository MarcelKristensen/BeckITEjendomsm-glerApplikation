using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks
{
    public class BoligaAddress
    {
        [Key]
        public int BoligaID { get; set; }
        [DisplayName("Boliga")]
        public string BoligaHyperlink { get; set; }
        public IList<Address> Address { get; set; }
    }
}
