using RoomBooking.CORE.Enums;
namespace RoomBooking.Shared.DTOs.Rooms
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Description { get; set; }  = string.Empty;
        public decimal Price {  get; set; }
        public string Location { get; set; } = string.Empty;
        public RoomType Type { get; set; } 
    }
}
