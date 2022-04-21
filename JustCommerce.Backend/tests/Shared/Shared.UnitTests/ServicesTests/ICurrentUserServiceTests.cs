using JustCommerce.Shared.Models;
using JustCommerce.Shared.Services.Interfaces;
using Xunit;

namespace Shared.UnitTests.ServicesTests
{
    public sealed class ICurrentUserServiceTests : IClassFixture<ServiceCollection>
    {
        private readonly ServiceCollection _Services;
        private readonly ICurrentUserService _CurrentUserService;
        public ICurrentUserServiceTests(ServiceCollection services)
        {
            _Services = services;
            _CurrentUserService = _Services.GetService<ICurrentUserService>();
        }

        [Fact]
        public void CurrentUser_Is_Not_Null_After_Initialize()
        {
            Assert.NotNull(_CurrentUserService.CurrentUser);
        }

        [Fact]
        public void CurrentUser_Changes_After_SetCurrentUserCall_With_Claims()
        {
            var prevUser = _CurrentUserService.CurrentUser;

            _CurrentUserService.SetCurrentUser(new JwtClaims
            {
                Email = "NEWTESTMAIL@gmail.com",
                Id = System.Guid.NewGuid()
            });

            Assert.NotEqual(prevUser.Email, _CurrentUserService.CurrentUser.Email);
            Assert.NotEqual(prevUser.Id, _CurrentUserService.CurrentUser.Id);
        }

        [Fact]
        public void CurrentUser_Dont_Changes_After_SetCurrentUserCall_With_Invalid_Jwt()
        {
            var prevUser = _CurrentUserService.CurrentUser;

            _CurrentUserService.SetCurrentUser(_Services.InvalidJwt);

            Assert.Equal(prevUser.Email, _CurrentUserService.CurrentUser.Email);
            Assert.Equal(prevUser.Id, _CurrentUserService.CurrentUser.Id);
        }

        [Fact]

        public void CurrentUser_Changes_After_SetCurrentUserCall_With_Valid_Jwt()
        {
            var prevUser = _CurrentUserService.CurrentUser;

            _CurrentUserService.SetCurrentUser(_Services.ValidJwt);

            Assert.NotEqual(prevUser.Email, _CurrentUserService.CurrentUser.Email);
            Assert.NotEqual(prevUser.Id, _CurrentUserService.CurrentUser.Id);
        }
    }
}
