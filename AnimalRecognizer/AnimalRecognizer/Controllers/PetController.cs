using Microsoft.AspNetCore.Mvc;

namespace AnimalRecognizer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
     
        private readonly ILogger<PetController> _logger;

        public PetController(ILogger<PetController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPet")]
        public string Get()
        {
            return "Hi, I'm pet";
        }
    }
}