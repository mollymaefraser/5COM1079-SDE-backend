using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.Models
{
    public class User
    {
        /// <summary>
        /// The unique ID of the record.
        /// </summary>
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The email of the selected user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A password, hashed for security.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// A value to determine if the user has admin privileges.
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// A collection of all associated logs with this user.
        /// </summary>
        [ForeignKey("LogID")]
        public ICollection<History> Logs { get; set; }
    }
}
