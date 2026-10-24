namespace TutorManagment.API.Entities;

public class Lesson
{
    public int ID { get; set; }
    public int StudentID { get; set; }
    public Student Student { get; set; }
    public DateTime Date { get; set; }
    public decimal LessonTime { get; set; }
    public decimal PricePerHour { get; set; } = 100; //Стоимость одного часа
    public string Status { get; set; } = "Запланирован";
    public string Topic { get; set; } = string.Empty;
    public Progress? Progress { get; set; }
}
