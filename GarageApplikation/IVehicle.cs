namespace GarageApplikation
{
    public interface IVehicle
    {
        string Color { get; set; }
        int NrOfWheels { get; set; }
        string RegNr { get; set; }

        string ToString();
    }
}