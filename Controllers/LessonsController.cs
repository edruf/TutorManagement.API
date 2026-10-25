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
public class LessonsController: ControllerBase
{
    private readonly AppDbContext _context;
    public LessonsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseLessonDto>> CreateLesson(CreateLessonDto dto) 
    {
        var student = await _context.Students.FindAsync(dto.StudentID);

        if (student == null)
        {
            return NotFound("Ученик не найден");
        }

        var lesson = new Lesson
        {
            StudentID = dto.StudentID,
            Date = dto.Date,
            LessonTime = dto.LessonTime,
            Topic = dto.Topic
        };

        student.CurrentBalance -= dto.PricePerHour * dto.LessonTime;
        _context.Lessons.Add(lesson);
        await _context.SaveChangesAsync();

        var responseDto = new ResponseLessonDto
        {
            ID = lesson.ID,
            Date = lesson.Date,
            Topic = dto.Topic,
            PriceForLesson = dto.PricePerHour * dto.LessonTime,
            RemainingBalance = student.CurrentBalance
        };
        return Ok(responseDto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseLessonDto>>> GetLessons([FromQuery] DateTime? date) 
    {
        var query = _context.Lessons.AsNoTracking();

        if(date.HasValue)
        {
            var startDate = date.Value.Date;
            var endDate = startDate.AddDays(1);

            query = query.Where(l => l.Date >= startDate && l.Date < endDate);
        }

        var lessons = await query
            .Select(lesson => new ResponseLessonDto
            {
                ID = lesson.ID,
                Date = lesson.Date,
                Topic = lesson.Topic,
                PriceForLesson = lesson.PricePerHour * lesson.LessonTime,
                RemainingBalance = lesson.Student.CurrentBalance
            })
            .ToListAsync();

        return Ok(lessons);
    }

}
