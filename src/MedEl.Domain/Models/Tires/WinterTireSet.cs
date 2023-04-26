using System.Collections.Generic;

namespace MedEl.Domain.Models.Tires
{
    public class WinterTireSet : TireSet
    {
        public static readonly string Season = "Winter";

        public float MinimumTemperature { get; }

        public float Thickness { get; }

        public WinterTireSet(float pressure, TireSize size, float minimumTemperature, float thickness) : base(pressure, size)
        {
            MinimumTemperature = minimumTemperature;
            Thickness = thickness;
        }

        protected override IEnumerable<(string name, string value)> GetCharacteristics()
        {
            var characteristics = new List<(string name, string value)>();
            characteristics.Add((nameof(Season), Season));
            characteristics.AddRange(base.GetCharacteristics());
            characteristics.Add((nameof(MinimumTemperature), $"{MinimumTemperature:F2}°C"));
            characteristics.Add((nameof(Thickness), $"{Thickness:F2}"));

            return characteristics;
        }
    }
}