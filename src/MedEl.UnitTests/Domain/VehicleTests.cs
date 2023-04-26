using System;
using MedEl.Domain.Models.Tires;
using MedEl.Domain.Models.Vehicles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedEl.UnitTests.Domain
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void Create_motorcycle_success()
        {
            var unit = new Motorcycle("Honda");

            Assert.IsNotNull(unit);
        }

        [TestMethod]
        public void Create_motorcycle_no_brand()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Motorcycle(null));
        }

        [TestMethod]
        public void GetEquipment_motorcycle_success()
        {
            var unit = new Motorcycle("Honda");
			var actual = unit.GetEquipment();
			var expected = "";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetEquipment_car_success()
        {
            var unit = new Car("Honda");
            unit.SetTires(new SummerTireSet(2.25F, TireSize.Parse("123/45R67"), 25));

			var actual = unit.GetEquipment();
			var expected = "Tire set: Season: Summer, Size: 45/67R123, Pressure: 2.25bar, MaximumTemperature: 25.00°C";

            Assert.AreEqual(expected, actual);
        }
    }
}
