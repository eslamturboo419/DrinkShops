using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class OrderDetail
    {

        public int OrderDetailId { get; set; }
     
        public int Amount { get; set; }
        public decimal Price { get; set; }
        
        
        public  Drink Drink { get; set; }
        [ForeignKey("Drink")]
        public int DrinkId { get; set; }

        public  Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }


    }
}
