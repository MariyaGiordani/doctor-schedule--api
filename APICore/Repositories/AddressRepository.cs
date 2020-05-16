using APICore.Database;
using APICore.Models;
using System.Collections.Generic;
using System.Linq;

namespace APICore.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DbConnectionProvider _context;
        public AddressRepository(DbConnectionProvider ctx) {
            _context = ctx;
        }

        public void Add(Address address) {
            _context.Address.Add(address);
            _context.SaveChanges();
        }

        public Address Find(int addressId, string cpf) {
            return _context.Address
                .Where(d => d.Cpf == cpf)
                .Where(a => a.AddressId == addressId)
                .SingleOrDefault();
        }

        public IEnumerable<Address> GetAll() {
            return _context.Address.ToList();
        }

        public void Remove(int addressId, string cpf) {
            var entity = _context.Address
                .Where(d => d.Cpf == cpf)
                .Where(d => d.AddressId == addressId)
                .Single();
            _context.Address.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Address address) {
            _context.Address.Update(address);
            _context.SaveChanges();
        }

        public IEnumerable<Address> GetAddress(string cpf) {            
            return _context.Address.Where(d => d.Cpf == cpf).ToList();
        }

        public bool AddressExists(Address address)
        {
            return _context.Address
                   .Where(a => a.AddressId == address.AddressId)
                   .Where(a => a.Cpf == address.Cpf).FirstOrDefault() != null;
        }

        public virtual bool AddressExists(int addressId)
        {
            return _context.Address
                   .Where(a => a.AddressId == addressId).FirstOrDefault() != null;
        }
    }
}
        