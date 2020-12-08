using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeckITEjendomsmæglerApplikation.DatabaseContext;
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

        public async Task<IActionResult> Index()
        {
            var addresses = context.Addresses
                .Include(c => c.User)
                .Include(c => c.Boliga)
                .Include(c => c.Boligsiden)
                .AsNoTracking();
            return View(await addresses.ToListAsync());
        }
    }
}
