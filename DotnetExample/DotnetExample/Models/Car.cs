using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetExample.Models;

public class Car : Entity
{
    public User Owner { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}