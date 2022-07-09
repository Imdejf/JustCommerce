using JustCommerce.Domain.Entities.Identity;
using JustCommerce.Domain.Enums;
using JustCommerce.Shared.Enums;

namespace JustCommerce.Application.Common.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? UserName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => FirstName + " " + LastName;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string PhotoFtpPath { get; set; }
        public Guid? SelectedShopId { get; set; }
        public string ProfileType { get; set; }
        public Domain.Enums.Language Language { get; set; }
        public Theme Theme { get; set; }
        public IDictionary<string, IEnumerable<int>>? Permissions { get; set; }

        public static UserDTO CreateFromUserEntity(CMSUserEntity user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                SelectedShopId = user.SelectedShopId,
                ProfileType = user.Profile.ToString(),
                PhoneNumber = user.PhoneNumber,
                Language = user.Language,
                Theme = user.Theme,
                PhotoFtpPath = user.FtpPhotoFilePath,
            };
        }
    }
}
