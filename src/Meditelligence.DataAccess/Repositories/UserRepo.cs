using Meditelligence.DataAccess.Context;
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

        public void CreateUser(User user, string email)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var item = _context.Users.Find(email);
            if (item.ToString() == user.Email)
            {
                throw new ArgumentException("Email already exisits", nameof(email));
            }
            _context.Users.Add(user);
        }

        public IEnumerable<User> DeleteUser()
        {
            User user = new User();
            _context.Users.Attach(user);
            return (IEnumerable<User>)_context.Users.Remove(user);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(i => i.UserID == id);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(i => i.Email == email && i.Password == password);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
