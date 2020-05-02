using System.Collections.Generic;
using System.Linq;
using APICore.Database;
using APICore.Models;
using Microsoft.EntityFrameworkCore;

namespace APICore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbConnectionProvider _context;
        public UserRepository(DbConnectionProvider ctx)
        {
            _context = ctx;
        }
        public void Add(User user)
        {
            user.Password = user.HashStringPassword(user.Password);
            _context.User.Add(user);            
            _context.SaveChanges();
        }

        public User Find(long id)
        {
            return _context.User.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.User.First(p => p.Id == id);
            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public User Login(string userName, string password) {
            return _context.User
                  .Where(p => p.UserName == userName && p.Password == password)
                  .Include(p => p.Doctor)
                  .Include(p => p.Patient)
                  .FirstOrDefault();
        }

        public User FindByUser(User user) {
            IQueryable<User> result = _context.User.AsQueryable();
            return result.Where(u => u.UserName == user.UserName).FirstOrDefault();
        }

        public long FindByUserLong(User user) {
            IQueryable<User> result = _context.User.AsQueryable();
            return result.Where(u => u.UserName == user.UserName).Select(u => u.Id).FirstOrDefault();
        }
    }
}
