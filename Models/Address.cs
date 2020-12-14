﻿using BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks;
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
        public DateTime? InsertDate { get; set; }
        [DisplayName("Liggetid")]
        public DateTime? CurrentDate { get; set; } 
    }
}

