using Meditelligence.DataAccess.Repositories;
using Meditelligence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Meditelligence.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepo _repo;

        public UserController(IUserRepo repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public IActionResult DeleteUser()
        {
            return Ok(_repo.DeleteUser());
        }

    }
}
