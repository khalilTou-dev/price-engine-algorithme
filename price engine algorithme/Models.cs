public interface IPricingEngine
{
    Pricing GetPricing(string roomType, string season);
}

public interface IRoomService
{
    List<Room> GetAvailableRooms(string roomType, int nights);
}

public class Pricing
{
    public decimal BasePrice { get; set; }
}

public class Room
{
    public int RoomId { get; set; }
    public bool HasView(string view) { /* Example implementation */ return true; }
    public bool IsConnectingRoom() { /* Example implementation */ return true; }
}

public class BookingRequest
{
    public string RoomType { get; set; }
    public int Nights { get; set; }
    public string Season { get; set; }
    public SpecialRequests SpecialRequests { get; set; }
}

public class SpecialRequests
{
    public string PreferredView { get; set; }
    public bool ConnectingRoom { get; set; }
}

public class AllocationResponse
{
    public string RoomType { get; set; }
    public int? AllocatedRoomId { get; set; }
    public decimal? TotalPrice { get; set; }
    public SpecialRequests SpecialRequests { get; set; }
    public string Error { get; set; }
}
