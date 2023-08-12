using AutoMapper;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meditelligence.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IllnessController : Controller
    {
        private readonly IIllnessRepo _repo;
        private readonly IMapper _mapper;

        public IllnessController(IIllnessRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<IllnessReadDto>> GetAllIllnesses()
        {
            var illnessRecords = _repo.GetAllIllnesses();
            return Ok(_mapper.Map<IEnumerable<IllnessReadDto>>(illnessRecords));
        }

        [HttpGet("GetIllness/{id}")]
        public ActionResult<IEnumerable<IllnessReadDto>> GetIllnessById(int id)
        {
            var illnessRecord = _repo.GetIllnessById(id);
            return Ok(_mapper.Map<IllnessReadDto>(illnessRecord));
        }

        [HttpPost("CreateIllness")]
        public ActionResult<IllnessReadDto> CreatePlatform(IllnessCreateDto symptomCreateDto)
        {
            var illnessModel = _mapper.Map<Illness>(symptomCreateDto);
            _repo.CreateIllness(illnessModel);
            _repo.SaveChanges();

            var illnessReadDto = _mapper.Map<SymptomReadDto>(illnessModel);

            return CreatedAtRoute(nameof(GetIllnessById), new { Id = illnessReadDto.SymptomID }, illnessReadDto);
        }
    }
}
