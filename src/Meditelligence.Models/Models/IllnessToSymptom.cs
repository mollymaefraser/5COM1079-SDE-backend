using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models.Models
{
    /// <summary>
    /// The join table model between <see cref="Illness"/> & <see cref="Symptom"/> 
    /// </summary>
    [PrimaryKey(nameof(IllnessRefID), nameof(SymptomRefID))]
    public class IllnessToSymptom
    {
        /// <summary>
        /// The foreign key to the illness record.
        /// </summary>
        public int IllnessRefID { get; set; }

        /// <summary>
        /// The foreign key to the symptom record.
        /// </summary>
        public int SymptomRefID { get; set; }

        /// <summary>
        /// The Illness object.
        /// </summary>
        public Illness IllnessRecord { get; set; }

        /// <summary>
        /// The symptom object.
        /// </summary>
        public Symptom SymptomRecord { get; set; }

    }
}
