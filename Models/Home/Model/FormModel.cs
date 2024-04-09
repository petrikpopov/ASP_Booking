using Microsoft.AspNetCore.Mvc;

namespace Booking_Exam.Models.Home.Model;

public class FormModel
{
    [FromForm(Name = "input-name")]
    public string Name { set; get; }
    [FromForm(Name = "input-surname")]
    public string Surname { set; get; }
    [FromForm(Name = "input-email")]
    public string Email { set; get; }
    [FromForm(Name = "input-password")]
    public string Password { set; get; }
    [FromForm(Name = "input-phone")]
    public string Phone { set; get; }
}