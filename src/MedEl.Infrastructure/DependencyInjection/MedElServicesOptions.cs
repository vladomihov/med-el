using System;
using System.Collections.Generic;
using MedEl.Domain.Services;

namespace MedEl.Infrastructure.DependencyInjection
{
    public class MedElServicesOptions
    {
        internal IDictionary<string, Type> CarFactories { get; } = new Dictionary<string, Type>();
        internal IDictionary<string, Type> MotorcycleFactories { get; } = new Dictionary<string, Type>();

        public MedElServicesOptions AddCarFactory<TFactory>(string name)
            where TFactory : ICarFactory
        {
            CarFactories.Add(name, typeof(TFactory));

            return this;
        }

        public MedElServicesOptions AddMotorcycleFactory<TFactory>(string name)
            where TFactory : IMotorcycleFactory
        {
            MotorcycleFactories.Add(name, typeof(TFactory));

            return this;
        }
    }
}