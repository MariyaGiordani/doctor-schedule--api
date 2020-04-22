namespace APICore.Models
{
    public class Patient
    {
        public long Cpf { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public User User { get; set; }

        public bool PatientIsValid(ref string message, bool isValid = true) {
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
                message += "E-mail";
                isValid = false;
            }

            message = message.Remove(message.LastIndexOf(","));

            return isValid;
        }
    }
}
