using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorManagment.API.Entities;

[Table("Students")]
public class Student : User
{
    public Student()
    {
        Role = "Student";
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Target { get; set; }
    public int Class { get; set; }
    public string Contacts { get; set; }
    public decimal CurrentBalance { get; set; }
    public List<Lesson> Lessons { get; set; } = new();
    public List<Payment> Payments { get; set; } = new();
}
