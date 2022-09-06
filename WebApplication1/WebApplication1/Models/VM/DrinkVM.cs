using System.Collections.Generic;

namespace WebApplication1.Models.VM
{
    public class DrinkVM
    {

        public IEnumerable<Drink> Drinks  { get; set; }


        public string CurrentCategory { get; set; }

    }
}
