using System.Collections.Generic;
using APICore.Models;

namespace APICore.Repositories
{
    public interface IAppointmentRepository
    {
        void Add(Appointment appointment);
        IEnumerable<Appointment> GetAll();
        Appointment Find(int appointmentId, int addressId, string doctorCpf, string patientCpf);
        void Remove(int appointmentId);
        void Update(Appointment appointment);
        IEnumerable<Appointment> GetAppointment(int appointmentId);
        bool AppointmentExists(Appointment appointment);
        bool AppointmentExists(int appointmentId);
        IEnumerable<Appointment> GetDoctorAppointments(string cpf);
        IEnumerable<Appointment> GetPatientAppointments(string cpf);
    }
}
