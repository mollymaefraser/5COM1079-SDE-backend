using AutoMapper;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Read;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.WebAPITests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLogController : Controller
    {
        private readonly IUserLogRepo _repo;
        private readonly IMapper _mapper;

        public UserLogController(IUserLogRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<UserLogReadDto> GetAllLogs()
        {
            return null;
        }
    }
}
