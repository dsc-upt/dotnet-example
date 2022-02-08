using System.ComponentModel.DataAnnotations;

namespace DotnetExample.Users;

public class UserRequest
{
    [Required]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
