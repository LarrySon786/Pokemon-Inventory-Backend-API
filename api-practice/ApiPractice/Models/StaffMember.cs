using System.ComponentModel.DataAnnotations;

namespace ApiPractice.Models;

public class StaffMember
{
    [Key]
    public int Id { get; set; }

    // Properties
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}