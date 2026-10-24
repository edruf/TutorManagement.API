using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using System.Diagnostics.SymbolStore;
using TutorManagment.API.Data;
using TutorManagment.API.DTOs;
using TutorManagment.API.Entities;



namespace TutorManagment.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;
    public StudentsController(AppDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult<ResponseStudentDto>> CreateStudent(CreateStudentDto dto) 
    {
        var student = new Student
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Target = dto.Target,
            Class = dto.Class,
            Contacts = dto.Contacts,
            CurrentBalance = 0
        };

        _context.Add(student);
        await _context.SaveChangesAsync();

        var responseDto = new ResponseStudentDto
        {
            ID = student.ID,
            FullName = $"{student.FirstName} {student.LastName}",
            Target = student.Target,
            CurrentBalance = student.CurrentBalance
        };
        return Ok(responseDto);
    }

    [HttpGet("{ID}")]
    public async Task<ActionResult<ResponseStudentDto>> GetStudent(int ID) 
    {
        var studentById = await _context.Students.FindAsync(ID);

        if (studentById == null)
        {
            return NotFound("Ученик с таким ID не найден");
        }

        var responseDto = new ResponseStudentDto
        {
            ID = studentById.ID,
            FullName = $"{studentById.FirstName} {studentById.LastName}",
            Target = studentById.Target,
            CurrentBalance = studentById.CurrentBalance
        };

        return Ok(responseDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseStudentDto>>> GetAllStudents() 
    {
        var students = await _context.Students
            .AsNoTracking()
            .Select(s => new ResponseStudentDto
            {
                ID = s.ID,
                FullName = $"{s.FirstName} {s.LastName}",
                Target = s.Target,
                CurrentBalance = s.CurrentBalance
            })
            .ToListAsync();

        return Ok(students);
    }

    [HttpDelete("{ID}")]

    public async Task<ActionResult> DeleteStudent(int id) 
    {
        var studentToDelete = await _context.Students.FindAsync(id);

        if (studentToDelete == null)
        {
            return NotFound("Ученик с таким ID не найден");
        }

        _context.Students.Remove(studentToDelete);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{ID}")]

    public async Task<ActionResult<ResponseStudentDto>> UpdateStudent(int id, CreateStudentDto dto) 
    {
        var studentToUpdate = await _context.Students.FindAsync(id);

        if (studentToUpdate == null)
        {
            return NotFound("Ученик с таким ID не найден");
        }

        studentToUpdate.FirstName = dto.FirstName;
        studentToUpdate.LastName = dto.LastName;
        studentToUpdate.Target = dto.Target;
        studentToUpdate.Class = dto.Class;
        studentToUpdate.Contacts = dto.Contacts;

        await _context.SaveChangesAsync();
        var UpdatedResponseDto = new ResponseStudentDto
        {
            ID = studentToUpdate.ID,
            FullName = $"{studentToUpdate.FirstName} {studentToUpdate.LastName}",
            Target = studentToUpdate.Target,
            CurrentBalance = studentToUpdate.CurrentBalance
        };

        return Ok(UpdatedResponseDto);
    }

    [HttpGet("{id}/progress")]
    public async Task<ActionResult<StudentProgressDto>> GetStudentProgress(int id) 
    {
        var student = await _context.Students
            .Include(s => s.Lessons)
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.ID == id);

        if (student == null)
        {
            return NotFound("Ученик с таким ID не найден");
        }

        var progressDto = new StudentProgressDto
        {
            Id = student.ID,
            FullName = $"{student.FirstName} {student.LastName}",
            CurrentBalance = student.CurrentBalance,
            PastLessons = student.Lessons.Select(l => new ResponseLessonDto 
            {
                ID = l.ID,
                Date = l.Date,
                Topic = l.Topic,
            }).ToList()
        };

        return Ok(progressDto);
    }
}
