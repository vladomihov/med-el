using MedEl.Domain.Models.Vehicles;

namespace MedEl.Domain.Services
{
    public interface ICarFactory
    {
        Car CreateNew();
    }
}