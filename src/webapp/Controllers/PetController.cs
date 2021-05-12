using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapp.Models;
using webapp.Services;

namespace webapp.Controllers
{
    public class PetController : Controller
    {
        private readonly ILogger<PetController> _logger;
        private readonly PetService _petService;

        public PetController(ILogger<PetController> logger, PetService petService)
        {
            _logger = logger;
            _petService = petService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _petService.GetAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
