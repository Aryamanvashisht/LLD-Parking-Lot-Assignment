using ParkingLotSystem.Enums;

namespace ParkingLotSystem.Models
{
    public class Vehicle
    {
        public VehicleType Type { get; }
        public string RegistrationNumber { get; }
        public string Color { get; }

        public Vehicle(VehicleType type, string registrationNumber, string color)
        {
            Type = type;
            RegistrationNumber = registrationNumber;
            Color = color;
        }
    }
}
