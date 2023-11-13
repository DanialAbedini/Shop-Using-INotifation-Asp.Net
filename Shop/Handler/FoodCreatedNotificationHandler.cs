using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Handlers
{
    public class FoodCreatedNotificationHandler : INotificationHandler<FoodCreatedNotification>
    {
        private readonly ILogger<FoodCreatedNotificationHandler> _logger;

        public FoodCreatedNotificationHandler(ILogger<FoodCreatedNotificationHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(FoodCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Food with ID {notification.FoodId} has been created.");
        }
    }
}