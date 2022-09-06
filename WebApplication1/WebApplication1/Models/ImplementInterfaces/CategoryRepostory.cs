using System.Collections.Generic;
using WebApplication1.Models.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Models.ImplementInterfaces
{
    public class CategoryRepostory : ICategoryRepostory
    {
        private readonly MyDbContext db;

        public CategoryRepostory(MyDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> categories => db.Categories;
    }
}
