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

        public int StartLiggetid { get; set; }

        public int Liggetid
        {
            get { return CalculateLiggetid(); } set { } }

        public DateTime DateOfInsertion { get; set; }

        [DisplayName("Boliga Link")]
        public int? BoligaID { get; set; }
        [ForeignKey("BoligaID")]
        public BoligaAddress Boliga { get; set; }

        [DisplayName("Boligsiden Link")]
        public int? BoligsidenID { get; set; }
        [ForeignKey("BoligsidenID")]
        public BoligsidenAddress Boligsiden { get; set; }

        public int? DocumentId { get; set; }
        [ForeignKey("DocumentId")]
        public Files File { get; set; }

        public int? BoligTypeID { get; set; }
        [ForeignKey("BoligTypeID")]
        public BoligType Type { get; set; }

        public int CalculateLiggetid()
        {
            DateTime doi = DateOfInsertion;
            DateTime don = DateTime.Now;
            TimeSpan interval = don - doi;
            return interval.Days;
        }
    }
}
