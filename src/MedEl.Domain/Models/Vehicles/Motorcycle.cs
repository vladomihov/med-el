namespace MedEl.Domain.Models.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public override string Kind => nameof(Motorcycle).ToLower();

        public Motorcycle(string brand) : base(brand)
        { }
    }
}