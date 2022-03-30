namespace E_Commerce.Shared.Models
{
    public class ApplicationUserJwtClaims
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsProfilePrivate { get; set; }
        public int RegisterSource { get; set; }
        public int ProfileType { get; set; }
    }
}
