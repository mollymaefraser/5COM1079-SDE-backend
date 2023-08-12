using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    public class PredictionReadDto
    {
        /// <summary>
        /// The predicted illness.
        /// </summary>
        public IllnessReadDto Illness { get; set; }

        /// <summary>
        /// The list of symptoms associated with this illness.
        /// </summary>
        public List<SymptomReadDto> Symptoms { get; set; } 
    }
}
