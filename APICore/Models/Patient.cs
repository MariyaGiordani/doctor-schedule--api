using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APICore.Models
{
    public class Patient
    {
        string firstName;
        string lastName;
        string cpf;

        public string Cpf
        {
            get => cpf;
            set => cpf = value.Replace(".", "").Replace("-", "");
        }
        public string FirstName {
            get => firstName;
            set => firstName = value.ToUpper(); 
        }
        public string LastName {
            get => lastName;
            set => lastName = value.ToUpper(); 
        }

        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public ICollection<Appointment> Appointments { get; set; }

        public bool PatientIsValid(ref string message, bool isValid = true) {
            if (Cpf == "") {
                message += "CPF,";
                isValid = false;
            }

            if (FirstName == "") {
                message += "First Name,";
                isValid = false;
            }

            if (LastName == "") {
                message += "Last Name,";
                isValid = false;
            }

            if (message.LastIndexOf(",") != -1) { 
                message = message.Remove(message.LastIndexOf(","));
            }

            return isValid;
        }
    }
}
