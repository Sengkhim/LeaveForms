namespace Application.Config
{
    public class MailConfiguration
    {
        public string? From { get; set; } //= "khimup.ads@gmail.com";
        public string? Host { get; set; } //= "smtp.gmail.com";
        public int Port { get; set; } //= 587;
        public string? UserName { get; set; } //= "Khim Khim";
        public string? Password { get; set; }// = "Khimup.ads@gmail";
        public string? DisplayName { get; set; } //= "sengkhim BoyLoy";
    }
}
