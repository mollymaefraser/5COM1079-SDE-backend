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
        /// Adds a <see cref="User"/> record to the database.
        /// </summary>
        /// <param name="user">The user record to add.</param>
        IEnumerable<User> CreateUser();

        bool UserLogIn(bool isAdmin);

        /// <summary>
        /// Deletes a <see cref="User"/> record from database.
        /// </summary>
        IEnumerable<User> DeleteUser();

        /// <summary>
        /// Gets a individual <see cref="User"/> record based on the ID provided.
        /// </summary>
        /// <param name="id">The ID of the record to return.</param>
        /// <returns>An <see cref="User"/> record with the corresponding ID.</returns>
        User GetUserById(int id);

        /// <summary>
        /// Gets a individual <see cref="User"/> account based on the email and password provided.
        /// </summary>
        /// <param name="email">The email of the account to return.</param>
        /// <param name="password">The password of the account to return.</param>
        /// <returns>An <see cref="User"/> account with the corresponding email and password.</returns>
        User GetUserByEmailAndPassword(string email, string password);

        bool SaveChanges();
    }
}
