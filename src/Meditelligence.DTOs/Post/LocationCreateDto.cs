using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    /// <summary>
    /// A DTO used for creating a new location record.
    /// </summary>
    public class LocationCreateDto
    {
        /// <summary>
        /// The latitude position of this location.
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// The longitude position of this location.
        /// </summary>
        [Required]
        public double Longitude { get; set; }

        /// <summary>
        /// The name of the location facility.
        /// </summary>
        [Required]
        public string NameOfFacility { get; set; }

        /// <summary>
        /// The address of the location facility.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// The telephone number of the facility.
        /// </summary>
        [Required]
        public string Telephone { get; set; }

        /// <summary>
        /// The contact email address of the facility.
        /// </summary>
        [Required]
        public string EmailAddress { get; set; }
    }
}
