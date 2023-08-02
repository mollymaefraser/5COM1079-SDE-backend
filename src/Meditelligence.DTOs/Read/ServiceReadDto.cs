using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    public class ServiceReadDto
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
