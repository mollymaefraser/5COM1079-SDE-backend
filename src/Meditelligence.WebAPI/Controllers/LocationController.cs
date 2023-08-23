using AutoMapper;
using GeoCoordinatePortable;
using Meditelligence.DataAccess.Repositories;
using Meditelligence.DataAccess.Repositories.Interfaces;
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
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationToServiceRepo _joinRepo;
        private readonly IServiceRepo _serviceRepo;

        public LocationController(ILocationRepo repo, IMapper mapper, ILocationToServiceRepo joinRepo, ILogger<LocationController> logger, IServiceRepo serviceRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
            _joinRepo = joinRepo;
            _serviceRepo = serviceRepo;
        }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<LocationReadDto>> GetAllLocations(double? latitude = null, double? longitude = null)
        {
            var resultList = new List<LocationReadDto>();
            var LocationRecords = _repo.GetAllLocations();
            foreach (var location in LocationRecords)
            {
                var mappedDto = _mapper.Map<LocationReadDto>(location);
                var joinrecords = _joinRepo.GetLocationToServiceByLocationID(location.LocationID);
                foreach (var joinrecord in joinrecords)
                {
                    var serviceRecord = _mapper.Map<ServiceReadDto>(_serviceRepo.GetServiceById(joinrecord.RefServiceID));
                    mappedDto.OfferedServices.Add(serviceRecord);
                }

                resultList.Add(mappedDto);
            }

            if (latitude is not null && longitude is not null)
            {
                var coord = new GeoCoordinate(latitude.Value, longitude.Value);

                // this line both checks distance and extracts closest 3 locations.
                var nearest = resultList.Select(x => new Tuple<LocationReadDto, GeoCoordinate>(x, new GeoCoordinate(x.Latitude, x.Longitude)))
                    .OrderBy(x => x.Item2.GetDistanceTo(coord)).Take(3).Select(x => x.Item1);
                return Ok(nearest.ToList());
            }

            return Ok(resultList);
        }

        [HttpGet("GetLocation/{id}", Name = nameof(GetLocationById))]
        public ActionResult<LocationReadDto> GetLocationById(int id)
        {
            var LocationRecords = _repo.GetLocationById(id);
            if (LocationRecords == null)
            {
                return BadRequest(_mapper.Map<LocationReadDto>(LocationRecords));
            }
            return Ok(_mapper.Map<LocationReadDto>(LocationRecords));
        }

        [HttpPost("CreateLocation")]
        public ActionResult<LocationReadDto> CreateLocation(LocationCreateDto LocationCreateDto)
        {
            try
            {
                var LocationModel = _mapper.Map<Location>(LocationCreateDto);
                _repo.CreateLocation(LocationModel);
                _repo.SaveChanges();

                var LocationReadDto = _mapper.Map<LocationReadDto>(LocationModel);

                return CreatedAtRoute(nameof(GetLocationById), new { id = LocationReadDto.LocationID }, LocationReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("LinkLocationToService")]
        public ActionResult<string> CreateServiceToLocation(int locationID, int serviceID)
        {
            try
            {
                _joinRepo.CreateLocationToService(locationID, serviceID);
                _joinRepo.SaveChanges();
                return Ok($"Added service to location");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
