using System;
using System.Collections.Generic;
using ParkingLotSystem.Enums;

namespace ParkingLotSystem.Models
{
    public class Floor
    {
        public int FloorNumber { get; }
        public List<Slot> Slots { get; }

        public Floor(int floorNumber, int numberOfSlots)
        {
            FloorNumber = floorNumber;
            Slots = new List<Slot>();
            InitializeSlots(numberOfSlots);
        }

        private void InitializeSlots(int numberOfSlots)
        {
            if (numberOfSlots < 3) throw new ArgumentException("Each floor must have at least 3 slots.");

            Slots.Add(new Slot(1, VehicleType.Truck));
            Slots.Add(new Slot(2, VehicleType.Bike));
            Slots.Add(new Slot(3, VehicleType.Bike));

            for (int i = 4; i <= numberOfSlots; i++)
            {
                Slots.Add(new Slot(i, VehicleType.Car));
            }
        }
    }
}
