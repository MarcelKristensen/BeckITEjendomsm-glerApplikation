using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Models
{
    [Table("BoligTyper")]
    public class BoligType
    {
        [Key]
        public int BoligTypeID { get; set; }
        [DisplayName("Boligsiden Link")]
        public string BoligTypeNavn { get; set; }
    }
}
