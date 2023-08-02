using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    public class History
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
        /// The illness identifier associated with this illness.
        /// </summary>
        [ForeignKey("AssociatedIllness")]
        public int PredictedDiagnosisID { get; set; }

        /// <summary>
        /// The illness record this associates with.
        /// </summary>
        public Illness AssociatedIllness { get; set; } 

    }
}
