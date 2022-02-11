using DotnetExample.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetExample.Teams;

[ApiController]
[Route("api/teams")]
public class TeamsController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public TeamsController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public List<Team> Get()
    {
        return new List<Team>();
    }

    [HttpPost]
    public async Task<GetTeamView> Add(AddTeamView teamView)
    {
        var teamLead = await _appDbContext.Users.FirstOrDefaultAsync(user => user.Id == teamView.TeamLeadId);

        if (teamLead is null)
        {
            throw new ArgumentException("Team lead not found!");
        }

        var team = new Team
        {
            // Guid - Global Unique ID
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            GithubLink = teamView.GithubLink,
            Name = teamView.Name,
            TeamLead = teamLead
        };

        await _appDbContext.Teams.AddAsync(team);
        await _appDbContext.SaveChangesAsync();

        return new GetTeamView
        {
            GithubLink = team.GithubLink,
            Id = team.Id,
            Name = team.Name,
            TeamLead = new GetTeamLeadView
            {
                Email = team.TeamLead.Email,
                Username = team.TeamLead.Username
            }
        };
    }
}
