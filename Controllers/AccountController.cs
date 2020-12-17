using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeckITEjendomsmæglerApplikation.ViewModels;
using BeckITEjendomsmæglerApplikation.Models;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private Task<ApplicationUser> GetCurrentUserAsync() => userManager.GetUserAsync(HttpContext.User);
        public async Task<string> GetId()
        {
            ApplicationUser appUsr = await GetCurrentUserAsync();
            return appUsr.Id;
        }

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser()
        {
            string id = await GetId();
            ApplicationUser user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return RedirectToAction("index", "home");
            }
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> EditProfile()
        //{

        //    var user = await GetCurrentUserAsync();
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"Cannot find user";
        //        return View("NotFound");
        //    }

        //    //TODO indarbejd roller (og claims? undersøg)
        //    //var userClaims = await userManager.GetClaimsAsync(user);
        //    //var userRoles = await userManager.GetRolesAsync(user);


        //    var model = new EditProfileViewModel
        //    {
        //        Name = user.Name,
        //        Email = user.Email,
        //        City = user.City,
        //        PhoneNumber = user.PhoneNumber

        //    };
        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            string id = await GetId();
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Cannot find user";
                return View("NotFound");
            }
            else
            {
                //if (model.Name != null)
                //{
                //    user.Name = model.Name;
                //}
                //if (model.Email != null)
                //{
                //    user.Email = model.Email;
                //}
                //if (model.City != null)
                //{
                //    user.City = model.City;
                //}
                //if (model.PhoneNumber != null)
                //{
                //    user.PhoneNumber = model.PhoneNumber;
                //}
                user.Name = model.Name;
                user.Email = model.Email;
                user.City = model.City;
                user.PhoneNumber = model.PhoneNumber;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);

            }
            //var model = new EditProfileViewModel
            //{
            //    Name = user.Name,
            //    Email = user.Email,
            //    City = user.City,
            //    PhoneNumber = user.PhoneNumber

            //};
            
        }

        //[HttpPost]
        //public async Task<IActionResult> EditProfile(string id)
        //{
        //    var user = await userManager.FindByIdAsync(id);
        //    if (user == null)
        //    {
        //        ViewBag.ErrorMessage = $"Cannot find user";
        //        return View("NotFound");
        //    }

        //    var model = new EditProfileViewModel
        //    {
        //        Name = user.Name,
        //        Email = user.Email,
        //        City = user.City,
        //        PhoneNumber = user.PhoneNumber

        //    };
        //    return View(model);
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
