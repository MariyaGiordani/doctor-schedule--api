using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.SqlServer.Query.ExpressionTranslators.Internal;
using System.Text;

namespace APICore.Models
{
    public class User
    {        
        public int Id {get; set;}
        public string UserName {get;set;}

        public string Password {get;set;}
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        private string HashString(string value) {
            //TO-DO IMPLEMENTAR HASH DE USUÁRIO E PASSWORD            
            return value;
        }

        public bool UserIsValid(ref string message) {
            bool isValid = true;

            if (UserName == "") {
                message += "User Name,";
                isValid = false;
            }
            if (Password == "") {
                message += "Password,";
                isValid = false;
            }

            if (Doctor != null) {
                isValid = Doctor.DoctorIsValid(ref message, isValid);        
            }

            if (Patient != null) {
                isValid = Patient.PatientIsValid(ref message, isValid);
            }

            message = message.Remove(message.LastIndexOf(","));

            return isValid;
        }            
    }
}
