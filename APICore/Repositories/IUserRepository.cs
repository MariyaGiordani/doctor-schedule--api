using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(long id);
        void Remove(long id);
        void Update(User product);
        User Login(string userName, string password);
    }
}
