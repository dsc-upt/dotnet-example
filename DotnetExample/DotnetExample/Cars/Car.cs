using DotnetExample.Users;

namespace DotnetExample.Cars;

public class Car : Entity
{
    public User Owner { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
}
