namespace TutorManagment.API.Entities;

public class Progress
{
    public int ID { get; set; }
    public int LessonID { get; set; }
    public Lesson Lesson { get; set; }
    public string Theme { get; set; }
    public List<int> Marks { get; set; }
    public string Comment { get; set; }
}
