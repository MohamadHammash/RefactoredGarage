using System.Collections.Generic;

namespace GarageApplikation
{
    public class Vehicle : IVehicle
    {
        private string regNo;
        public string RegNr
        {
            get
            {
                return regNo;
            }
            set
            {
                regNo = value;

            }
        }
        public string Color { get; set; }
        public int NrOfWheels { get; set; }
        public Vehicle(string regNr, string color, int nrOfWheels)
        {
            RegNr = regNr;
            Color = color;
            NrOfWheels = nrOfWheels;
        }
        public override string ToString()
        {
            return $" vehicle of type: {this.GetType().Name}, that has the register number: {RegNr}, with the color: {Color}," +
                $"and has: {NrOfWheels} wheels";
        }

    }
    class AirPlane : Vehicle
    {
        public int NrOfEngines { get; set; }
        public AirPlane(string regNr, string color, int nrOfWheels, int nrOfEngines) : base(regNr, color, nrOfWheels)
        {
            NrOfEngines = nrOfEngines;
        }
    }
    class MotorCycle : Vehicle
    {
        public double CylinderVolume { get; set; }
        public MotorCycle(string regNr, string color, int nrOfWheels, double cylinderVolume) : base(regNr, color, nrOfWheels)
        {
            CylinderVolume = cylinderVolume;
        }
        public override string ToString()
        {
            return $"{base.ToString()} and has a cylinder volume of {CylinderVolume}";

        }
    }
    public class Car : Vehicle // made public for the test
    {
        public string FuelType { get; set; }
        public Car(string regNr, string color, int nrOfWheels, string fuelType) : base(regNr, color, nrOfWheels)
        {
            FuelType = fuelType;
        }
        public override string ToString()
        {
            return $"{base.ToString()} and can be filled with: { FuelType}";

        }
    }
    class Bus : Vehicle
    {
        public int NrOfSeats { get; set; }
        public Bus(string regNr, string color, int nrOfWheels, int nrOfSeats) : base(regNr, color, nrOfWheels)
        {
            NrOfSeats = nrOfSeats;
        }
        public override string ToString()
        {
            return $"{base.ToString()} and has:  { NrOfSeats} seats";
        }
    }
    class Boat : Vehicle
    {
        public double BoatLenght { get; set; }
        public Boat(string regNr, string color, int nrOfWheels, double boatLenght) : base(regNr, color, nrOfWheels)
        {
            BoatLenght = boatLenght;
        }
        public override string ToString()
        {
            return $"{base.ToString()} and is: { BoatLenght}M long ";
        }
    }
}