using Microsoft.AspNetCore.Mvc;

namespace RiseStudyCase.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/report/get/")]
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
        [Route("/location")]
        public IActionResult GetReportByLocation()
        {
            return Ok(Summaries);
        }

        [HttpGet]
        [Route("/locationRank")]
        public IActionResult GetReportOfLocationRank()
        {
            return Ok(Summaries);
        }

        [HttpGet]
        [Route("/locationContactCount")]
        public IActionResult GetReportOfLocationContactCount()
        {
            return Ok(Summaries);
        }

        [HttpGet]
        [Route("/locationPhoneNumber")]
        public IActionResult GetReportOfLocationPhoneNumberCount()
        {
            return Ok(Summaries);
        }

    }
}