using System.Collections.Generic;
using System.Text.Json.Serialization;
using MediatR;

namespace MedEl.Domain.Models.Vehicles
{
    public abstract class Entity
    {
        public int Id { get; }

        private List<INotification> _domainEvents;
        [JsonIgnore]
        public IEnumerable<INotification> DomainEvents => _domainEvents;

        protected void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}