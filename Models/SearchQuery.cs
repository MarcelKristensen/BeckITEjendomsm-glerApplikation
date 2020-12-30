using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Models
{
    public class SearchQuery
    {
        public string Query { get; set; }
        //public string Street { get; set; }
        //public string Zipcode { get; set; }
        ////public string City { get; set; }
        ////public string County { get; set; }
        ////public string Landsdel { get; set; }
        //public int Price { get; set; }
        //public int Liggetid { get; set; }

        public bool Andelsbolig { get; set; }        
        public bool Ejerlejlighed { get; set; }
        public bool Fritidsbolig { get; set; }
        public bool Fritidsgrund { get; set; }
        public bool Helårsgrund { get; set; }
        public bool Landejendom { get; set; }
        public bool Rækkehus { get; set; }
        public bool Villa { get; set; }
        public bool Villalejlighed { get; set; }
    }
}
