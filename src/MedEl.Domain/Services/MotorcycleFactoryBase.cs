using MedEl.Domain.Configuration;
using MedEl.Domain.Models.Vehicles;
using Microsoft.Extensions.Options;

namespace MedEl.Domain.Services
{
    public abstract class MotorcycleFactoryBase : IMotorcycleFactory
    {
        public abstract string FactoryName { get; }

        public virtual Motorcycle CreateNew()
        {
            var motorcycle = new Motorcycle(FactoryName);
            return motorcycle;
        }
    }
}