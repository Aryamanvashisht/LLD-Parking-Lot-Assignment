using ParkingLotSystem.Enums;

namespace ParkingLotSystem.Models
{
    public class Slot
    {
        public int Number { get; }
        public VehicleType SlotType { get; }
        public Vehicle ParkedVehicle { get; private set; }

        public bool IsFree => ParkedVehicle == null;

        public Slot(int number, VehicleType slotType)
        {
            Number = number;
            SlotType = slotType;
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            if (vehicle.Type == SlotType)
            {
                ParkedVehicle = vehicle;
            }
        }

        public void UnparkVehicle()
        {
            ParkedVehicle = null;
        }
    }
}
