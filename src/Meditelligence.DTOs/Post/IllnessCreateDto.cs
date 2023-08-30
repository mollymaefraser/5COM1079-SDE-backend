using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    /// <summary>
    /// A DTO used to create a illness record.
    /// </summary>
    public class IllnessCreateDto
    {
        /// <summary>
        /// The name of the illness.
        /// </summary>
        [Required]
        public string IllnessName { get; set; }

        /// <summary>
        /// A brief description of the illness.
        /// </summary>
        [Required]
        public string IllnessDescription { get; set; }

        /// <summary>
        /// A brief set of advice/instructions for patients who may have this illness.
        /// </summary>
        [Required]
        public string IllnessAdvice { get; set; }
    }
}
