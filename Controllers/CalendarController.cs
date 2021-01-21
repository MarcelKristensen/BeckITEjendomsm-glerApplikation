using BeckITEjendomsmæglerApplikation.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using BeckITEjendomsmæglerApplikation.Models;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    public class CalendarController : Controller
    {
        private readonly ApplicationDbContext context;
        public CalendarController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
