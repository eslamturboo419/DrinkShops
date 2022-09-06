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

        public IActionResult List(string category)
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
                    drinks = drinkRepostory.drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p => p.Name);
                else
                    drinks = drinkRepostory.drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);

                currentCategory = _category;
            }
            @ViewBag.Current = currentCategory;
            return View(drinks);
        }



    }
}
