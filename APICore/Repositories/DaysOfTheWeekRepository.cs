using APICore.Database;
using APICore.Models;
using System.Collections.Generic;
using System.Linq;

namespace APICore.Repositories
{
    public class DaysOfTheWeekRepository : IDaysOfTheWeekRepository
    {
        private readonly DbConnectionProvider _context;
        public DaysOfTheWeekRepository(DbConnectionProvider ctx) {
            _context = ctx;
        }

        public void Add(DaysOfTheWeek daysOfTheWeek) {
            _context.DaysOfTheWeek.Add(daysOfTheWeek);
            _context.SaveChanges();
        }

        public DaysOfTheWeek Find(int daysId, int timeSheetId) {
            return _context.DaysOfTheWeek
                .Where(d => d.Id == daysId)
                .Where(a => a.TimeSheetId == timeSheetId)
                .SingleOrDefault();
        }

        public IEnumerable<DaysOfTheWeek> GetAll() {
            return _context.DaysOfTheWeek.ToList();
        }

        public void Remove(int daysId, int timeSheetId) {
            var entity = _context.DaysOfTheWeek
                .Where(d => d.Id == daysId)
                .Where(d => d.TimeSheetId == timeSheetId)
                .Single();
            _context.DaysOfTheWeek.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(DaysOfTheWeek daysOfTheWeek) {
            _context.DaysOfTheWeek.Update(daysOfTheWeek);
            _context.SaveChanges();
        }

        public IEnumerable<DaysOfTheWeek> GetDaysOfTheWeek(int timeSheetId) {            
            return _context.DaysOfTheWeek.Where(d => d.Id == timeSheetId).ToList();
        }

        //public bool AddressExists(Address address)
        //{
        //    return _context.Address
        //           .Where(a => a.AddressId == address.AddressId)
        //           .Where(a => a.Cpf == address.Cpf).FirstOrDefault() != null;
        //}

        //public virtual bool AddressExists(int addressId)
        //{
        //    return _context.Address
        //           .Where(a => a.AddressId == addressId).FirstOrDefault() != null;
        //}
    }
}
        