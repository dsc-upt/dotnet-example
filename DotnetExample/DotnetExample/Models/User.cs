using System.ComponentModel.DataAnnotations;

namespace DotnetExample.Models;

public class User : Entity
{
    [Required]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
