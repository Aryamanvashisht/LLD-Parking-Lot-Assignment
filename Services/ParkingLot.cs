using System;
using System.Collections.Generic;
using System.Linq;
using ParkingLotSystem.Models;
using ParkingLotSystem.Enums;

namespace ParkingLotSystem.Services
{
    public class ParkingLot
    {
        public string Id { get; }
        public List<Floor> Floors { get; }

        public ParkingLot(string id, int numberOfFloors, int slotsPerFloor)
        {
            Id = id;
            Floors = new List<Floor>();

            for (int i = 1; i <= numberOfFloors; i++)
            {
                Floors.Add(new Floor(i, slotsPerFloor));
            }
        }

        public string ParkVehicle(Vehicle vehicle)
        {
            foreach (var floor in Floors)
            {
                foreach (var slot in floor.Slots)
                {
                    if (slot.IsFree && slot.SlotType == vehicle.Type)
                    {
                        slot.ParkVehicle(vehicle);
                        return $"{Id}_{floor.FloorNumber}_{slot.Number}";
                    }
                }
            }
            return "Parking Lot Full";
        }

        public string UnparkVehicle(string ticketId)
        {
            var parts = ticketId.Split('_');
            if (parts.Length != 3 || parts[0] != Id) return "Invalid Ticket";

            int floorNumber = int.Parse(parts[1]);
            int slotNumber = int.Parse(parts[2]);

            var floor = Floors.Find(f => f.FloorNumber == floorNumber);
            var slot = floor?.Slots.Find(s => s.Number == slotNumber);

            if (slot == null || slot.IsFree) return "Invalid Ticket";

            var vehicle = slot.ParkedVehicle;
            slot.UnparkVehicle();
            return $"Unparked vehicle with Registration Number: {vehicle.RegistrationNumber} and Color: {vehicle.Color}";
        }

        public void DisplayFreeCount(VehicleType vehicleType)
        {
            foreach (var floor in Floors)
            {
                int freeCount = floor.Slots.Count(slot => slot.IsFree && slot.SlotType == vehicleType);
                Console.WriteLine($"No. of free slots for {vehicleType} on Floor {floor.FloorNumber}: {freeCount}");
            }
        }

        public void DisplayFreeSlots(VehicleType vehicleType)
        {
            foreach (var floor in Floors)
            {
                var freeSlots = floor.Slots.FindAll(slot => slot.IsFree && slot.SlotType == vehicleType);
                Console.WriteLine($"Free slots for {vehicleType} on Floor {floor.FloorNumber}: {string.Join(",", freeSlots.Select(slot => slot.Number))}");
            }
        }

        public void DisplayOccupiedSlots(VehicleType vehicleType)
        {
            foreach (var floor in Floors)
            {
                var occupiedSlots = floor.Slots.FindAll(slot => !slot.IsFree && slot.SlotType == vehicleType);
                Console.WriteLine($"Occupied slots for {vehicleType} on Floor {floor.FloorNumber}: {string.Join(",", occupiedSlots.Select(slot => slot.Number))}");
            }
        }
    }
}
