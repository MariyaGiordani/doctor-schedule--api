using APICore.Database;
using APICore.Models;
using System.Collections.Generic;
using System.Linq;

namespace APICore.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DbConnectionProvider _context;
        public AppointmentRepository(DbConnectionProvider ctx) {
            _context = ctx;
        }

        public void Add(Appointment appointment) {
            _context.Appointment.Add(appointment);
            _context.SaveChanges();
        }

        public Appointment Find(int appointmentId, int addressId, string doctorCpf, string patientCpf) {
            return _context.Appointment
                .Where(d => d.AppointmentId == appointmentId)
                .Where(a => a.AddressId == addressId)
                .Where(m => m.DoctorCpf == doctorCpf)
                .Where(p => p.PatientCpf == patientCpf)
                .SingleOrDefault();
        }

        public IEnumerable<Appointment> GetAll() {
            return _context.Appointment.ToList();
        }

        public void Remove(int appointmentId) {
            var entity = _context.Appointment                
                .Where(d => d.AppointmentId == appointmentId)
                .SingleOrDefault();
            _context.Appointment.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Appointment appointment) {
            _context.Appointment.Update(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAppointment(int appointmentId) {            
            return _context.Appointment.Where(d => d.AppointmentId == appointmentId).ToList();
        }

        public bool AppointmentExists(Appointment appointment)
        {
            return _context.Appointment
                   .Where(a => a.AddressId == appointment.AddressId)
                   .Where(a => a.DoctorCpf == appointment.DoctorCpf)
                   .Where(a => a.PatientCpf == appointment.PatientCpf)
                   .FirstOrDefault() != null;
        }

        public virtual bool AppointmentExists(int appointmentId)
        {
            return _context.Appointment
                   .Where(a => a.AppointmentId == appointmentId).FirstOrDefault() != null;
        }

        public IEnumerable<Appointment> GetDoctorAppointments(string cpf)
        {
            return _context.Appointment
                .Where(a => a.DoctorCpf == cpf)
                .ToList();
        }

        public IEnumerable<Appointment> GetPatientAppointments(string cpf)
        {
            return _context.Appointment
                .Where(a => a.PatientCpf == cpf)                
                .ToList();
        }
    }
}
        