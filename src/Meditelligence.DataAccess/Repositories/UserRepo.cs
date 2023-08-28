using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Repositories.Interfaces;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meditelligence.DataAccess.Repositories
{
    public class UserRepo :IUserRepo
    {
        private readonly MeditelligenceDBContext _context;

        public UserRepo(MeditelligenceDBContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public void CreateUser(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
            // if email exists in database, not a unique record, throw error.
            if (_context.Users.Any(u => u.Email == user.Email.ToLower()))
            {
                throw new ArgumentException("Email is already used, please enter another.");
            }

            _context.Users.Add(user);
        }

        /// <inheritdoc/>
        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        /// <inheritdoc/>
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(i => i.UserID == id);
        }
        
        /// <inheritdoc/>
        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(i => i.Email == email);
        }

        /// <inheritdoc/>
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
