using APICore.Database;
using APICore.Models;
using System.Collections.Generic;
using System.Linq;

namespace APICore.Repositories
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly DbConnectionProvider _context;
        public TimeSheetRepository(DbConnectionProvider ctx) {
            _context = ctx;
        }

        public void Add(TimeSheet timeSheet)
        {
            _context.TimeSheet.Add(timeSheet);
            _context.SaveChanges();
        }

        public TimeSheet Find(int timeSheetId, string cpf, int addressId) {
            return _context.TimeSheet
                .Where(d => d.Cpf == cpf)
                .Where(a => a.AddressId == addressId)
                .Where(t => t.TimeSheetId == timeSheetId)
                .Single();
        }

        public virtual TimeSheet Find(string cpf, int addressId)
        {
            return _context.TimeSheet
                .Where(d => d.Cpf == cpf)
                .Where(a => a.AddressId == addressId)                
                .SingleOrDefault();
        }

        public IEnumerable<TimeSheet> GetAll(int addressId, string cpf) {
            return _context.TimeSheet
                .Where(t => t.AddressId == addressId)
                .Where(t =>t.Cpf == cpf)
                .ToList();
        }

        public void Remove(int timeSheetId, int addressId, string cpf) {
            var entity = _context.TimeSheet
                .Where(d => d.Cpf == cpf)
                .Where(d => d.AddressId == addressId)
                .Where(t => t.TimeSheetId == timeSheetId)
                .Single();
            _context.TimeSheet.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TimeSheet timeSheet) {
            _context.TimeSheet.Update(timeSheet);
            _context.SaveChanges();
        }

        public IEnumerable<TimeSheet> GetTimeSheet(string cpf) {            
            return _context.TimeSheet.Where(d => d.Cpf == cpf).ToList();
        }

        public bool TimeSheetExists(TimeSheet timeSheet)
        {
            return _context.TimeSheet
                   .Where(a => a.AddressId == timeSheet.AddressId)
                   .Where(a => a.TimeSheetId == timeSheet.TimeSheetId)
                   .Where(a => a.Cpf == timeSheet.Cpf)
                   .FirstOrDefault() != null;
        }
    }
}
        