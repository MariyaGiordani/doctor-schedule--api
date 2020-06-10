using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IAddressRepository
    {
        void Add(Address address);
        IEnumerable<Address> GetAll();
        Address Find(int addressId, string cpf, bool listarEnderecosDesativados = false);
        void Remove(int addressId);
        void Update(Address address);
        IEnumerable<Address> GetAddress(string cpf);
        bool AddressExists(Address address);
        bool AddressExists(int addressId);
    }
}
