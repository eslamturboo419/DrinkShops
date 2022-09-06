using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.VM;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{

    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IDrinkRepostory drinkRepostory;
        private readonly ShoppingCart _shoppingCart;
        

        public ShoppingCartController(IDrinkRepostory drinkRepostory , ShoppingCart  shoppingCart)
        {
            this.drinkRepostory = drinkRepostory;
            this._shoppingCart = shoppingCart;
           
        }
         
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartVM
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(shoppingCartViewModel);
        }

         
        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = drinkRepostory.drinks.FirstOrDefault(p => p.DrinkId == drinkId);
            if (selectedDrink != null)
            {
                _shoppingCart.AddToCart(selectedDrink, 1);
            }
            return RedirectToAction("Index");
        }

       
        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = drinkRepostory.drinks.FirstOrDefault(p => p.DrinkId == drinkId);
            if (selectedDrink != null)
            {
                _shoppingCart.RemoveFromCart(selectedDrink);
            }
            return RedirectToAction("Index");
        }

    }
}
