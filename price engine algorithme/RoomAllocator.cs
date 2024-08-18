using System;
using System.Collections.Generic;
using System.Linq;

public class RoomAllocator
{
    private readonly IPricingEngine _pricingEngine;
    private readonly IRoomService _roomService;

    public RoomAllocator(IPricingEngine pricingEngine, IRoomService roomService)
    {
        _pricingEngine = pricingEngine;
        _roomService = roomService;
    }

    public AllocationResponse AllocateRoom(BookingRequest request)
    {
        // Fetch pricing from the dynamic pricing engine
        var pricing = _pricingEngine.GetPricing(request.RoomType, request.Season);

        // Fetch available rooms
        var availableRooms = _roomService.GetAvailableRooms(request.RoomType, request.Nights);

        // Filter rooms based on special requests
        var filteredRooms = availableRooms.Where(room =>
            room.HasView(request.SpecialRequests.PreferredView) &&
            (!request.SpecialRequests.ConnectingRoom || room.IsConnectingRoom())
        ).ToList();

        // If no rooms match, return an error response
        if (filteredRooms.Count == 0)
        {
            return new AllocationResponse
            {
                RoomType = request.RoomType,
                Error = "No available rooms meet the special requests."
            };
        }

        // Allocate the first available room (simple approach)
        var allocatedRoom = filteredRooms.First();
        var totalPrice = pricing.BasePrice * request.Nights; // Example calculation

        return new AllocationResponse
        {
            RoomType = request.RoomType,
            AllocatedRoomId = allocatedRoom.RoomId,
            TotalPrice = totalPrice,
            SpecialRequests = request.SpecialRequests
        };
    }
}
