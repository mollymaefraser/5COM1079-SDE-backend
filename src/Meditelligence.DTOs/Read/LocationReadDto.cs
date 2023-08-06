using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    public class LocationReadDto
    {
        /// <summary>
        /// The unique ID for this location.
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// The latitude position of this location.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude position of this location.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// The name of the location facility.
        /// </summary>
        public string NameOfFacility { get; set; }

        /// <summary>
        /// The address of the location facility.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The telephone number of the facility.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// The contact email address of the facility.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// The services associated with this facility.
        /// </summary>
        public List<ServiceReadDto> OfferedServices { get; set; } 
    }
}
