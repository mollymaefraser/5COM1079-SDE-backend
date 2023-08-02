using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    /// <summary>
    /// A DTO used to communicate information around an Illness.
    /// </summary>
    public class IllnessReadDto
    {
        /// <summary>
        /// The illness name.
        /// </summary>
        public string IllnessName { get; set; }

        /// <summary>
        /// The illness description.
        /// </summary>
        public string IllnessDescription { get; set; }

        /// <summary>
        /// The illness advice.
        /// </summary>
        public string IllnessAdvice { get; set; }

        /// <summary>
        /// The list of symptoms associated with this illness.
        /// </summary>
        public List<SymptomReadDto> Symptoms { get; set; }
    }
}
