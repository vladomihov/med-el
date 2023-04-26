using System;
using System.Text.RegularExpressions;

namespace MedEl.Domain.Models.Tires
{
    public record class TireSize(int RimDiameter, int SectionWidth, int AspectRatio)
    {
        private static readonly Regex ParseExpression = new Regex(@$"(?<{nameof(SectionWidth)}>\d+)/(?<{nameof(AspectRatio)}>\d+)R(?<{nameof(RimDiameter)}>\d+)");

        public override string ToString() => $"{SectionWidth}/{AspectRatio}R{RimDiameter}";

        public static TireSize Parse(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var match = ParseExpression.Match(text);
            if (!match.Success)
            {
                throw new ArgumentException($"Invalid format. Cannot parse tire size '{text}'.", nameof(text));
            }

            return new TireSize(
                RimDiameter: ParseSegment(match, nameof(SectionWidth)),
                SectionWidth: ParseSegment(match, nameof(AspectRatio)),
                AspectRatio: ParseSegment(match, nameof(RimDiameter)));
        }

        private static int ParseSegment(Match match, string segmentName)
        {
            var segment = match.Groups[segmentName].Value;
            if (int.TryParse(segment, out var result))
            {
                return result;
            }

            throw new ArgumentException($"Cannot parse {segmentName} from '{segment}'.");
        }
    }
}