using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    public class UserLog
    {
        /// <summary>
        /// The unique identifier of this record.
        /// </summary>
        [Key]
        public int LogID { get; set; }

        /// <summary>
        /// The date this record was created.
        /// </summary>
        public DateTime LogDate { get; set; }

        /// <summary>
        /// The UserID this log belongs to.
        /// </summary>
        [ForeignKey(nameof(AssociatedUser))]
        public int UserID { get; set; }

        /// <summary>
        /// The user record that this log belongs to.
        /// </summary>
        public User AssociatedUser { get; set; }

        /// <summary>
        /// The illness identifier associated with this illness.
        /// </summary>
        [ForeignKey("AssociatedIllness")]
        public int PredictedDiagnosisID { get; set; }

        /// <summary>
        /// The illness record this associates with.
        /// </summary>
        public Illness AssociatedIllness { get; set; } 

        /// <summary>
        /// The collection of <see cref="UserLogSymptom"/> records, that will join to <see cref="Symptom"/> records.
        /// </summary>
        public ICollection<UserLogSymptom> UserLogSymptoms { get; set; }
    }
}
