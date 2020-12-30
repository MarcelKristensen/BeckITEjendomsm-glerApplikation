using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeckITEjendomsmæglerApplikation.ViewModels;
using BeckITEjendomsmæglerApplikation.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeckITEjendomsmæglerApplikation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> DeleteUser()
        {
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("NotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    await signInManager.SignOutAsync();
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

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            //string id = await GetId();
            ApplicationUser user = await userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Cannot find user";
                return View("NotFound");
            }
            else
            {
                if (!String.IsNullOrEmpty(model.Name))
                {
                    user.Name = model.Name;
                }
                if (!String.IsNullOrEmpty(model.Email))
                {
                    user.Email = model.Email;
                }
                if (!String.IsNullOrEmpty(model.City))
                {
                    user.City = model.City;
                }
                if (!String.IsNullOrEmpty(model.PhoneNumber))
                {
                    user.PhoneNumber = model.PhoneNumber;
                }
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
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = new NewUser { UserName = model.Email, Email = model.Email, UserRole = model.UserRole};
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, model.UserRole);
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
