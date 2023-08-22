using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public interface IUserRepo
    {
        /// <summary>
        /// Gets all <see cref="User"/> records from the DbContext. 
        /// </summary>
        /// <returns>A list of Users from the database.</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Adds a <see cref="User"/> record to the database.
        /// </summary>
        /// <param name="user">The user record to add.</param>
        void CreateUser(User user);

        /// <summary>
        /// Gets a individual <see cref="User"/> record based on the ID provided.
        /// </summary>
        /// <param name="id">The ID of the record to return.</param>
        /// <returns>An <see cref="User"/> record with the corresponding ID.</returns>
        User GetUserById(int id);

        bool SaveChanges();
    }
}
