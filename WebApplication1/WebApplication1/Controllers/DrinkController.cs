using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models.VM;



namespace WebApplication1.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinkRepostory drinkRepostory;
        private readonly ICategoryRepostory categoryRepostory;

        public DrinkController(IDrinkRepostory drinkRepostory, ICategoryRepostory categoryRepostory)
        {
            this.drinkRepostory = drinkRepostory;
            this.categoryRepostory = categoryRepostory;
        }

        // try to use async Task<IActionResult> coz it's better performance on production
        // and will make ur api can proses more requests
        public IActionResult List(string category)// ToDo you need to change this to accept the enum instead coz developer can make a typo which will break the work flow
        {

            string _category = category;
            IEnumerable<Drink> drinks;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = drinkRepostory.drinks.OrderBy(p => p.DrinkId);
                currentCategory = "All drinks";
            }
            else
            {
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase))
                    drinks = drinkRepostory.ByType(DrinkType.Alcoholic); // the old code was getting all rows from the DB then appling the condetions in the memory 
                else
                    drinks = drinkRepostory.drinks.ByType(DrinkType.NonAlcoholic);

                currentCategory = _category;
            }
            @ViewBag.Current = currentCategory;
            return View(drinks);
        }



    }
}
