using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models.Interfaces;

namespace WebApplication1.Models.ImplementInterfaces
{
    public class DrinkRepository : IDrinkRepostory
    {
        private readonly MyDbContext db;

        public DrinkRepository(MyDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Drink> drinks => db.Drinks.Include(x=>x.Category);

        public IEnumerable<Drink> PrefereDrinks =>  db.Drinks.Where(x=>x.IsPreferDrink).Include(x=>x.Category);

        public Drink GetDrinkById(int DrinkId)
        {
            return db.Drinks.Where(x => x.DrinkId == DrinkId).FirstOrDefault();
        }
    }
}
