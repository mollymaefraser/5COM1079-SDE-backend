using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public class ServiceRepo : IServiceRepo
    {
        private readonly MeditelligenceDBContext _context;

        public ServiceRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public void CreateService(Service Service)
        {
            if (Service is null)
            {
                throw new ArgumentNullException(nameof(Service));
            }

            Service.Name = Service.Name.ToLower();
            if (_context.Services.Any(l => l.Name.ToLower() == Service.Name))
            {
                throw new InvalidDataException("This Service already exists.");
            }

            _context.Services.Add(Service);
        }

        /// <inheritdoc/>
        public IEnumerable<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        /// <inheritdoc/>
        public Service GetServiceById(int id)
        {
            return _context.Services.FirstOrDefault(i => i.ServiceID == id);
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
