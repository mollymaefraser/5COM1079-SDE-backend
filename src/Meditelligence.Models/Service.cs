using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    /// <summary>
    /// A class to model the Service table in the DB design.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// The unique identifier for this record.
        /// </summary>
        [Key]
        public int ServiceID { get; set; }

        /// <summary>
        /// The name of the service offered.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A list of join table records for this service.
        /// </summary>
        [ForeignKey("RefServiceID")]
        public ICollection<LocationToService> locationServices { get; set; }
    }
}
