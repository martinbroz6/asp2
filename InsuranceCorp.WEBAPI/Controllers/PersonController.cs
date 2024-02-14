using InsuranceCorp.Data;
using InsuranceCorp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCorp.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly InsCorpDbContext db;

        public PersonController(InsCorpDbContext db)
        {
            this.db = db;
        }

        //[Route("List")]
        [HttpGet("List")]
        public ActionResult<List<Person>> List(int start, int take)
        {
            return db.Persons.Skip(start).Take(take).ToList();
        }

        [HttpGet("Find/{email}")]
        public ActionResult<List<Person>> Find(string email)
        {
            return db.Persons.Where(x => x.Email != null && x.Email.Contains(email)).ToList();
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public ActionResult<Person> getPerson(int id)
        {
            var person = db.Persons
                .Include(x => x.Address)
                .Include(x => x.Contracts)
                .FirstOrDefault(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult postPerson(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();

            return Created($"/api/person/{person.Id}", person);
        }
    }
}
