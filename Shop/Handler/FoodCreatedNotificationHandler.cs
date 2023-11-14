using MediatR;
using Microsoft.Extensions.Logging;
using Shop.Notifications;
using System.Threading;
using System.Threading.Tasks;

namespace Shop.Handlers
{
    public class FoodCreatedNotificationHandler : INotificationHandler<FoodNotification>
    {
        private readonly ILogger<FoodCreatedNotificationHandler> _logger;

        public FoodCreatedNotificationHandler(ILogger<FoodCreatedNotificationHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(FoodNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Method {notification.Message} Has Been Called");
        }
    }
}