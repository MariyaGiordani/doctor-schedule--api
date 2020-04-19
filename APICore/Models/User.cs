namespace APICore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
