using MedEl.Domain.Configuration;
using Microsoft.Extensions.Options;

namespace MedEl.Domain.Services
{
    public class ToyotaCarFactory : CarFactoryBase
    {
        public static readonly string BrandName = "Toyota";

        public override string FactoryName => BrandName;

        public ToyotaCarFactory(IOptions<TireConfiguration> tireConfigurationOptions) : base(tireConfigurationOptions)
        { }
    }
}