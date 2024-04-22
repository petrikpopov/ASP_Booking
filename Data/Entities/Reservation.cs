namespace ASP_.Net_Core_Class_Home_Work.Data.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid RoomId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    
    // navigation props
    public User User { set; get; }
    public Room Room { set; get; }
}