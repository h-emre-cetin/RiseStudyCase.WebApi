using Microsoft.AspNetCore.Mvc;
using RiseStudyCase.WebApi.Business.Abstract;
using RiseStudyCase.WebApi.Models;
using RiseStudyCase.WebApi.Repositories.EntitiyFramework;

namespace RiseStudyCase.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            var res = _contactRepository.GetAll();

            return Ok();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(ContactModel contact)
        {
            var res = _contactRepository.Create(contact);

            //var response = HttpContext.Response.StatusCode = 201;


            return Ok(res);
        }

        [HttpPatch]
        [Route("/remove")]
        public IActionResult RemoveContact(Guid id)
        {
            var res = _contactRepository.Remove(id);

            return Ok();
        }

        [HttpPut]
        [Route("/update")]
        public IActionResult UpdateContact(ContactModel contact)
        {
            var res = _contactRepository.Update(contact);

            return Ok(res);
        }

        [HttpDelete]
        [Route("/delete")]
        public IActionResult DeleteContact(Guid id)
        {
            var res = _contactRepository.Delete(id);

            return NoContent();
        }

        [HttpPatch]
        [Route("/addinfo")]
        public IActionResult AddInfo(Guid id, ContactType contactType, string contactInfo)
        {
            var res = _contactRepository.AddInfo(id, contactType, contactInfo);

            return Ok(res);
        }

        [HttpPatch]
        [Route("/removeinfo")]
        public IActionResult RemoveInfo(Guid id, ContactType contactType)
        {
            var res = _contactRepository.RemoveInfo(id, contactType);

            return Ok(res);
        }

    }
}