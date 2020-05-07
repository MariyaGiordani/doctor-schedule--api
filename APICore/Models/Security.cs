namespace APICore.Models
{
    public class Security
    {
        public byte[] SaltPassword { get; set; }
        public int Id { get; set; }
        public User User { get; set; }
    }
}
