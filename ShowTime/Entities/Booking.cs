using ShowTime.Enum;

namespace ShowTime.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string Event { get; set; } = string.Empty;
        public int ApplicationUserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int FestivalId { get; set; }
        public Festival? Festival { get; set; }
        public DateTime BookingDate { get; set; }
        public Status Status { get; set; } 
    }
}
