
using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    interface IPatientRepository
    {
        void Add(Patient patient);
        IEnumerable<Patient> GetAll();
        Patient Find(long cpf);
        void Remove(long cpf);
        void Update(Patient patient);
    }
}
