namespace TutorManagment.API.Entities;

public class User
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public int? PasswordHash { get; set; }
    public string? Role { get; set; }

    public Student? StudentProfile { get; set; }
}
