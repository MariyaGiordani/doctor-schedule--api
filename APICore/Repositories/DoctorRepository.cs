using APICore.Database;
using APICore.Models;
using System.Collections.Generic;
using System.Linq;

namespace APICore.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DbConnectionProvider _context;
        public DoctorRepository(DbConnectionProvider ctx) {
            _context = ctx;
        }

        public void Add(Doctor doctor) {
            _context.Doctor.Add(doctor);
            _context.SaveChanges();
        }

        public Doctor Find(long cpf) {
            return _context.Doctor.FirstOrDefault(d => d.Cpf == cpf);
        }

        public IEnumerable<Doctor> GetAll() {
            return _context.Doctor.ToList();
        }

        public void Remove(long cpf) {
            var entity = _context.Doctor.First(d => d.Cpf == cpf);
            _context.Doctor.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor) {
            _context.Doctor.Update(doctor);
            _context.SaveChanges();
        }
    }
}
        