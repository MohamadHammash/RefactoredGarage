using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageApplikation
{
    public class GarageManager
    {
        private IUI ui;
        private IHandler handler;


        public GarageManager()
        {
            ui = new ConsoleUI();
        }
        internal void Run()
        {
            StartMenu();
            MainMenu();
        }

        private void MainMenu()
        {
            do
            {
                ui.ShowMainMenu();
                int input = ui.AskForInteger("");
                switch (input)
                {
                    case 1:
                        if (CheckGarageIsFull()) { break; }
                        AddVehicle();
                        break;
                    case 2:
                        RemoveVehicle();
                        break;
                    case 3:
                        GetVehiclesNumbers();
                        break;
                    case 4:
                        PrintAll();
                        break;
                    case 5:
                        Seed();
                        break;
                    case 6:
                        FindVehicleByRegNr();
                        break;
                    case 7:
                        FindVehiclesByProporties();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        private void FindVehicleByRegNr()
        {
            bool regNrExist = false;
            do
            {
                string regNr = ui.AskForString("Please enter the registration number of the vehicle!");
                try
                {
                    var vehicleToFind = handler.FindVehicleByRegNr(regNr);
                    if (regNr.Equals(regNr, StringComparison.InvariantCultureIgnoreCase))
                    {Console.Clear();
                        ui.Print($"The vehicle yo searched for is a {vehicleToFind.Color} {vehicleToFind.GetType().Name}, that has {vehicleToFind.NrOfWheels} wheels ");
                        regNrExist = true;
                    }
                }
                catch (NullReferenceException)
                {
                    int input1 = ui.AskForInteger($"There is no vehicle in the garage that has this registration number: \u0022{regNr}\u0022. Please try again." +
                       $"\n Press 1 to try again" +
                        "\n press 2 to go back");
                    
                    switch (input1)
                    {
                        case 1:
                            regNrExist = false;
                            break;
                        case 2:
                            regNrExist = true;
                            Console.Clear();
                            break;
                    }
                }
            } while (!regNrExist);
        }
        private void FindVehiclesByProporties()
        {Console.Clear();
           
            ui.Print("Please enter the color of the vehicles you would like to find!");
            var color = ui.GetInput();
            ui.Print("Please enter the number of wheels of the vehicles you would like to find!");
            var NrOfWheels = ui.GetInput();
            ui.Print("Please enter the type of the vehicle would like to find!");
            var type = ui.GetInput();
            IEnumerable<Vehicle> result = handler.GetAll();

            if (!string.IsNullOrWhiteSpace(color))
            {

                result = result.Where(v => v.Color.Equals(color, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!String.IsNullOrWhiteSpace(NrOfWheels) && int.TryParse(NrOfWheels, out int getWheelsNr))
            {
                result = result.Where(v => v.NrOfWheels == getWheelsNr);
            }


            if (!String.IsNullOrWhiteSpace(type))
                result = result.Where(v => v.GetType().Name.Equals(type, StringComparison.InvariantCultureIgnoreCase));

            foreach (var itemAllVehicles in result)
            {

                if (color.ToLower() == itemAllVehicles.Color.ToLower()  || type.ToLower() ==  itemAllVehicles.GetType().Name.ToLower() || int.TryParse(NrOfWheels, out  getWheelsNr))
                {Console.Clear();
                    ui.Print($"A vehicle of type {itemAllVehicles.GetType().Name} with the register number: {itemAllVehicles.RegNr} that has a {itemAllVehicles.Color} color and {itemAllVehicles.NrOfWheels} wheels has been found");
                }
                else
                {Console.Clear();
                    ui.Print("No vehicles found in these specifications!");
                    break;
                }
            }
        }
        private void StartMenu()
        {
            bool sucess = false;
            Console.Clear();
            ui.Print("Welcome! To create a new garage please enter the garage's capacity");
            do
            {
                if (int.TryParse(ui.AskForString(""), out int capacity))
                {

                    handler = new GarageHandler(capacity);
                    if (capacity <= 0)
                    {
                        sucess = false;
                        ui.Print("The garage must have a capacity for at least 1 vehicle! Please try again");
                    }
                    else
                    {
                        sucess = true;
                    }
                }
                else
                {
                    sucess = false;
                    Console.WriteLine("Please enter a valid choice");
                }

            } while (!sucess);

        }
        private bool CheckGarageIsFull()
        {
            if (handler.GarageIsFull())
            {Console.Clear();
                ui.Print("The garage is already full!");
                return true;
            }
            else
            {
                return false;
            }
        }
        private void RemoveVehicle()
        {
            var regNr = ui.AskForString("Please enter the Registration number of the Vehicle you would like to remove.");
            var vehicleToRemove = handler.RemoveVehicle(regNr);
            if (vehicleToRemove != null)
            {
                Console.Clear();
                ui.Print($"a vehicle of type {vehicleToRemove.GetType().Name} and Register number {vehicleToRemove.RegNr} has been removed");
            }
            else
            {
                Console.Clear();
                ui.Print($"No vehicle in the garage that has the registration number: \u0022 {regNr} \u0022 !");
            }
        }
        private void AddVehicle()
        {
            bool success = true;
            ui.VehiclesMenu();
            do
            {
                int input = ui.AskForInteger("");

                switch (input)
                {
                    case 1:
                        AddCar();
                        
                        break;
                    case 2:
                        AddAirPlane();
                        break;
                    case 3:
                        AddMotorCycle();
                        break;
                    case 4:
                        AddBus();
                        break;
                    case 5:
                        AddBoat();
                        break;
                    case 9:
                        Console.Clear();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        success = false;
                        ui.Print("Please enter a valid choice");
                        break;
                }
            } while (!success);
        }


        private Boat AddBoat()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            double boatLength = ui.GetBoatLength();
            Console.Clear();
            ui.Print($"a vehicle of type: Boat that has the Register number: \u0022{regNr}\u0022 has parked in the garage");
            return handler.CreateBoat(regNr, color, nrOfWheels, boatLength);
        }
        private Bus AddBus()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            int nrOfSeats = ui.AskForInteger("Please enter the number of seats that the bus has!");
            Console.Clear();
            ui.Print($"a vehicle of type: Buss that has the Register number: \u0022{regNr}\u0022 has parked in the garage");
            return handler.CreateBus(regNr, color, nrOfWheels, nrOfSeats);
        }
        private MotorCycle AddMotorCycle()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            double cylinderVolume = ui.GetCylinderVolume();
            Console.Clear();
            ui.Print($"a vehicle of type: Motor cycle that has the Register number: \u0022{regNr}\u0022 has parked in the garage");
            return handler.CreateMotorCycle(regNr, color, nrOfWheels, cylinderVolume);
        }
        private Car AddCar() 
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            string fuelType = ui.AskForString("Please enter the vehicle's fuel type!");
            Console.Clear();
            ui.Print($"a vehicle of type: Car that has the Register number: \u0022{regNr}\u0022 has parked in the garage");
            return handler.CreateCar(regNr, color, nrOfWheels, fuelType);
        }
        private AirPlane AddAirPlane()
        {
            string regNr = CheckRegNr();
            string color = ui.AskForString("Please enter the color of the vehicle!");
            int nrOfWheels = ui.AskForInteger("Please enter the number of wheels that the vehicle has!");
            int nrOfEngines = ui.AskForInteger("Please enter the airplane's number of engines!");
            Console.Clear();
            ui.Print($"a vehicle of type: Airplane that has the Register number: \u0022{regNr}\u0022 has parked in the garage");
            return handler.CreateAirPlane(regNr, color, nrOfWheels, nrOfEngines);
        }
        private string CheckRegNr()
        {
            string regNr;
            do
            {
                regNr = ui.AskForString("Please enter the registration number of the vehicle!");
                if (handler.RegNrExists(regNr)) {Console.Clear();
                    ui.Print("This vehicle already exists in the garage"); }
            } while (handler.RegNrExists(regNr));
            return regNr;
        }
        private void GetVehiclesNumbers()
        {
            Console.Clear();
            ui.Print(handler.GetVehiclesCount());
        }
      
        private void PrintAll()
        {
            try
            {
                IEnumerable<Vehicle> allVehicles = handler.GetAll();
                if(handler.GetAll().Count > 0)
                {
                    Console.Clear();
                    ui.Print("The Garage contains the following vehicles: ");
             
                foreach (var item in allVehicles)
                {

                    ui.Print(item.ToString());
                }
                }
                else
                {
                    Console.Clear();
                    ui.Print("The garage is empty!");
                }
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                ui.Print("The garage is empty!");
            }
        }

        private void Seed()
        {
            handler = new GarageHandler(10);
            Console.Clear();
            handler.Seed();
        }
    }
}
