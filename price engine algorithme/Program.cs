using System;
using System.Collections.Generic;

// Ensure there is no Main method in this file
class Program
{
    // This file will not contain a Main method anymore
}

// Sample implementations for testing purposes
public class SamplePricingEngine : IPricingEngine
{
    public Pricing GetPricing(string roomType, string season)
    {
        // Return dummy pricing based on room type and season
        return new Pricing { BasePrice = roomType == "Deluxe" ? 150 : 100 };
    }
}

public class SampleRoomService : IRoomService
{
    public List<Room> GetAvailableRooms(string roomType, int nights)
    {
        // Return dummy available rooms
        return new List<Room>
        {
            new Room { RoomId = 101 },
            new Room { RoomId = 102 }
        };
    }
}
