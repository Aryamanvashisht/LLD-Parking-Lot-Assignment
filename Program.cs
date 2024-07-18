using System;
using ParkingLotSystem.Enums;
using ParkingLotSystem.Models;
using ParkingLotSystem.Services;

namespace ParkingLotSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ParkingLot parkingLot = null;
            while (true)
            {
                var command = Console.ReadLine().Split(' ');
                switch (command[0])
                {
                    case "create_parking_lot":
                        parkingLot = new ParkingLot(command[1], int.Parse(command[2]), int.Parse(command[3]));
                        Console.WriteLine($"Created parking lot with {command[2]} floors and {command[3]} slots per floor");
                        break;
                    case "park_vehicle":
                        var ticketId = parkingLot.ParkVehicle(new Vehicle((VehicleType)Enum.Parse(typeof(VehicleType), command[1], true), command[2], command[3]));
                        if (ticketId == "Parking Lot Full")
                        {
                            Console.WriteLine(ticketId);
                        }
                        else
                        {
                            Console.WriteLine($"Parked vehicle. Ticket ID: {ticketId}");
                        }
                        break;
                    case "unpark_vehicle":
                        Console.WriteLine(parkingLot.UnparkVehicle(command[1]));
                        break;
                    case "display":
                        if (command[1] == "free_count")
                        {
                            parkingLot.DisplayFreeCount((VehicleType)Enum.Parse(typeof(VehicleType), command[2], true));
                        }
                        else if (command[1] == "free_slots")
                        {
                            parkingLot.DisplayFreeSlots((VehicleType)Enum.Parse(typeof(VehicleType), command[2], true));
                        }
                        else if (command[1] == "occupied_slots")
                        {
                            parkingLot.DisplayOccupiedSlots((VehicleType)Enum.Parse(typeof(VehicleType), command[2], true));
                        }
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
