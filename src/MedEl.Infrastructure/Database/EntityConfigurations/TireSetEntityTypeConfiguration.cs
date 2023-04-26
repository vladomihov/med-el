using MedEl.Domain.Models.Tires;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedEl.Infrastructure.Database.EntityConfigurations
{
    class TireSetEntityTypeConfiguration : IEntityTypeConfiguration<TireSet>
	{
		public void Configure(EntityTypeBuilder<TireSet> entityType)
		{
			entityType.HasKey(o => o.Id);

			entityType.Property(o => o.Pressure);
			entityType.Property(o => o.Size)
			 	.HasConversion(
					v => v.ToString(),
					v => TireSize.Parse(v));
		}
	}
}
