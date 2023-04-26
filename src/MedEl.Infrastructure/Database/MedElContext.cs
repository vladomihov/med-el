using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MedEl.Domain.Models.Tires;
using MedEl.Domain.Models.Vehicles;
using MedEl.Domain.Services;
using MedEl.Infrastructure.Database.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedEl.Infrastructure.Database
{
    internal class MedElContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set; }

        public DbSet<TireSet> TireSets { get; set; }
        public DbSet<WinterTireSet> WinterTireSets { get; set; }
        public DbSet<SummerTireSet> SummerTireSets { get; set; }

        public MedElContext(DbContextOptions<MedElContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VehicleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MotorcycleEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new TireSetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SummerTireSetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WinterTireSetEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await DispatchDomainEventsAsync();

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        private async Task DispatchDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
			{
                await _mediator.Publish(domainEvent);
			}

        }
    }
}
