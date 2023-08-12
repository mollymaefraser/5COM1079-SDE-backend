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

        [HttpGet("GetSymptom/{id}")]
        public ActionResult<IEnumerable<SymptomReadDto>> GetSymptomById(int id)
        {
            var symptomRecords = _repo.GetSymptomById(id);
            return Ok(_mapper.Map<SymptomReadDto>(symptomRecords));
        }

        [HttpPost("CreateSymptom")]
        public ActionResult<SymptomReadDto> CreatePlatform(SymptomCreateDto symptomCreateDto) 
        {
            var symptomModel = _mapper.Map<Symptom>(symptomCreateDto);
            _repo.CreateSymptom(symptomModel);
            _repo.SaveChanges();

            var symptomReadDto = _mapper.Map<SymptomReadDto>(symptomModel);

            return CreatedAtRoute(nameof(GetSymptomById), new { Id = symptomReadDto.SymptomID }, symptomReadDto);
        }

    }
}
