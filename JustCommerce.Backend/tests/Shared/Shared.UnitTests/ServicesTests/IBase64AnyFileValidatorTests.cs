using JustCommerce.Shared.Services.Interfaces.Base64FileValidator;
using Xunit;

namespace Shared.UnitTests.ServicesTests
{
    public sealed class IBase64AnyFileValidatorTests : IClassFixture<ServiceCollection>
    {
        private readonly IBase64AnyFileValidator _AnyFileValidator;
        private readonly ServiceCollection _Services;
        public IBase64AnyFileValidatorTests(ServiceCollection services)
        {
            _Services = services;
            _AnyFileValidator = _Services.GetService<IBase64AnyFileValidator>();
        }

        [Fact]
        public void If_File_Has_Not_Requested_Extensions_Returns_False()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithExtension(".txt", ".md").IsValid(out string[] errors);

            Assert.False(result);
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void If_File_Has_Requested_Extensions_Returns_True()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithExtension(".png", ".jpg").IsValid(out string[] errors);

            Assert.True(result);
            Assert.Empty(errors);
        }

        [Fact]
        public void If_File_Has_NotRequested_Extensions_Returns_False()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithoutExtension(".png", ".jpg").IsValid(out string[] errors);

            Assert.False(result);
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void If_File_Has_Not_NotRequested_Extensions_Returns_False()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.TxtBase64File)).WithoutExtension(".png", ".jpg").IsValid(out string[] errors);

            Assert.True(result);
            Assert.Empty(errors);
        }

        [Fact]
        public void If_File_If_File_Is_Bigger_Then_MinFileSize_Returns_True()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithMinFileSize(0.00000000000000001).IsValid(out string[] errors);

            Assert.True(result);
            Assert.Empty(errors);
        }

        [Fact]
        public void If_File_If_File_Is_Smaller_Then_MinFileSize_Returns_False()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithMinFileSize(10100000000).IsValid(out string[] errors);

            Assert.False(result);
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void If_File_If_File_Is_Smaller_Then_MaxFileSize_Returns_True()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithMaxFileSize(10100000000).IsValid(out string[] errors);

            Assert.True(result);
            Assert.Empty(errors);
        }

        [Fact]
        public void If_File_If_File_Is_Bigger_Then_MaxFileSize_Returns_False()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithMaxFileSize(0.00000000000000001).IsValid(out string[] errors);

            Assert.False(result);
            Assert.NotEmpty(errors);
        }

        [Fact]
        public void If_More_Than_One_Error_Occures_Out_Returns_More_Than_One_Error()
        {
            var result = _AnyFileValidator.OnFile(new(_Services.PngBase64File)).WithExtension(".txt").WithMaxFileSize(0.00000000000000001).IsValid(out string[] errors);

            Assert.False(result);
            Assert.NotEmpty(errors);
            Assert.Equal(2, errors.Length);
        }
    }
}
