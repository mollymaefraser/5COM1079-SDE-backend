using Meditelligence.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Meditelligence.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SymptomController : Controller
    {
        private readonly ISymptomRepo _repo;

        public SymptomController(ISymptomRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllSymptoms()
        {
            return Ok(_repo.GetAllSymptoms());
        }

    }
}
