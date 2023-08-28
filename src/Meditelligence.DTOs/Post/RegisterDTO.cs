using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    public class RegisterDTO
    {
        /// <summary>
        /// Gets or sets the email to send.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password to send.
        /// </summary>
        public string Password { get; set; }
    }
}
