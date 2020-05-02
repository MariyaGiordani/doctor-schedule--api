using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace APICore.Models
{
    public class User
    {
        string password;

        public int Id {get; set;}
        public string UserName {get; set;}
        public string Password { get; set; }        
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        [JsonIgnore]
        public Security Security { get; set; }       

        public User() {
            Security = new Security();    
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

            if (message.LastIndexOf(",") != -1) { 
                message = message.Remove(message.LastIndexOf(","));
            }

            return isValid;
        }

        public string HashStringPassword(string password) {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }

            Security.SaltPassword = salt;

            return HashString(password, salt);
        }

        public string HashString(string value, byte[] salt) {
            value = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 512 / 8
            ));
                
            return value;
        }

        public string ReturnHash(string value, byte[] salt) {
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: value,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 512 / 8
            ));

            return hash;
        }
    }
}
