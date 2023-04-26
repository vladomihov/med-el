using MedEl.Domain.Configuration;
using Microsoft.Extensions.Options;

namespace MedEl.Domain.Services
{
    public class HondaCarFactory : CarFactoryBase
    {
        public static readonly string BrandName = "Honda";

        public override string FactoryName => BrandName;

        public HondaCarFactory(IOptions<TireConfiguration> tireConfigurationOptions) : base(tireConfigurationOptions)
        { }
    }
}