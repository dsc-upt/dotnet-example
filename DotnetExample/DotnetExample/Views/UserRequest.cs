using System.ComponentModel.DataAnnotations;

namespace DotnetExample.Views;

public class UserRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}