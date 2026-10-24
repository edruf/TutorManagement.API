namespace TutorManagment.API.DTOs;

public class CreateLessonDto
{
    public int StudentID { get; set; }
    public DateTime Date { get; set; }
    public decimal LessonTime { get; set; }
    public string Topic { get; set; } = string.Empty;
    public decimal PricePerHour { get; set; } = 100; //Стоимость одного часа 
}

public class ResponseLessonDto 
{
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public string Topic { get; set; } = string.Empty;
    public decimal PriceForLesson { get; set; }
    public decimal RemainingBalance { get; set; }
}