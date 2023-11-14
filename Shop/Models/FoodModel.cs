using System.ComponentModel.DataAnnotations;
using Shop.Models.Domain;

namespace Shop.Models
{
    public class FoodModel
    {
        [Required]
        public string FoodName { get; set; }

        public string FoodQuantity { get; set; }

        public double FoodPrice { get; set; }

        [Required]
        public Category.category FoodCatagory { get; set; }
    }
}
