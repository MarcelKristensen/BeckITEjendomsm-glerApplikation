using BeckITEjendomsmæglerApplikation.DatabaseContext;
using BeckITEjendomsmæglerApplikation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly ApplicationDbContext context;
        public FileUploadController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var files = context.Files
                .AsNoTracking();
            return View(await files.ToListAsync());
        }
    }
}