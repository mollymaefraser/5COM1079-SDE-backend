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
    /// Schema definition for an illness record in the database.
    /// </summary>
    public class Illness
    {
        /// <summary>
        /// The unique ID for this illness record.
        /// </summary>
        [Key]
        public int IllnessID { get; set; }

        /// <summary>
        /// The name of the illness.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A brief description of the illness.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A brief set of advice/instructions for patients who may have this illness.
        /// </summary>
        public string Advice { get; set; }

        /// <summary>
        /// A list of corresponding symptoms that this illness may present.
        /// </summary>
        /// <remarks>The set up of this list allows a many-to-many relationship.</remarks>
        [ForeignKey("IllnessRefID")]
        public ICollection<IllnessToSymptom> SymptomList { get; set; } 

        /// <summary>
        /// A list representing all logs this illness appears in.
        /// </summary>
        public ICollection<UserLog> LogList { get; set; }
    }
}
