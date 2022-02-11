using DotnetExample.Users;

namespace DotnetExample.Teams;

public class Team : Entity
{
    public User TeamLead { get; set; }
    public string Name { get; set; }
    public string GithubLink { get; set; }
}
