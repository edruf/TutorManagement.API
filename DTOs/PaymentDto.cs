namespace TutorManagment.API;

public class CreatePaymentDto
{
    public int StudentID { get; set; }
    public decimal Amount { get; set; }
}

public class ResponsePaymentDto
{
    public int ID { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal NewStudentBalance { get; set; }
}