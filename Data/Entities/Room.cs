namespace ASP_.Net_Core_Class_Home_Work.Data.Entities;

public class Room
{
    
    public Guid Id { set; get; }
    public Guid LocationId { set; get; }
    public int? Stars { set; get; }
    public string Name { set; get; } = null!;
    public string Description { set; get; } = null!;
    public DateTime? DeleteDt { get; set; }// ознака доступності
}