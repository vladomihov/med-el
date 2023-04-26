using MedEl.Domain.Models.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedEl.Infrastructure.Database.EntityConfigurations
{
	class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> entityType)
		{
			entityType.Navigation(x => x.Tires).AutoInclude();
		}
	}
}
