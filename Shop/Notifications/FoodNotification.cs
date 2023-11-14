using MediatR;

namespace Shop.Notifications
{
    public class FoodNotification:INotification
    {
        public Guid FoodId { get; set; }
        public string Message { get; set; }

    }
}
