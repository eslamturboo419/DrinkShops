using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.VM;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDrinkRepostory drinkRepostory;

        public HomeController(ILogger<HomeController> logger , IDrinkRepostory drinkRepostory)
        {
            _logger = logger;
            this.drinkRepostory = drinkRepostory;
        }

        public IActionResult Index()
        {
            DrinkVM drinkVM = new DrinkVM()
            {
                 Drinks = drinkRepostory.PrefereDrinks 
            };

            return View(drinkVM);
        }


        public IActionResult ContactUs()
        {
            return View();
        }

         



    }
}
