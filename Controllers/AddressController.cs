using System;
using System.Threading.Tasks;
using BeckITEjendomsmæglerApplikation.DatabaseContext;
using BeckITEjendomsmæglerApplikation.Models;
using BeckITEjendomsmæglerApplikation.Models.AddressHyperlinks;
using BeckITEjendomsmæglerApplikation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    public class AddressController : Controller
    {

        private readonly ApplicationDbContext context;
        public AddressController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var addresses = context.Addresses
                .Include(c => c.Boliga)
                .Include(c => c.Boligsiden)
                .AsNoTracking();
            return View(await addresses.ToListAsync());
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                Address newAddress = new Address
                {
                    Street = model.Street,
                    Zipcode = model.Zipcode,
                    Boligsiden = model.BoligsidenAddresse,
                    Boliga = model.BoligaAddresse,
                    InsertDate = model.InsertDate = DateTime.Now
                };

                context.AddRange(newAddress);
                context.SaveChanges();
                return RedirectToAction("index", new { id = newAddress.AddressId });

            }

            return View();
        }
    }
}
