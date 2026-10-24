using Microsoft.EntityFrameworkCore.Metadata;

namespace TutorManagment.API.DTOs;

public class CreateStudentDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Target { get; set; }
    public int Class { get; set; }
    public string Contacts { get; set; } 
}

public class ResponseStudentDto 
{
    public int ID { get; set; }
    public string FullName { get; set; }
    public string Target { get; set; }
    public decimal CurrentBalance { get; set; }
}

public class StudentProgressDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public decimal CurrentBalance { get; set; }
    public List<ResponseLessonDto> PastLessons { get; set; } = new();
}