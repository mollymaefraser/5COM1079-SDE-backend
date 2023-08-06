using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    /// <summary>
    /// A DTO used for communicating information about a symptom.
    /// </summary>
    public class SymptomCreateDto
    {
        /// <summary>
        /// The name of the symptom.
        /// </summary>
        [Required]
        public string SymptomName { get; set; }

        /// <summary>
        /// The description of the symptom. 
        /// </summary>
        /// <remarks>Defaults to empty string.</remarks>
        [Required]
        public string SymptomDescription { get; set; }
    }
}
