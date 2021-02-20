namespace GarageApplikation
{
    public interface IUI
    {
        double AskForDouble();
        int AskForInteger(string message);
        string AskForString(string message);
        double GetBoatLength();
        double GetCylinderVolume();
        string GetInput();
        void Print(string message);
        void VehiclesMenu();
        void ShowMainMenu();
    }
}