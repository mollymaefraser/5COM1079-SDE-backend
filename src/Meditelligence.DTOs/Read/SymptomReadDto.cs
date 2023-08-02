using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    /// <summary>
    /// A DTO used for communicating information about a symptom.
    /// </summary>
    public class SymptomReadDto
    {
        /// <summary>
        /// The name of the symptom.
        /// </summary>
        public string SymptomName { get; set; }

        /// <summary>
        /// The description of the symptom. 
        /// </summary>
        /// <remarks>Defaults to empty string.</remarks>
        public string SymptomDescription { get; set; } = string.Empty;
    }
}
