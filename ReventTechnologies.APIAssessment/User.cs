namespace ReventTechnologies.APIAssessment
{
    public class User
    {
        public string username { get; set; } = string.Empty;
        public byte[] PassworHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
