using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    /// <summary>
    /// A DTO to hold information relating to changing a password.
    /// </summary>
    public class ChangePasswordDto
    {
        /// <summary>
        /// Gets or sets the user ID for which user password to change.
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Gets or sets the new password to change.
        /// </summary>
        public string NewPassword { get; set; }
    }
}
