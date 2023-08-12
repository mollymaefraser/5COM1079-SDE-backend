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
    public class LocationController : Controller
    {
        private readonly ILocationRepo _repo;

        private readonly IMapper _mapper;

        public LocationController(ILocationRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<LocationReadDto>> GetAllLocations()
        {
            var LocationRecords = _repo.GetAllLocations();
            return Ok(_mapper.Map<IEnumerable<LocationReadDto>>(LocationRecords));
        }

        [HttpGet("GetLocation/{id}")]
        public ActionResult<IEnumerable<LocationReadDto>> GetLocationById(int id)
        {
            var LocationRecords = _repo.GetLocationById(id);
            return Ok(_mapper.Map<LocationReadDto>(LocationRecords));
        }

        [HttpPost("CreateLocation")]
        public ActionResult<LocationReadDto> CreatePlatform(LocationCreateDto LocationCreateDto)
        {
            var LocationModel = _mapper.Map<Location>(LocationCreateDto);
            _repo.CreateLocation(LocationModel);
            _repo.SaveChanges();

            var LocationReadDto = _mapper.Map<LocationReadDto>(LocationModel);

            return CreatedAtRoute(nameof(GetLocationById), new { Id = LocationReadDto.LocationID }, LocationReadDto);
        }
    }
}
