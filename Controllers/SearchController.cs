using BeckITEjendomsmæglerApplikation.DatabaseContext;
using BeckITEjendomsmæglerApplikation.Models;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchQuery search)
        {
            //var result = new Address();
            var resultList = new List<Address>();
            var finalList = new List<Address>();
            if (search.Andelsbolig == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Andelsbolig == true))
                {
                    resultList.Add(n);
                }                
            }
            if (search.Ejerlejlighed == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Ejerlejlighed == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Fritidsbolig == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Fritidsbolig == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Fritidsgrund == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Fritidsgrund == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Helårsgrund == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Helårsgrund == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Landejendom == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Landejendom == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Rækkehus == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Rækkehus == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Villa == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Villa == true))
                {
                    resultList.Add(n);
                }
            }
            if (search.Villalejlighed == true)
            {
                foreach (var n in _context.Addresses.Where(s => s.Villalejlighed == true))
                {
                    resultList.Add(n);
                }
            }

            if (!String.IsNullOrEmpty(search.Query))
            {
                foreach (var n in resultList)
                {
                    if (n.Street.Contains(search.Query) || n.Zipcode.Contains(search.Query)/* || n.City.Contains(search.Query) || n.County.Contains(search.Query) || n.Landsdel.Contains(search.Query)*/)
                    {
                        finalList.Add(n);
                    }
                }
                return View(finalList);
            }
            else
            {
                return View(resultList);
            }
        }
    }
}
