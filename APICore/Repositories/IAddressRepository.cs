using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IAddressRepository
    {
        void Add(Address address);
        IEnumerable<Address> GetAll();
        Address Find(int addressId, string cpf);
        void Remove(int addressId, string cpf);
        void Update(Address address);
        IEnumerable<Address> GetAddress(string cpf);
        bool AddressExists(Address address);
    }
}
