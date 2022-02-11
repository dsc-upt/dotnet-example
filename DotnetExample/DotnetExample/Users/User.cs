using System.ComponentModel.DataAnnotations;

namespace DotnetExample.Users;

public class User : Entity
{
    [Required] public string Username { get; set; }

    [Required] [EmailAddress] public string Email { get; set; }
}
