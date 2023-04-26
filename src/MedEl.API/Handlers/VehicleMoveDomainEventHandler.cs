using MediatR;

namespace MedEl.Domain.Events
{
    public class VehicleMoveDomainEventHandler : INotificationHandler<VehicleMoveDomainEvent>
    {
        private readonly ILogger<VehicleMoveDomainEventHandler> _logger;

        public VehicleMoveDomainEventHandler(ILogger<VehicleMoveDomainEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Handle(VehicleMoveDomainEvent notification, CancellationToken cancellationToken)
        {
            var vehicle = notification.Vehicle;
            var message = $"You are driving a {vehicle.Kind} from {vehicle.Brand}. ";
            var equipment = vehicle.GetEquipment();
            if (!string.IsNullOrEmpty(equipment))
            {
                message += $" Equipped with: {equipment}.";
            }
            
            _logger.LogInformation(message, vehicle);

            return Task.CompletedTask;
        }
    }
}