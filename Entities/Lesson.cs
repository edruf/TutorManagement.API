namespace TutorManagment.API.Entities;

public class Lesson
{
    public int ID { get; set; }
    public int StudentID { get; set; }
    public Student Student { get; set; }
    public DateTime Date { get; set; }
    public int LessonTinme { get; set; }
    public string Status { get; set; } = "Запланирован";
    public Progress? Progress { get; set; }
}
