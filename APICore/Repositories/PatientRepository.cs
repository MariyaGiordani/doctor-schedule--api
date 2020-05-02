using APICore.Database;
using APICore.Models;
using System.Collections.Generic;
using System.Linq;


namespace APICore.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DbConnectionProvider _context;
        public PatientRepository(DbConnectionProvider ctx) {
            _context = ctx;
        }

        public void Add(Patient patient) {
            _context.Patient.Add(patient);
            _context.SaveChanges();
        }

        public Patient Find(string cpf) {
            return _context.Patient.FirstOrDefault(p => p.Cpf == cpf);
        }

        public IEnumerable<Patient> GetAll() {
            return _context.Patient.ToList();
        }

        public void Remove(string cpf) {
            var entity = _context.Patient.First(p => p.Cpf == cpf);
            _context.Patient.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Patient patient) {
            _context.Patient.Update(patient);
            _context.SaveChanges();
        }
    }
}
