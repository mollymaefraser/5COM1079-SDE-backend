using Meditelligence.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Meditelligence.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IllnessController : Controller
    {
        private readonly IIllnessRepo _repo;

        public IllnessController(IIllnessRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllIllnesses()
        {
            return Ok(_repo.GetAllIllnesses());
        }
    }
}
