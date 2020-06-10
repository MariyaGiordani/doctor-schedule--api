using System;
using System.Collections.Generic;

namespace APICore.Models.ViewModels
{
    public class DoctorAppointmentViewModel
    {        
        public string DoctorCpf { get; set; }
        public string PatientCpf { get; set; }
        public DateTime AppointmentTime { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public Address Address { get; set; }
        public int AppointmentId { get; set; }        
    }
}
