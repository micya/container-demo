using System.Collections.Generic;
using common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.Data;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly ILogger<PetController> _logger;
        private readonly PetContext _context;

        public PetController(ILogger<PetController> logger, PetContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _context.Pets;
        }
    }
}
