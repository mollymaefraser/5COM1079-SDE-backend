using Meditelligence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories.Interfaces
{
    public interface IUserRepo
    {
        /// <summary>
        /// Adds a <see cref="User"/> record to the database, based on whether the email already exists.
        /// </summary>
        /// <param name="user">The user record to add.</param>
        void CreateUser(User user);

        /// <summary>
        /// Deletes a <see cref="User"/> record from database.
        /// </summary>
        /// <param name="user">The user record to delete.</param>
        void DeleteUser(User user);

        /// <summary>
        /// Gets a individual <see cref="User"/> record based on the ID provided.
        /// </summary>
        /// <param name="id">The ID of the record to return.</param>
        /// <returns>An <see cref="User"/> record with the corresponding ID.</returns>
        User GetUserById(int id);

        /// <summary>
        /// Gets a individual <see cref="User"/> account based on the email provided.
        /// </summary>
        /// <param name="email">The email of the account to return.</param>
        /// <returns>A <see cref="User"/> record with the email.</returns>
        User GetUserByEmail(string email);

        /// <summary>
        /// Changes the password for a supplied user.
        /// </summary>
        /// <param name="userId">The userID of the record to change</param>
        /// <param name="newHashedPassword">the new password, pre-hashed.</param>
        void ChangePassword(int userId, string newHashedPassword);

        bool SaveChanges();
    }
}
