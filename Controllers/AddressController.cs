using System;
using System.IO;
using System.Threading.Tasks;
using BeckITEjendomsmæglerApplikation.DatabaseContext;
using BeckITEjendomsmæglerApplikation.Models;
using BeckITEjendomsmæglerApplikation.ViewModels;
using Microsoft.AspNetCore.Http;
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
        //GET
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

        //POST
        [HttpPost]
        public IActionResult Create(CreateAddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                Address newAddress = new Address
                {
                    Street = model.Street,
                    Zipcode = model.Zipcode,
                    StartLiggetid = model.StartLiggetid,
                    Boligsiden = model.BoligsidenAddresse,
                    Boliga = model.BoligaAddresse,
                    DateOfInsertion = model.DateOfInsertion
                };

                context.AddRange(newAddress);
                context.SaveChanges();
                return RedirectToAction("index", new { id = newAddress.AddressId });

            }

            return View();
        }

        [HttpGet]
        public ViewResult Upload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile files)
        {
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new Files()
                    {
                        DocumentId = 0,
                        Name = newFileName,
                        FileType = fileExtension,
                        CreatedOn = DateTime.Now
                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.DataFiles = target.ToArray();
                    }

                    context.Files.Add(objfiles);
                    context.SaveChanges();

                }
            }
            return View();
        }

        //DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            var address = await context.Addresses.FindAsync(id);
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
