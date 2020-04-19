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
    }
}
