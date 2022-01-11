using Bogus;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ContactsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]"), ActionName("contact")]
        public ActionResult<Contact> GetHero(string name)
        {
            var contact = new Faker<Contact>()
                .RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
                .RuleFor(x => x.Email, x => x.Internet.Email())
                .Generate();

            _logger.LogInformation(
                "You can reach {name} at {phone} and write at {email}", 
                name,
                contact.Phone,
                contact.Email);

            return Ok(contact);
        }
    }
}
