using System;
using System.Collections.Generic;
using System.Text.Json;
using MedEl.Domain.Configuration;
using MedEl.Domain.Models.Tires;
using MedEl.Domain.Models.Vehicles;
using MedEl.Domain.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MedEl.UnitTests.Domain
{
    [TestClass]
    public class HondaCarFactoryTests
    {
        [TestMethod]
        public void Create_motorcycle_success()
        {
            const string brandName = "Honda";
            const float pressure = 1.23F;

            var config = new TireConfiguration
            {
                Factories = new Dictionary<string, SummerTireSetConfiguration> {
                    { brandName, new SummerTireSetConfiguration { Pressure = pressure } }
                }
            };
            var options = Mock.Of<IOptions<TireConfiguration>>(
                x => x.Value == config
            );

            var unit = new HondaCarFactory(options);
            var actualCar = unit.CreateNew();
            var actual = JsonSerializer.Serialize(actualCar);

            var expectedCar = new Car(brandName);
            var expectedTires = new SummerTireSet(pressure, TireSize.Parse("225/60R17"), 50);
            expectedCar.SetTires(expectedTires);
            var expected = JsonSerializer.Serialize(expectedCar);

            Assert.AreEqual(expected, actual);
        }
    }
}
