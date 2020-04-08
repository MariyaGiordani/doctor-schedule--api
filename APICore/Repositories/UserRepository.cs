using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Database;
using APICore.Model;

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
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public User Find(long id)
        {
            return _context.User.FirstOrDefault(p => p.ID == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public void Remove(long id)
        {
            var entity = _context.User.First(p => p.ID == id);
            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }
    }
}
