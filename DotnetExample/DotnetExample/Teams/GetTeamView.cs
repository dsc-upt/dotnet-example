namespace DotnetExample.Teams;

public class GetTeamView
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string GithubLink { get; set; }
    public GetTeamLeadView TeamLead { get; set; }
}
