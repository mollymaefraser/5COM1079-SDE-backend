using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Post
{
    public class UserCreateDto
    {
        /// <summary>
        /// The user's first name.
        /// </summary>
        [Required]
        public required string UserFirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        [Required]
        public required string UserLastName { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        [Required]
        public required string UserEmail { get; set; }

        /// <summary>
        /// The user's password
        /// </summary>
        [Required]
        public required string UserPassword { get; set; }
    }
}
