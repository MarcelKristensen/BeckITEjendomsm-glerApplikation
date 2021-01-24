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


        public List<BType> btList = new List<BType> {
            new BType("Villa", true),
            new BType("Ejerlejlighed", true),
            new BType("Rækkehus", true),
            new BType("Andelsbolig", true),
            new BType("Landejendom", true),
            new BType("Fritidsbolig", true),
            new BType("Villalejlighed", true),
            new BType("Helårsgrund", true),
            new BType("Fritidsgrund", true)
        };
        public List<Address> rList = new List<Address>();


    }

    public class BType
    {

        public BType(string tn, bool ic)
        {
            TName = tn;
            IsChecked = ic;
        }
        public string TName { get; set; }
        public bool IsChecked { get; set; }
    }
}
