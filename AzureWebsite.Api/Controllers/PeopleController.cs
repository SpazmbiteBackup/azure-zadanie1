using AzureWebsite.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureWebsite.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> logger;
    private readonly AOrtmanDB db;

    public PeopleController(ILogger<PeopleController> logger, AOrtmanDB db)
    {
        this.logger = logger;
        this.db = db;
    }

    [HttpGet(Name = "GetPeople")]
    public async Task<IEnumerable<Person>> Get()
    {
        var people = await db.People.ToListAsync();
        return people;
    }
}
