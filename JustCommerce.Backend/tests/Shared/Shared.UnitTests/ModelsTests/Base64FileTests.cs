using JustCommerce.Shared.Exceptions;
using JustCommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Shared.UnitTests.ModelsTests
{
    public sealed class Base64FileTests : IClassFixture<ServiceCollection>
    {
        private readonly ServiceCollection _Services;
        public Base64FileTests(ServiceCollection services)
        {
            _Services = services;
        }

        [Fact]
        public void Binds_Valid_File()
        {
            var file = new Base64File(_Services.PngBase64File);
            Assert.Equal(_Services.PngBase64File, file.Base64String);
        }

        [Fact]
        public void Throws_Exception_If_Passed_String_Is_Not_Base64File()
        {
            Assert.Throws<InvalidBase64FileException>(() => new Base64File("dhjkahddkjashdjaskhdjaskh"));
        }

        [Fact]
        public void File_Extension_Is_Defined_Properly()
        {
            var file = new Base64File(_Services.PngBase64File);
            Assert.Equal(".png", file.FileExtension);
        }

        [Fact]
        public void File_Size_Is_Defined_Properly()
        {
            var file = new Base64File(_Services.PngBase64File);
            Assert.Equal(0.04, Math.Round(file.SizeInMb, 2));
        }

        [Fact]
        public void ByteArray_Is_Properly_Generated()
        {
            var file = new Base64File(_Services.PngBase64File);
            var bArray = file.ByteArray;

            Assert.NotEmpty(bArray);
            Assert.Equal(_Services.PngBase64File, Convert.ToBase64String(bArray));
        }
    }
}
