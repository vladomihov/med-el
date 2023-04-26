using MedEl.Domain.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedEl.Infrastructure.Database.EntityConfigurations
{
	class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
	{
		public void Configure(EntityTypeBuilder<Vehicle> entityType)
		{
			entityType.HasKey(o => o.Id);
			entityType.Property(x => x.Brand);
		}
	}
}
