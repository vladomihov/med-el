using MedEl.Domain.Models.Vehicles;

namespace MedEl.Domain.Services
{
    public class HondaMotorcycleFactory : MotorcycleFactoryBase
    {
        public static readonly string BrandName = "Honda";

        public override string FactoryName => BrandName;
    }
}