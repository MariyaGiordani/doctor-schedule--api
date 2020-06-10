using APICore.Database;
using APICore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using APICore.Models.ViewModels;

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

        public IEnumerable<DoctorAppointmentViewModel> GetDoctorAppointments(string cpf)
        {
            return _context.Doctor
                .Join(
                        _context.Appointment,
                        doctor => doctor.Cpf,
                        appointment => appointment.DoctorCpf,
                        (doctor, appointment) => new
                        {
                            doctor,
                            appointment
                        })
                .Join(
                       _context.Address,
                       appointment => appointment.appointment.AddressId,
                       address => address.AddressId,
                       (appointment, address) => new
                       {
                           appointment,
                           address
                       })
                .Join(
                      _context.Patient,
                     appointment => appointment.appointment.appointment.PatientCpf,
                     patient => patient.Cpf,
                     (appointment, patient) => new
                     {
                         appointment,
                         patient
                     })
                .Where(d => d.appointment.appointment.appointment.DoctorCpf == cpf)
                .Where(d => d.appointment.appointment.appointment.Status == AppointmentStatus.Scheduled)
                .Select(x => new DoctorAppointmentViewModel
                {
                    DoctorCpf = x.appointment.appointment.appointment.DoctorCpf,
                    PatientCpf = x.appointment.appointment.appointment.PatientCpf,
                    AppointmentTime = x.appointment.appointment.appointment.AppointmentTime,
                    AppointmentEndTime = x.appointment.appointment.appointment.AppointmentEndTime,
                    PatientFirstName = x.patient.FirstName,
                    PatientLastName = x.patient.LastName,
                    Address = x.appointment.appointment.appointment.Address,
                    AppointmentId = x.appointment.appointment.appointment.AppointmentId
                })
                .ToList();
        }

        public IEnumerable<PatientAppointmentViewModel> GetPatientAppointments(string cpf)
        {
            return _context.Patient
                .Join(
                        _context.Appointment,
                        patient => patient.Cpf,
                        appointment => appointment.PatientCpf,
                        (patient, appointment) => new
                        {
                            patient,
                            appointment
                        })
                .Join(
                       _context.Address,
                       appointment => appointment.appointment.AddressId,
                       address => address.AddressId,
                       (appointment, address) => new
                       {
                           appointment,
                           address
                       })
                .Join(
                      _context.Doctor,
                     appointment => appointment.appointment.appointment.DoctorCpf,
                     doctor => doctor.Cpf,
                     (appointment, doctor) => new
                     {
                         appointment,
                         doctor
                     })
                .Where(p => p.appointment.appointment.appointment.AppointmentTime >= DateTime.Now)
                .Where(p => p.appointment.appointment.appointment.Status == AppointmentStatus.Scheduled)
                .Where(d => d.appointment.appointment.appointment.PatientCpf == cpf)
                .Select(x => new PatientAppointmentViewModel
                {
                    DoctorCpf = x.appointment.appointment.appointment.DoctorCpf,
                    PatientCpf = x.appointment.appointment.appointment.PatientCpf,
                    AppointmentTime = x.appointment.appointment.appointment.AppointmentTime,
                    AppointmentEndTime = x.appointment.appointment.appointment.AppointmentEndTime,
                    DoctorFirstName = x.doctor.FirstName,
                    DoctorLastName = x.doctor.LastName,
                    Address = x.appointment.appointment.appointment.Address,
                    AppointmentId = x.appointment.appointment.appointment.AppointmentId
                })
                .ToList();
        }
        
        public IEnumerable<Appointment> GetDoctorAppointmentsByDay(string cpf, DateTime day)
        {
            return _context.Appointment
                .Where(a => a.DoctorCpf == cpf)
                .Where(a => a.AppointmentTime.Day == day.Day)
                .Where(a => a.Status == AppointmentStatus.Scheduled)
                .Include(d => d.Doctor)
                .ToList();
        }
    }
}
        