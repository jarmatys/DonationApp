using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonationApp.Models.Db;
using DonationApp.Models.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DonationApp.Context
{
    public class AccountController : Controller
    {
        protected UserManager<UserApp> UserManager { get; }
        protected SignInManager<UserApp> SignInManager { get; }

        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Error = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserApp
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Surname = model.Surname,
                    Email = model.Email,
                };

                var result = await UserManager.CreateAsync(user, model.Password);   //sprawdzenie hasła

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false);   //zalogowanie od razu po rejestracji
                    return RedirectToAction("login", "account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.Error = true;
            return View(model);
        }


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
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Invalid login attempt!");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}