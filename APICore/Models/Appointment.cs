using System;
using System.Text.Json.Serialization;

namespace APICore.Models
{
    public enum AppointmentStatus
    {
        Scheduled = 1,
        Rescheduled = 2,
        Canceled = 3
    }
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }                        
        public AppointmentStatus Status { get; set; }
        public int RescheludedAppointmentId { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
        public string DoctorCpf { get; set; }
        [JsonIgnore]
        public Patient Patient { get; set; }
        public string PatientCpf { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public DateTime AppointmentEndTime { get; set; }
        public bool AppointmentIsValid(ref string message, bool isValid = true)
        {
            if (AppointmentTime == null)
            {
                message += "Appointment Time,";
                isValid = false;
            }

            if (Status == 0)
            {
                message += "Status,";
                isValid = false;
            }            

            if (message.LastIndexOf(",") != -1)
            {
                message = message.Remove(message.LastIndexOf(","));
            }

            return isValid;
        }
    }
}
