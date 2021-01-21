using System;
using System.Collections.Generic;
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
        public string BoligTypeNavn { get; set; }
    }
}
