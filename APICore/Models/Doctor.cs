namespace APICore.Models
{
    public class Doctor {
        public long Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Crm { get; set; }
        public string Speciality { get; set; }
        public int Id { get; set; }
        public User User { get; set; }

        public bool DoctorIsValid(ref string message, bool isValid = true) {            
            if (Cpf == 0) {
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

            if (Email == "") {
                message += "E-mail,";
                isValid = false;
            }

            if (Crm == 0) {
                message += "CRM,";
                isValid = false;
            }

            if (Speciality == "") {
                message += "Speciality";
                isValid = false;
            }

            message = message.Remove(message.LastIndexOf(","));

            return isValid;
        }
    }
}
