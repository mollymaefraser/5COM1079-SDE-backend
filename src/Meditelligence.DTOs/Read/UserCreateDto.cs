using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    public class UserCreateDto
    {
        /// <summary>
        /// The user's first name.
        /// </summary>
        public required string UserFirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public required string UserLastName { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        public required string UserEmail { get; set; }

        /// <summary>
        /// The user's password
        /// </summary>
        public required string UserPassword { get; set; }
    }
}
