using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MedEl.Domain.Models.Tires
{
    [JsonDerivedType(typeof(SummerTireSet))]
    [JsonDerivedType(typeof(WinterTireSet))]
    public abstract class TireSet
    {
        public int Id { get; }

        public float Pressure { get; }

        public TireSize Size { get; }

        protected TireSet(float pressure, TireSize size)
        {
            Pressure = pressure;
            Size = size;
        }

        protected virtual IEnumerable<(string name, string value)> GetCharacteristics()
        {
            return new[] {
                (nameof(Size), Size?.ToString()),
                (nameof(Pressure), $"{Pressure:0.00}bar")
            };
        }

        public string GetSummary()
        {
            var characteristics = GetCharacteristics().Select(x => $"{x.name}: {x.value}");
            var summary = "Tire set: " + string.Join(", ", characteristics);
            return summary;
        }
    }
}