using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Drink
    {

        public int DrinkId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbilUrl { get; set; }
        public bool IsPreferDrink { get; set; }
        public bool InStock { get; set; }

        public Category Category  { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

    }
}
