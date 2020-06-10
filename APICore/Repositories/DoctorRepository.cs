using APICore.Database;
using APICore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public Doctor Find(string cpf) {
            return _context.Doctor.FirstOrDefault(d => d.Cpf == cpf);
        }

        public IEnumerable<Doctor> GetAll() {
            return _context.Doctor.ToList();
        }

        public void Remove(string cpf) {
            var entity = _context.Doctor.First(d => d.Cpf == cpf);
            _context.Doctor.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor) {
            _context.Doctor.Update(doctor);
            _context.SaveChanges();
        }

        public IEnumerable<Doctor> GetDoctor(string speciality, string firstName, string lastName, string neighborhood) {
            var result = _context.Doctor.AsQueryable();

            if ((speciality != null) && (speciality != "NENHUMA")){
                result = result.Where(d => d.Speciality == speciality);
            }

            if (firstName != null) {
                result = result.Where(d => d.FirstName.Contains(firstName));
            }

            if (lastName != null) {
                result = result.Where(d => d.LastName.Contains(lastName));
            }

            if (neighborhood != null)
            {
                result = result.Where(d => d.Addresses.Any(n => n.Neighborhood == neighborhood));
            }
            
            result = result.Include(d => d.Addresses);
            result = result.Where(d => d.Addresses != null);
            result = result.Where(d => d.Addresses.Any(a => a.Status == AddressStatus.Active));
            result = result.Include(d => d.TimeSheets).ThenInclude(d => d.DaysOfTheWeeks);

            return result.ToList();
        }

        public bool DoctorExists(string cpf)
        {
            return _context.Doctor.FirstOrDefault(d => d.Cpf == cpf) != null;
        }
    }
}
        