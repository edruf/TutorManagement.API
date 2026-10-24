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
public class PaymentsController :ControllerBase
{
    private readonly AppDbContext _context;
    public PaymentsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    async public Task<ActionResult<ResponsePaymentDto>> CreatePayment(CreatePaymentDto dto) 
    {
        var studentToPay = await _context.Students.FindAsync(dto.StudentID);

        if(studentToPay == null)
        {
            return NotFound();
        }

        var payment = new Payment
        {
            StudentID = dto.StudentID,
            Amount = dto.Amount,
            PaymentDate = DateTime.UtcNow
        };

        studentToPay.CurrentBalance += dto.Amount;   
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var responseDto = new ResponsePaymentDto
        {
            ID = payment.ID,
            Amount = payment.Amount,
            PaymentDate = payment.PaymentDate,
            NewStudentBalance = studentToPay.CurrentBalance
        };

        return Ok(responseDto);
    }

}
