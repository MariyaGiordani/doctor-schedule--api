using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface ISecurityRepository
    {
        void Add(Security security);
        IEnumerable<Security> GetAll();
        byte[] Find(long id);
        void Remove(long id);
        void Update(Security security);
    }
}
