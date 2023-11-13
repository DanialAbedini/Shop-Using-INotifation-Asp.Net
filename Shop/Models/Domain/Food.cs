using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Domain
{
    public class Food
    {
        [Key]
        public Guid FoodID { get; set; }

        [Required]
        public string FoodName { get; set; }

        public string FoodQuantity { get; set; }

        public double FoodPrice { get; set; }

        [Required]
        public Category.category FoodCatagory { get; set; }


    }
}
