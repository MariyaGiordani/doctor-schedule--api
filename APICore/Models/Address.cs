using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICore.Models
{
    public enum AddressAction
    {
        Add = 1,
        Update = 2,
        Remove = 3
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string RoadType { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string UF { get; set; }
        public string Information { get; set; }
        [JsonIgnore]
        public Doctor Doctor { get; set; }
        public string Cpf { get; set; }
        [NotMapped]
        public AddressAction AddressAction { get; set; }

        public bool AddressIsValid(ref string message, bool isValid = true)
        {
            if (RoadType == "")
            {
                message += "Road Type,";
                isValid = false;
            }

            if (Street == "")
            {
                message += "Street,";
                isValid = false;
            }

            if (Number == 0)
            {
                message += "Number,";
                isValid = false;
            }

            if (Neighborhood == "")
            {
                message += "Neighborhood,";
                isValid = false;
            }

            if (PostalCode == "")
            {
                message += "Postal Code";
                isValid = false;
            }

            if (City == "")
            {
                message += "City";
                isValid = false;
            }

            if (UF == "")
            {
                message += "UF";
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
