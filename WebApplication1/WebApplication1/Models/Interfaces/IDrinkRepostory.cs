using System.Collections.Generic;

namespace WebApplication1.Models.Interfaces
{
    public interface IDrinkRepostory
    {

        IEnumerable<Drink> drinks { get; }

        IEnumerable<Drink> PrefereDrinks { get; }


        Drink GetDrinkById(int DrinkId);

    }
}
