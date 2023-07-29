using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    /// <summary>
    /// A class to represent the join table between <see cref="Location"/> and <see cref="Service"/>.
    /// </summary>
    [PrimaryKey(nameof(RefLocationID), nameof(RefServiceID))]
    public class LocationToService
    {
        /// <summary>
        /// The reference location ID of the <see cref="Location"/> record.
        /// </summary>
        public int RefLocationID { get; set; }

        /// <summary>
        /// The reference service ID of the <see cref="Service"/> record.
        /// </summary>
        public int RefServiceID { get; set; }

        /// <summary>
        /// The location record reference object.
        /// </summary>
        public Location RefLocation { get; set; }

        /// <summary>
        /// The service record reference object.
        /// </summary>
        public Service RefService { get; set; }
    }
}
