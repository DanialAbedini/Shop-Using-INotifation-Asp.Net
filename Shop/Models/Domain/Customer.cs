using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Domain
{
    public class Customer
    {
        [Key]
        public Guid CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhone { get; set; }
    }
}
