using System.Text.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;

namespace APICore.Models
{
    public class TimeSheet
    {
        public int TimeSheetId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LunchStartDate { get; set; }
        public DateTime LunchEndDate { get; set; }
        public DateTime AppointmentDuration { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
        public string Cpf { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public DateTime AppointmentCancelTime { get; set; }
        public ICollection<DaysOfTheWeek> DaysOfTheWeeks { get; set; }

        public bool TimeSheetIsValid(ref string message, bool isValid = true)
        {
            if (StartDate == null)
            {
                message += "Start Date,";
                isValid = false;
            }

            if (EndDate == null)
            {
                message += "End Date,";
                isValid = false;
            }

            if (LunchStartDate == null)
            {
                message += "Lunch StartDate,";
                isValid = false;
            }

            if (LunchEndDate == null)
            {
                message += "Neighborhood,";
                isValid = false;
            }

            if (AppointmentDuration == null)
            {
                message += "Appointment Duration";
                isValid = false;
            }

            if (Cpf == "")
            {
                message += "CPF";
                isValid = false;
            }

            if (AddressId == 0)
            {
                message += "Address Id";
                isValid = false;
            }

            if (AppointmentCancelTime == null)
            {
                message += "Appointment Cancel Time";
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
