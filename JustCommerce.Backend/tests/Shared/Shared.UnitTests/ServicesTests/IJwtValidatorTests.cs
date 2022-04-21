using JustCommerce.Shared.Services.Interfaces.JwtService;
using Xunit;

namespace Shared.UnitTests.ServicesTests
{
    public sealed class IJwtValidatorTests : IClassFixture<ServiceCollection>
    {
        private readonly ServiceCollection _Services;
        public IJwtValidatorTests(ServiceCollection service)
        {
            _Services = service;
        }

        [Theory]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzNTQ1NiwiRW1haWwiOiJURVNUIiwiRG9taW5payI6IiIsIkRhc2RzYWRhcyI6ImRzYWRzYSIsIklkIjoiNzlkOTBlOWQtZDBlYi00NjUwLThmN2QtOTRmMGY3Y2RiN2Y3In0.fwGBvt3LxTbMwS1oZPY4uEDLEo8coxtJp43x8niT32V8kOYU9ybpTqX5T3IE3y0ZoMmaFCr2EK2XcQZ7qPeOSA")]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzNTQ3MSwiRW1haWwiOiJURVNUIiwiRG9taW5payI6IiIsIkRhc2RzYWRhcyI6ImRzYWRzYSIsIklkIjoiNzlkOTBlOWQtZDBlYi00NjUwLThmN2QtOTRmMGY3Y2RiN2Y3In0.YvRBjrPlHKJbktXSEu1_J9YT9kUZc-jQCx81y_9AxV2IFkd0YKRWWsJuRDPAsWw8KhaDpltcCQXnKoaSC4b6mA")]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzNTQ0NywiRW1haWwiOiJURVNUIiwiRG9taW5payI6IiIsIkRhc2RzYWRhcyI6ImRzYWRzYSIsIklkIjoiNzlkOTBlOWQtZDBlYi00NjUwLThmN2QtOTRmMGY3Y2RiN2Y3In0.i4M8Obmrn95sj4NSSmk5W0psLgto6-74w4v20tpSf2BL6DKZR0fqqR64GdtLBcqHtjoHqHk458vNEn9yBEDWww")]
        public void Returns_True_For_Valid_Jwt(string jwt)
        {
            Assert.True(_Services.GetService<IJwtValidator>().IsValid(jwt));
        }

        [Fact]
        public void Returns_False_For_Valid_But_Expired_Jwt()
        {
            Assert.False(_Services.GetService<IJwtValidator>().IsValid(_Services.ExpiredValidJwt));
        }

        [Theory]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyasInN1YiI6IiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzMzcwNiwiZXhwIjoxNjM3MTMzNzY2LCJFbWFpbCI6IlRFU1QiLCJEYXNkc2FkYXMiOiJkc2Fkc2EiLCJJZCI6Ijc5ZDkwZTlkLWQwZWItNDY1MC04ZjdkLTk0ZjBmN2NkYjdmNyJ9.a61efq4oIBluHoYAGyhb6xKCg14ECQg06pJMP9-CNBrYSApbwVr0XQq5Ij8-6Zcnta6IAuXGVV4sqnXgf52-PA")]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6ImV2YW5kZXIiLCJhdWQiOiJhbm5hIiwiaWF0IjfxNjM3MTMzNjU1LCJleHAiOjE2MzcxMzM3MTUsIkVtYWlsIjoiVEVTVCIsIkRvbWluaWsiOiJKQUpBIiwiRGFzZHNhZGFzIjoiZHNhZHNhIiwiSWQiOiI3OWQ5MGU5ZC1kMGViLTQ2NTAtOGY3ZC05NGYwZjdjZGI3ZjcifQ.PK0qub_CYJS0im4E_CCc3sMWEPFic0Xv64SBy5Qsr5dz-bGU3p9rmIwHFM1gc37g2jxf4LoOrrAnUoT4zFznWw")]
        [InlineData("eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsInZlcnNpb24iOiI1cjBmcGw2cGszdjdibWVkYjZwdGNyIn0.eyJpc3MiOiJEaW5vQ2hpZXNhLmdpdGh1Yi5pbyIsInN1YiI6fiIsImF1ZCI6IiIsImlhdCI6MTYzNzEzMzY4MCwiZXhwIjoxNjM3MTMzNzQwLCJFbWFpbCI6IlRFU1QiLCJEb21pbmlrIjoiIiwiRGFzZHNhZGFzIjoiZHNhZHNhIiwiSWQiOiI3OWQ5MGU5ZC1kMGViLTQ2NTAtOGY3ZC05NGYwZjdjZGI3ZjcifQ.Hg7ZXbUHNvJHPLUmNbjtdn8jGQMEMCeA2_Qszb_62ganpcjehJ5lmJhuQu6Vib-Y9B_Rk0qLnWAVwvqqOhGN4g")]
        public void Returns_False_For_Invalid_Jwt(string jwt)
        {
            Assert.False(_Services.GetService<IJwtValidator>().IsValid(jwt));
        }
    }
}
