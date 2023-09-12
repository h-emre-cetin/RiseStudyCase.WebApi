using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using RiseStudyCase.WebApi.Models;

namespace RiseStudyCase.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/report")]
    public class ContactReportController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ContactController> _logger;

        public ContactReportController(ILogger<ContactController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/getall")]
        public IActionResult Get()
        {
            return Ok(Summaries);
        }

    }
}