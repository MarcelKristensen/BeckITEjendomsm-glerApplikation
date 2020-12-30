using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.ViewModels
{
    public class SearchViewModel
    {
        public string Query { get; set; }

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
