using System.Collections.Generic;

namespace MedEl.Domain.Configuration
{
    public class TireConfiguration
    {
        public IDictionary<string, SummerTireSetConfiguration> Factories {get; set; }
    }
}