using BeckITEjendomsmæglerApplikation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        public EditProfileController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]


        public IActionResult Index()
        {
            return View();
        }
    }
}
