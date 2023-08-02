using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    [PrimaryKey(nameof(RefLogID), nameof(RefSymptomID))]
    public class HistorySymptom
    {
        /// <summary>
        /// The reference LogID this record joins.
        /// </summary>
        [ForeignKey("RefLog")]
        public int RefLogID { get; set; }

        /// <summary>
        /// The reference SymptomID this record joins.
        /// </summary>
        [ForeignKey("RefSymptom")]
        public int RefSymptomID { get; set; }

        /// <summary>
        /// The reference Log record this join table links to.
        /// </summary>
        public History RefLog { get; set; }

        /// <summary>
        /// The reference symptom record this join table links to.
        /// </summary>
        public Symptom RefSymptom { get; set; }


    }
}
