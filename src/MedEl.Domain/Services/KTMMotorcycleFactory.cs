using MedEl.Domain.Models.Vehicles;

namespace MedEl.Domain.Services
{
    public class KTMMotorcycleFactory : MotorcycleFactoryBase
    {
        public static readonly string BrandName = "KTM";

        public override string FactoryName => BrandName;
    }
}