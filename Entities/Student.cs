namespace TutorManagment.API.Entities;

public class Student : User
{
    public int ID { get; set; }
    public int UserID { get; set; }
    public User User { get; set; }
    public string Login { get; set; }
    public int PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Target { get; set; }
    public int Class { get; set; }
    public string Contacts { get; set; }
    public decimal CurrentBalance { get; set; }
    public List<Lesson> Lessons { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();
}
