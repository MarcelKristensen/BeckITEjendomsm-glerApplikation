using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks
{
    public class BoligsidenAddress
    {
        [Key]
        public int BoligsidenID { get; set; }
        [DisplayName("Boligsiden")]
        public string BoligsidenHyperlink { get; set; }
    }
}
