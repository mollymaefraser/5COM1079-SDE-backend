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
    public class SymptomController : Controller
    {
        private readonly ISymptomRepo _repo;

        private readonly IMapper _mapper;

        public SymptomController(ISymptomRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<SymptomReadDto>> GetAllSymptoms()
        {
            var symptomRecords = _repo.GetAllSymptoms();
            return Ok(_mapper.Map<IEnumerable<SymptomReadDto>>(symptomRecords));
        }

        [HttpGet("GetSymptom/{id}", Name=nameof(GetSymptomById))]
        public ActionResult<SymptomReadDto> GetSymptomById(int id)
        {
            var symptomRecords = _repo.GetSymptomById(id);
            if (symptomRecords is null)
            {
                return BadRequest(_mapper.Map<SymptomReadDto>(symptomRecords));
            }

            return Ok(_mapper.Map<SymptomReadDto>(symptomRecords));
        }

        [HttpPost("CreateSymptom")]
        public ActionResult<SymptomReadDto> CreateSymptom(SymptomCreateDto symptomCreateDto) 
        {
            try
            {
                var symptomModel = _mapper.Map<Symptom>(symptomCreateDto);
                _repo.CreateSymptom(symptomModel);
                _repo.SaveChanges();

                var symptomReadDto = _mapper.Map<SymptomReadDto>(symptomModel);

                return CreatedAtRoute(nameof(GetSymptomById),new { id = symptomReadDto.SymptomID }, symptomReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
