using System;
using MedEl.Domain.Models.Tires;

namespace MedEl.Domain.Models.Vehicles
{
    public class Car : Vehicle
    {
        public TireSet Tires { get; private set; }

        public override string Kind => nameof(Car).ToLower();

        public Car(string brand) : base(brand)
        { }

        public override string GetEquipment()
        {
            var equipment = base.GetEquipment();
            equipment += Tires?.GetSummary();
            return equipment;
        }

        public void SetTires(TireSet tires)
        {
            Tires = tires;
        }
    }
}