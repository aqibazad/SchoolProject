using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class EmployeeViewModel
{
    [Required(ErrorMessage = "Staff ID is required.")]
    public string EmployeeId { get; set; }
    public string? CampusId { get; set; }
    public string? UserId { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    public string Name { get; set; }

    public string FatherName { get; set; }

    public string Surname { get; set; }

    [Required(ErrorMessage = "Designation is required.")]
    public string Designation { get; set; }

    [Required(ErrorMessage = "Date of Birth is required.")]
    public DateTime? Dob { get; set; }

    public DateTime? DateOfJoining { get; set; }

    [Required(ErrorMessage = "Role is required.")]
    public string Role { get; set; }

    [Required(ErrorMessage = "Gender is required.")]
    public string Gender { get; set; }

    public string Department { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    public string Password { get; set; }

    public string ContactNo { get; set; }

    public string EmergencyNo { get; set; }

    public string MaritalStatus { get; set; }

    public string Address { get; set; }

    public string PermanentAddress { get; set; }

    public string Note { get; set; }

    [Required(ErrorMessage = "Qualification is required.")]
    public string Qualification { get; set; }

    [Required(ErrorMessage = "Work Experience is required.")]
    public int WorkExperience { get; set; }

    [Required(ErrorMessage = "PAN Number is required.")]
    public string PanNumber { get; set; }

    public IFormFile Photo { get; set; }
    public IFormFile Resume { get; set; }
}
