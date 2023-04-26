using MedEl.Domain.Models.Tires;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedEl.Infrastructure.Database.EntityConfigurations
{
    class SummerTireSetEntityTypeConfiguration : IEntityTypeConfiguration<SummerTireSet>
	{
		public void Configure(EntityTypeBuilder<SummerTireSet> entityType)
		{
			entityType.Property(o => o.MaximumTemperature);
		}
	}
}
