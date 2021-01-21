using BeckITEjendomsmæglerApplikation.DatabaseContext;
using BeckITEjendomsmæglerApplikation.Models;
using BeckITEjendomsmæglerApplikation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Search()
        {
            SearchViewModel m = new SearchViewModel();
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {


                var addresses = _context.Addresses
                .Include(c => c.Boliga)
                .Include(c => c.Boligsiden)
                .Include(c => c.Type)
                .AsNoTracking();
                var addList = await addresses.ToListAsync();
                var resultList = new List<Address>();

                if (model.Andelsbolig == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Andelsbolig"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Ejerlejlighed == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Ejerlejlighed"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Fritidsbolig == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Fritidsbolig"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Fritidsgrund == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Fritidsgrund"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Helårsgrund == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Helårsgrund"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Landejendom == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Landejendom"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Rækkehus == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Rækkehus"))
                    {
                        resultList.Add(n);
                    }
                }
                if (model.Villa == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Villa"))
                    {
                        resultList.Add(n);
                    }

                }
                if (model.Villalejlighed == true)
                {
                    foreach (var n in addList.Where(s => s.Type.BoligTypeNavn == "Villalejlighed"))
                    {
                        resultList.Add(n);
                    }
                }

                resultList = resultList.Where(x => x.Liggetid >= model.StLiggetid & x.Liggetid <= model.SlLiggetid).ToList();

                if (!String.IsNullOrEmpty(model.Query))
                {
                    resultList = resultList.Where(x => x.Street.ToLower().Contains(model.Query.ToLower())
                                                        || x.Zipcode.Contains(model.Query.ToLower())
                                                        /*|| x.City.Contains(model.Query.ToLower())*/
                                                        /*|| x.County.Contains(model.Query.ToLower())*/
                                                        /*|| x.Landsdel.Contains(model.Query.ToLower())*/).ToList();
                }
                model.rList = resultList;
                return View(model);
            }
            return View(model);
        }
    }
}


