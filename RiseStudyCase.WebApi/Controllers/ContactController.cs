using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/contacts")]
    public class ContactController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/get")]
        public IActionResult Get()
        {
            return Ok(Summaries);
        }

        [HttpGet]
        [Route("/getall")]
        public IActionResult GetAll()
        {
            return Ok(Summaries);
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(ContactModel contact)
        {
            return Ok(Summaries);
        }

        [HttpPatch]
        [Route("/remove")]
        public IActionResult RemoveContact(Guid id)
        {
            return Ok(Summaries);
        }

        [HttpPut]
        [Route("/update")]
        public IActionResult UpdateContact(ContactModel contact)
        {
            return Ok(Summaries);
        }

        [HttpDelete]
        [Route("/delete")]
        public IActionResult DeleteContact(Guid id)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("/addinfo")]
        public IActionResult AddInfo(Guid id, ContactType contactType, string contactInfo)
        {
            return Ok(Summaries);
        }

        [HttpPatch]
        [Route("/removeinfo")]
        public IActionResult RemoveInfo(Guid id, ContactType contactTyp)
        {
            return Ok(Summaries);
        }

    }
}