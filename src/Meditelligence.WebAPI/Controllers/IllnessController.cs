using AutoMapper;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.DTOs.Post;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Meditelligence.WebAPI.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("[controller]")]
    public class IllnessController : Controller
    {
        private readonly IIllnessRepo _repo;
        private readonly IMapper _mapper;
        private readonly IIllnessToSymptomRepo _joinRepo;
        private readonly ILogger<IllnessController> _logger;

        public IllnessController(IIllnessRepo repo, IMapper mapper, IIllnessToSymptomRepo joinRepo, ILogger<IllnessController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _joinRepo = joinRepo;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<IllnessReadDto>> GetAllIllnesses()
        {
            var illnessRecords = _repo.GetAllIllnesses();
            return Ok(_mapper.Map<IEnumerable<IllnessReadDto>>(illnessRecords));
        }

        [HttpGet("GetIllness/{id}", Name =nameof(GetIllnessById))]
        public ActionResult<IllnessReadDto> GetIllnessById(int id)
        {
            var illnessRecord = _repo.GetIllnessById(id);
            if (illnessRecord == null)
            {
                return BadRequest(_mapper.Map<IllnessReadDto>(illnessRecord));
            }
            return Ok(_mapper.Map<IllnessReadDto>(illnessRecord));
        }

        [HttpPost("CreateIllness")]
        public ActionResult<IllnessReadDto> CreateIllness(IllnessCreateDto illnessCreateDto)
        {
            try
            {
                var illnessModel = _mapper.Map<Illness>(illnessCreateDto);
                _repo.CreateIllness(illnessModel);
                _repo.SaveChanges();

                var illnessReadDto = _mapper.Map<IllnessReadDto>(illnessModel);

                return CreatedAtRoute(nameof(GetIllnessById), new { id = illnessReadDto.IllnessID }, illnessReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("LinkIllnessToSymptom")]
        public ActionResult<string> CreateIllnessToSymptom(int illnessID, int symptomID)
        {
            try
            {
                _joinRepo.CreateIllnessToSymptom(illnessID, symptomID);
                _joinRepo.SaveChanges();
                return Ok("Added symptom to illness");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
