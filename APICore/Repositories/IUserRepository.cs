using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.Model;

namespace APICore.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(long id);
        void Remove(long id);
        void Update(User product);
    }
}
