using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DTOs.Read
{
    public class UserReadDto
    {
        /// <summary>
        /// The user's first name.
        /// </summary>
        public string UserFirstName { get; set; }

        /// <summary>
        /// The user's last name.
        /// </summary>
        public string UserLastName { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// If thr user has admin privileges
        /// </summary>
        public bool IsUserAdmin { get; set; }

        //History is not yet included and needs to be reviewed
    }
}
