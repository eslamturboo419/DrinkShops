using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models.Components
{
    public class CategoryMenu:ViewComponent
    {
        private readonly ICategoryRepostory categoryRepostory;

        public CategoryMenu(ICategoryRepostory categoryRepostory)
        {
            this.categoryRepostory = categoryRepostory;
        }

        public IViewComponentResult Invoke()
        {
            var val = categoryRepostory.categories.OrderBy(x => x.CategoryName);
            return View(val);
        }
        


    }
}
