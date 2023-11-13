using MediatR;

namespace Shop.Notifications
{
    public class FoodCreatedNotification:INotification
    {
        public Guid FoodId { get; set; }

    }
}
