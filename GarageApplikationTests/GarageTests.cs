using Microsoft.VisualStudio.TestTools.UnitTesting;
using GarageApplikation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplikation.Tests
{
    [TestClass()]
    public class GarageTests
    {
        private Garage<Vehicle> garage;


        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitializer()
        {
            if (TestContext.TestName.EndsWith('1'))
            {
                garage = new Garage<Vehicle>(1);
                var car = new Car("ABC123", "Black", 4, "Petrol");
                garage.Add(car);
            }
            else if (TestContext.TestName.EndsWith('0'))
            {
                garage = new Garage<Vehicle>(0);
            }
            else
            {
                garage = new Garage<Vehicle>(3);
            }
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            //ToDo : Create a test unit to test GetEnumerator method in Garage class.

            // Arrange

            // Act

            // Assert
        }

        [TestMethod()]
        public void AddToAFullGarage1()
        {
            // Arrange
            var expected = 1;
            var actual = garage.Count;
            // Act
            var car2 = new Car("aaa555", "Red", 4, "Diesel");
            garage.Add(car2);
            // Assert
            Assert.IsTrue(garage.IsFull);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RemoveFromEmptyGarageTest0()
        {
            var expected = 0;
            var actual = garage.Count;
            //Act
            var car = new Car("ABC123", "Black", 4, "Petrol");
            garage.Remove(car);
           
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void RemoveCheckIfCountGoesDown_Test()
        {
            var expected = 2;
            //Act
            var car1 = new Car("ABC123", "Black", 4, "Petrol");
            var car2 = new Car("XYZ321", "Red", 4, "Gas");
            var car3 = new Car("QWE123", "Blue", 4, "Diesel");
            garage.Add(car1);
            garage.Add(car2);
            garage.Add(car3);
            garage.Remove(car1);
            var actual = garage.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddCheckIfCountIncreasesTest()
        {
            var expectedOldCount = 0;
            var actualOldCount = garage.Count;
            var expectedNewCount = 1;
            var car1 = new Car("ABC123", "Black", 4, "Petrol");
            garage.Add(car1);
            var actualNewCount = garage.Count;
            Assert.AreEqual(expectedOldCount, actualOldCount);
            Assert.AreEqual(expectedNewCount, actualNewCount);
        }
    }
}
