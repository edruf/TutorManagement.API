namespace TutorManagment.API.Entities;

public class StudentAvailability
{
    public int ID { get; set; }
    public int StudentID { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
