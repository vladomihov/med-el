using MedEl.Domain.Configuration;
using MedEl.Domain.Models.Tires;
using MedEl.Domain.Models.Vehicles;
using Microsoft.Extensions.Options;

namespace MedEl.Domain.Services
{
    public abstract class CarFactoryBase : ICarFactory
    {
        private readonly TireConfiguration _tireConfiguration;

        public abstract string FactoryName { get; }

        public CarFactoryBase(IOptions<TireConfiguration> tireConfigurationOptions)
        {
            _tireConfiguration = tireConfigurationOptions.Value;
        }

        public virtual Car CreateNew()
        {
            var tireSet = CreateDefaultTireSet(FactoryName);
            var car = new Car(FactoryName);
            car.SetTires(tireSet);

            return car;
        }

        protected TireSet CreateDefaultTireSet(string factory)
        {
            if (!_tireConfiguration.Factories.TryGetValue(factory, out var configuration))
            {
                configuration = new SummerTireSetConfiguration();
            }

            var tireSet = new SummerTireSet(
                pressure: configuration.Pressure,
                size: TireSize.Parse(configuration.Size),
                maximumTemperature: configuration.MaximumTemperature
            );

            return tireSet;
        }
    }
}