using JustCommerce.Shared.Services.Interfaces.JwtService;
using System;
using Xunit;

namespace Shared.UnitTests.ServicesTests
{
    public sealed class IJwtDecoderTests : IClassFixture<ServiceCollection>
    {
        private readonly ServiceCollection _Services;
        private readonly IJwtDecoder _Decoder;
        public IJwtDecoderTests(ServiceCollection service)
        {
            _Services = service;
            _Decoder = _Services.GetService<IJwtDecoder>();
        }

        [Theory]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzNTE2OCwiRW1haWwiOiJURVNUIiwiRGFzZHNhZGFzIjoiZHNhZHNhIiwiSWQiOiI3OWQ5MGU5ZC1kMGViLTQ2NTAtOGY3ZC05NGYwZjdjZGI3ZjcifQ.T5i-7-wlz4M9Lp_afgiNDFePwI-ff0HYEc_kfnMhdgnsUPKz07c_fQ5KRMzGn8zG9_gU_MxLyAxm-CBWkgoEiQ")]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzNTE2MSwiRW1haWwiOiJURVNUIiwiRGFzZHNhZGFzIjoiZHNhZHNhIiwiSWQiOiI3OWQ5MGU5ZC1kMGViLTQ2NTAtOGY3ZC05NGYwZjdjZGI3ZjcifQ.hgEErWY_BgBNgq7e45OIzHv1S0u-ZxUlELq6WzkfqYHkvjoHDdJUBHbQRsz4P7ob-4ZU9rLvheXIe6zxQ56z5g")]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzNTE0OCwiRW1haWwiOiJURVNUIiwiRGFzZHNhZGFzIjoiZHNhZHNhIiwiSWQiOiI3OWQ5MGU5ZC1kMGViLTQ2NTAtOGY3ZC05NGYwZjdjZGI3ZjcifQ.Y5D2NAMAetF19lnDE8gN2liUu1rqHxife1tdXF3fOKiqDR4voSz2PSq9WcwbF4Q6yoaiI5dQD7icKpkXGT4KpA")]
        public void Decodes_User_From_Jwt(string jwt)
        {
            var decodedUser = _Decoder.Decode(jwt);

            Assert.NotEqual(Guid.Empty, decodedUser.Id);
            Assert.NotEqual(String.Empty, decodedUser.Email);
        }
    }
}
