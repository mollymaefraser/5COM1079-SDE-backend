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
    /// Schema definition for a symptom record in the database.
    /// </summary>
    public class Symptom
    {
        /// <summary>
        /// The unique identifier for this symptom
        /// </summary>
        [Key]
        public int SymptomID { get; set; }

        /// <summary>
        /// The name of the symptom.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A short description of the symptom.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// A corresponding list of illnesses that this symptom may exhibit in.
        /// </summary>
        /// <remarks>The set up of this list allows a many-to-many relationship.</remarks>
        [ForeignKey("SymptomRefID")]
        public ICollection<IllnessToSymptom> IllnessList { get; set; }

        /// <summary>
        /// A corresponding list of log that associate with this record.
        /// </summary>
        public ICollection<HistorySymptom> HistorySymptoms { get; set; }

    }
}
