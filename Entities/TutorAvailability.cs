namespace TutorManagment.API.Entities;

public class TutorAvailability
{
    public int ID { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
