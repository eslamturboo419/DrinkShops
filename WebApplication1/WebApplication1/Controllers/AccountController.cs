﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models.VM;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager , SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login(/*string returnUrl*/)
        {
            //LoginVM loginVM = new LoginVM()
            //{
            //    ReturnUrl = returnUrl
            //}; loginVM
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                //var user =await userManager.FindByNameAsync(loginVM.UserName);
                //if (user == null) { return NotFound(); }

              var result= await signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);
                if (result.Succeeded) 
                {
                    //if (string.IsNullOrEmpty(loginVM.ReturnUrl)) { return RedirectToAction("Index", "Home"); }

                    //return RedirectToAction(loginVM.ReturnUrl);

                    return RedirectToAction("Index", "Home");
                }
                
            }
            ModelState.AddModelError(string.Empty, "Password Or Email Not Found");
            return View(loginVM);
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registerVM.UserName, Email = registerVM.UserName };
                var result = await userManager.CreateAsync(user,registerVM.Password);

                if (result.Succeeded) {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Error Register , Try Again");
            }
            return View(registerVM);
        }


        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



    }
}
