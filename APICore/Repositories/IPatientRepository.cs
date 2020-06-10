using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IPatientRepository
    {
        void Add(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient Find(string cpf);
        void Remove(string cpf);
        void Update(Patient patient);
        bool PatientExists(string cpf);
    }
}
