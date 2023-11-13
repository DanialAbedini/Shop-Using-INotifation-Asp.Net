using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shop.Models.Domain
{
    [Keyless]
    public class OrderItem
    {
        [Display(Name = "Order")]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order order { get; set; }

        [Display(Name = "Food")]
        public Guid FoodId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Food food { get; set; }

        public double UnitPrice { get; set; }
    }
}
