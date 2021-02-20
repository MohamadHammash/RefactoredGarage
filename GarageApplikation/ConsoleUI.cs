using System;
using System.Collections.Generic;
using System.Text;

namespace GarageApplikation
{
    public class ConsoleUI : IUI
    {


        #region Menus

      

        public void ShowMainMenu()
        {
            Print($"Welcome to the main menu!"
                    + "\n Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 6, 7, 0) of your choice"
                    + "\n1. Park a vehicle to the garage "
                    + "\n2. Leave a vehicle from the garage"
                    + "\n3. Get the total amount of all the vehicles in the garage"
                    + "\n4. Get a specified list of all the vehicles in the garage"
                    + "\n5. Park stored vehicles"
                    + "\n6. Find a vehicle by registration number"
                    + "\n7. Find a vehicle by specifications"
                    + "\n0. Exit the application");


        }
      

        public void VehiclesMenu()
        {
            Print("Please Choose which vehicle you would like to add");
            Print("Please press 1 to Add a car" +
                "\n Please press 2 to Add an airplane" +
                "\n Please press 3 to Add a motorcycle" +
                "\n Please press 4 to Add a bus" +
                "\n Please press 5 to Add a boat" +
                "\n To go back to the previous menu please press 9" +
                "\n To close the application please press 0");
        }
      
       
        #endregion
        #region Util
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
        public string GetInput()
        {
            string message = Console.ReadLine();
            return message;
        }
       
        public string AskForString(string message)
        {
            Print(message);
            bool success = false;
            string answer;
            do
            {
                Console.WriteLine();
                answer = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(answer))
                {
                    Print("You must enter something");
                }
                else
                {
                    success = true;
                }

            } while (!success);

            return answer;
        }
        public int AskForInteger(string message)
        {
            Print(message);
            bool ok = false;
            int choice;
            do
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out choice))
                {

                    ok = true;
                }
                else
                {
                    Print("Please enter a valid choice! ");
                }

            }
            while (!ok);
            return choice;
        }
        public double AskForDouble()
        {
            bool ok = false;
            double choice;
            do
            {
                string input = Console.ReadLine();

                if (double.TryParse(input, out choice))
                {

                    ok = true;
                }
                else
                {
                    Print("Please enter a valid choice! ");
                }

            }
            while (!ok);
            return choice;
        }
        #endregion

        #region GetSpecs



      

      
        public double GetCylinderVolume()
        {
            Print("Please enter the Motor Cycle's cylinder volume!");
            double message = AskForDouble();
            return message;
        }
       
        public double GetBoatLength()
        {
            Print("Please enter the length of the boat!");
            double message = AskForDouble();
            return message;
        }
        #endregion
    }
}
