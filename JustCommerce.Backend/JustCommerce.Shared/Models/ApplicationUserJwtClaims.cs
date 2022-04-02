namespace JustCommerce.Shared.Models
{
    public class ApplicationUserJwtClaims
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public int RegisterSource { get; set; }
    }
}
