using Meditelligence.DataAccess.Context;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public class LocationRepo : ILocationRepo
    {
        private readonly MeditelligenceDBContext _context;

        public LocationRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        public void CreateLocation(Location location)
        {
            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            if (_context.Locations.Any(l => l.Latitude == location.Latitude && l.Longitude == location.Longitude)) 
            {
                throw new InvalidDataException("This location already exists.");
            }

            _context.Locations.Add(location);
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.FirstOrDefault(i => i.LocationID == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
