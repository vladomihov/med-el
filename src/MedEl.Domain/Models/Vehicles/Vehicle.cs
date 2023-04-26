using System;
using System.Text.Json.Serialization;
using MedEl.Domain.Events;

namespace MedEl.Domain.Models.Vehicles
{
    [JsonDerivedType(typeof(Car))]
    [JsonDerivedType(typeof(Motorcycle))]
    public abstract class Vehicle : Entity
    {
        public string Brand { get; }

        public abstract string Kind { get; }

        protected Vehicle() { }

        protected Vehicle(string brand)
        {
            Brand = brand ?? throw new ArgumentNullException(nameof(brand));
        }

        public void Move()
        {
            var moveEvent = new VehicleMoveDomainEvent(this);
            AddDomainEvent(moveEvent);
        }

        public virtual string GetEquipment() => "";
    }
}