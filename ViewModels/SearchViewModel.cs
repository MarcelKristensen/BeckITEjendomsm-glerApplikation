using BeckITEjendomsmæglerApplikation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.ViewModels
{
    public class SearchViewModel
    {
        [DisplayName("Søgning")]
        public string Query { get; set; }
        [DisplayName("Min Liggetid")]
        public int StLiggetid { get; set; }
        [DisplayName("Max Liggetid")]
        public int SlLiggetid { get; set; }
        public bool Andelsbolig { get; set; }
        public bool Ejerlejlighed { get; set; }
        public bool Fritidsbolig { get; set; }
        public bool Fritidsgrund { get; set; }
        public bool Helårsgrund { get; set; }
        public bool Landejendom { get; set; }
        public bool Rækkehus { get; set; }
        public bool Villa { get; set; }
        public bool Villalejlighed { get; set; }

        public List<Address> rList = new List<Address>();
    }
}
