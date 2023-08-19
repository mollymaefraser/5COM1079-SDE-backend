using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public class LocationToServiceRepo : ILocationToServiceRepo
    {
        private readonly MeditelligenceDBContext _context;
        private readonly ILogger<LocationToServiceRepo> _logger;

        public LocationToServiceRepo(MeditelligenceDBContext context, ILogger<LocationToServiceRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <inheritdoc/>
        public void CreateLocationToService(int locationID, int serviceID)
        {
            if (_context.Locations.Find(locationID) == null)
            {
                throw new ArgumentException("The illness could not be found.");
            }
            else if (_context.Services.Find(serviceID) == null)
            {
                throw new ArgumentException("The symptom could not be found.");
            }
            else
            {
                if (_context.LocationToServices.Any(i => i.RefLocationID == locationID && i.RefServiceID == serviceID))
                {
                    _logger.LogInformation("Record between Location with ID {locationID} & service with ID {serviceID} not created as already exists.", locationID, serviceID);
                    return;
                }
                else
                {
                    _context.LocationToServices.Add(new LocationToService()
                    {
                        RefLocationID = locationID,
                        RefServiceID = serviceID,
                    });
                }
            }
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
