using System.Collections.Generic;

namespace MedEl.Domain.Models.Tires
{
    public class SummerTireSet : TireSet
    {
        public static readonly string Season = "Summer";

        public float MaximumTemperature { get; }

        public SummerTireSet(float pressure, TireSize size, float maximumTemperature) : base(pressure, size)
        {
            MaximumTemperature = maximumTemperature;
        }

        protected override IEnumerable<(string name, string value)> GetCharacteristics()
        {
            var characteristics = new List<(string name, string value)>();
            characteristics.Add((nameof(Season), Season));
            characteristics.AddRange(base.GetCharacteristics());
            characteristics.Add((nameof(MaximumTemperature), $"{MaximumTemperature:F2}°C"));

            return characteristics;
        }
    }
}