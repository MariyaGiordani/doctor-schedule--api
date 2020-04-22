using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IDoctorRepository
    {
        void Add(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        Doctor Find(long cpf);
        void Remove(long cpf);
        void Update(Doctor doctor);
        IEnumerable<Doctor> GetDoctor(string speciality, string firstName, string lastName);
        }
}
