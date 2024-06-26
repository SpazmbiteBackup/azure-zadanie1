using AzureWebsite.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AzureWebsite.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly ILogger<PeopleController> logger;
    private readonly PeopleDb db;

    public PeopleController(ILogger<PeopleController> logger, PeopleDb db)
    {
        this.logger = logger;
        this.db = db;
    }

    [HttpGet(Name = "GetPeople")]
    public async Task<IEnumerable<Person>> Get()
    {
        // var mock = new List<Person>
        // {
        //     new Person(firstName: "Jan", lastName: "Nowak", phoneNumber: "123321123"),
        //     new Person(firstName: "Marek", lastName: "Kowalski")
        // };

        var people = await db.People.ToListAsync();
        return people;
    }
}
