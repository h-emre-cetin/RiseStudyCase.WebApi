using Microsoft.AspNetCore.Mvc;
using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Models;
using RiseStudyCase.WebApi.Repositories.EntitiyFramework;

namespace RiseStudyCase.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/contacts")]
    public class ContactController : ControllerBase
    {
       
        private readonly ILogger<ContactController> _logger;
        IContactRepository _contactRepository;
        public ContactController(ILogger<ContactController> logger, EfContactRepository efContactRepository)
        {
            _logger = logger;
            _contactRepository = efContactRepository;
        }

        [HttpGet]
        [Route("/get")]
        public IActionResult Get(Guid id)
        {
            var res = _contactRepository.Get(id);

            return Ok(res);

        }

        [HttpGet]
        [Route("/getall")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(ContactModel contact)
        {
            var res = _contactRepository.Create(contact);
            return Ok(res);
        }

        [HttpPatch]
        [Route("/remove")]
        public IActionResult RemoveContact(Guid id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("/update")]
        public IActionResult UpdateContact(ContactModel contact)
        {
            return Ok();
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
            return Ok();
        }

        [HttpPatch]
        [Route("/removeinfo")]
        public IActionResult RemoveInfo(Guid id, ContactType contactTyp)
        {
            return Ok();
        }

    }
}