using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    /// <summary>
    /// A DTO used to create a new service record.
    /// </summary>
    public class ServiceCreateDto
    {
        /// <summary>
        /// The name of the service offered.
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// A short description of the service.
        /// </summary>
        public string ServiceDescription { get; set; }
    }
}
