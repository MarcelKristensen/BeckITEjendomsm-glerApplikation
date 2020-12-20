using BeckITEjendomsmæglerApplikation.Models;
using BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeckITEjendomsmæglerApplikation.ViewModels
{
    public class CreateAddressViewModel
    {
        public BoligaAddress BoligaAddresse { get; set; }
        public BoligsidenAddress BoligsidenAddresse { get; set; }
        public string BoligaStreet { get; set; }
        [Required]
        public string Street { get; set; }
        [MaxLength(4, ErrorMessage = "Postnummer kan ikke være mere end 4 karakterer")]
        [DisplayName("Postnummer")]
        public string Zipcode { get; set; }
        [DisplayName("Liggetid")]
        [Required]
        public int StartLiggetid { get; set; }

        public DateTime DateOfInsertion { get { return CalculateStartLiggetid(); } set { } }

        public DateTime CalculateStartLiggetid()
        {
            int startLiggetid = StartLiggetid;
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(-startLiggetid);
            return dt;
        }
    }
}
