using MedEl.Domain.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedEl.Infrastructure.Database.EntityConfigurations
{
	class MotorcycleEntityTypeConfiguration : IEntityTypeConfiguration<Motorcycle>
	{
		public void Configure(EntityTypeBuilder<Motorcycle> entityType)
		{
		}
	}
}
