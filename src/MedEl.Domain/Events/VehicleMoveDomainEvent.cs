using MedEl.Domain.Models.Vehicles;
using MediatR;

namespace MedEl.Domain.Events
{
    public record class VehicleMoveDomainEvent(Vehicle Vehicle) : INotification
    { }
}