using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using WebApplication1.Models;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepostory orderRepostory;
        private readonly ShoppingCart shoppingCart;

        public OrderController(IOrderRepostory orderRepostory , ShoppingCart shoppingCart)
        {
            this.orderRepostory = orderRepostory;
            this.shoppingCart = shoppingCart;
        }

        [HttpGet]
        [Authorize]
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (ModelState.IsValid)
            {
                var items = shoppingCart.GetShoppingCartItems();
                shoppingCart.ShoppingCartItems = items;

                if(shoppingCart.ShoppingCartItems.Count == 0) { ModelState.AddModelError("Empty", "This cart Is Empty"); }

                order.Email = User.Identity.Name.ToString() ;
                orderRepostory.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }

            return View(order);
        }

        [Authorize]
        public IActionResult CheckOutComplete()
        {
            ViewBag.CompleteMessage = "Thanks For Ordering";
            
            return View();
           

        }



    }
}
