using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.ViewModels
{
    public class EditProfileViewModel
    {



        //TODO Ændring af email skal kræve en autorizering fra mail adressen? Username == Email (opdateres username automatisk?)
        [EmailAddress]
        public string Email { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        //TODO find en måde at lave en liste med zipkoder på siden. Hvordan skal den sættes op? Liste med create og delete knapper?
        //public EditProfileViewModel()
        //{
        //    Zipcodes = new List<int>();
        //}                

        //public List<int> Zipcodes { get; set; }
    }
}
