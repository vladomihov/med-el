using MedEl.Domain.Models.Tires;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedEl.Infrastructure.Database.EntityConfigurations
{
    class WinterTireSetEntityTypeConfiguration : IEntityTypeConfiguration<WinterTireSet>
	{
		public void Configure(EntityTypeBuilder<WinterTireSet> entityType)
		{
			entityType.Property(o => o.MinimumTemperature);
			entityType.Property(o => o.Thickness);
		}
	}
}
