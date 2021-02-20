using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageApplikation
{
    class GarageHandler : IHandler
    {
        private Garage<Vehicle> garage;
        private ConsoleUI ui;
        public GarageHandler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
            ui = new ConsoleUI();
        }
        public void Seed()
        {
            var vehicles = GetVehicles();

            foreach (var vehicle in vehicles)
            {
                garage.Add(vehicle);
            }
            ui.Print($"{GetVehicles().Count()} Vehicles of various types has parked in the garage");
        }
        private IEnumerable<Vehicle> GetVehicles()
        {
            return new List<Vehicle>
            {
                (new Car("ABC123", "Black", 4, "Petrol")),
                (new AirPlane("a1256", "Grey", 9, 4)),
                (new Bus("XYZ789", "Orange", 6, 36)),
                (new Boat("CGT25", "White and Blue", 1 , 6.8)),
                (new MotorCycle("CT255", "Black and Red", 2, 3.2))
            };
        }
        public List<Vehicle> GetAll()
        {
            return garage.ToList();
        }
        public Vehicle RemoveVehicle(string regNr)
        {
            var vehicleToRemove = garage.FirstOrDefault(v => regNr.Equals(v.RegNr, StringComparison.InvariantCultureIgnoreCase));
            garage.Remove(vehicleToRemove);
            return vehicleToRemove;
        }
        public string GetVehiclesCount()
        {
            return $"The Garage has {garage.Count()} Vehicles";
        }
        public Car CreateCar(string regNr, string color, int nrOfWheels, string fuelType)
        {
            var car = new Car(regNr, color, nrOfWheels, fuelType);
            garage.Add(car);
            return car;
        }
        public AirPlane CreateAirPlane(string regNr, string color, int nrOfWheels, int nrOfEngines)
        {
            var airPlane = new AirPlane(regNr, color, nrOfWheels, nrOfEngines);
            garage.Add(airPlane);
            return airPlane;
        }
        public MotorCycle CreateMotorCycle(string regNr, string color, int nrOfWheels, double cylinderVolume)
        {
            var motorCycle = new MotorCycle(regNr, color, nrOfWheels, cylinderVolume);
            garage.Add(motorCycle);
            return motorCycle;
        }

        public Vehicle FindVehicleByRegNr(string regNr)
        {
            var vehicleToFind = garage.FirstOrDefault(v => regNr.Equals(v.RegNr, StringComparison.InvariantCultureIgnoreCase));
            return vehicleToFind;
        }

        public Bus CreateBus(string regNr, string color, int nrOfWheels, int nrOfSeats)
        {
            var bus = new Bus(regNr, color, nrOfWheels, nrOfSeats);
            garage.Add(bus);
            return bus;
        }
        public Boat CreateBoat(string regNr, string color, int nrOfWheels, double boatLength)
        {
            var boat = new Boat(regNr, color, nrOfWheels, boatLength);
            garage.Add(boat);
            return boat;
        }
        public bool GarageIsFull()
        {
            return garage.IsFull;
        }

        public bool RegNrExists(string regNr)
        {
            return garage.FirstOrDefault(v => regNr.Equals(v.RegNr, StringComparison.InvariantCultureIgnoreCase)) is null ? false : true;
            #region CodeExplanation

            //Review: this does exactly like the code below:
            //foreach (var vehicle in garage)
            //{
            //    if(vehicle.RegNr == regNr)
            //    {
            //        return true;
            //    }

            //}
            //return false;
            #endregion
        }
    }
}
