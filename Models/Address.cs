using BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeckITEjendomsmæglerApplikation.Models
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        [DisplayName("Adresse")]
        public string Street { get; set; }
        [DisplayName("Postnummer")]
        public string Zipcode { get; set; }
        [DisplayName("Boliga Link")]
        public int? BoligaID { get; set; }
        [ForeignKey("BoligaID")]
        public BoligaAddress Boliga { get; set; }
        [DisplayName("Boligsiden Link")]
        public int? BoligsidenID { get; set; }
        [ForeignKey("BoligsidenID")]
        public BoligsidenAddress Boligsiden { get; set; }
        public int StartLiggetid { get; set; }
        public DateTime DateOfInsertion { get; set; }
        public int? Liggetid { get; set; }

        public int BoligTypeID { get; set; }
        [ForeignKey("BoligTypeID")]
        public BoligType Type { get; set; }

        //public bool Villa { get; set; }
        //public bool Ejerlejlighed { get; set; }
        //public bool Andelsbolig { get; set; }
        //public bool Helårsgrund { get; set; }
        //public bool Villalejlighed { get; set; }
        //public bool Rækkehus { get; set; }
        //public bool Fritidsbolig { get; set; }
        //public bool Landejendom { get; set; }
        //public bool Fritidsgrund { get; set; }

        public DateTime CalculateStartLiggetid()
        {
            int startLiggetid = StartLiggetid;
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(-startLiggetid);
            return dt;
        }

        public int CalculateLiggetid()
        {
            DateTime StartDate = DateOfInsertion;
            DateTime CurrentDate = DateTime.Now;
            TimeSpan interval = (CurrentDate - StartDate);
            return interval.Days;
        }


    }
}