using System;
using System.Collections;

namespace APICore.Models.ViewModels
{
    public class PatientAppointmentViewModel
    {
        public string DoctorCpf { get; set; }
        public string PatientCpf { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public Address Address { get; set; }
    }
}
