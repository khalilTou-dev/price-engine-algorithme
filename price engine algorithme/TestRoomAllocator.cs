using System;
using System.Collections.Generic;

public class TestRoomAllocator
{
    public static void Main(string[] args)
    {
        // Sample implementations of IPricingEngine and IRoomService
        IPricingEngine pricingEngine = new SamplePricingEngine();
        IRoomService roomService = new SampleRoomService();

        var allocator = new RoomAllocator(pricingEngine, roomService);

        var request1 = new BookingRequest
        {
            RoomType = "Deluxe",
            Nights = 3,
            Season = "Peak Season",
            SpecialRequests = new SpecialRequests
            {
                PreferredView = "sea",
                ConnectingRoom = false
            }
        };

        var response1 = allocator.AllocateRoom(request1);
        Console.WriteLine($"Response for Request 1: RoomType: {response1.RoomType}, AllocatedRoomId: {response1.AllocatedRoomId}, TotalPrice: {response1.TotalPrice}, Error: {response1.Error}");
    }
}


