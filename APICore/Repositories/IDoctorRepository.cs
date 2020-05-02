using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IDoctorRepository
    {
        void Add(Doctor doctor);
        IEnumerable<Doctor> GetAll();
        Doctor Find(string cpf);
        void Remove(string cpf);
        void Update(Doctor doctor);
        IEnumerable<Doctor> GetDoctor(string speciality, string firstName, string lastName);
        }
}
