using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models.Domain
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        [Display(Name = "Customer")]
        public Guid CustomerId { get; set; }

        [ForeignKey("CustomreId")]
        public virtual Customer Csutomer { get; set; }
        public string OrderQuntity { get; set; }

        public DateTime PickUpDate { get; set; }

    }
}
