using JustCommerce.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Shared.UnitTests.ModelsTests
{
    public sealed class ApiResponseTests
    {
        [Fact]
        public void Success_Bind_Data()
        {
            var newApiResponse = ApiResponse.Success(201, new
            {
                Str = "TESTSTRING",
                Num = 123
            });

            dynamic data = newApiResponse.Data;
            Assert.Equal(201, newApiResponse.StatusCode);
            Assert.Equal(123, data.Num);
            Assert.Equal("TESTSTRING", data.Str);
        }

        [Fact]
        public void Success_Sets_Errors_To_Null()
        {
            var newApiResponse = ApiResponse.Success(201, new
            {
                Str = "TESTSTRING",
                Num = 123
            });

            Assert.Null(newApiResponse.Errors);
        }

        [Fact]
        public void Failuer_With_String_Bind_Data()
        {
            var newApiResponse = ApiResponse.Failure(500, "Error Occured");

            Assert.Equal(500, newApiResponse.StatusCode);
            Assert.Equal("Message", newApiResponse.Errors.First().Key);
            Assert.Equal("Error Occured", newApiResponse.Errors.First().Value.First());
            Assert.Single(newApiResponse.Errors.First().Value);
        }

        [Fact]
        public void Failuer_With_String_Sets_Data_To_Null()
        {
            var newApiResponse = ApiResponse.Failure(500, "Error Occured");

            Assert.Null(newApiResponse.Data);
        }

        [Fact]
        public void Failuer_With_Dic_Bind_Data()
        {
            var testDic = new Dictionary<string, string[]> { { "Data", new string[] { "D1", "D2" } }, { "DATA321", new string[] { "132312", "312312432" } } };
            var newApiResponse = ApiResponse.Failure(500, testDic);

            Assert.Equal(500, newApiResponse.StatusCode);
            Assert.Equal(2, newApiResponse.Errors.First().Value.Length);
            Assert.True(newApiResponse.Errors.TryGetValue("Data", out string[] values));
            Assert.Equal(2, values.Length);
            Assert.Equal("D1", values[0]);
            Assert.True(newApiResponse.Errors.TryGetValue("DATA321", out values));
            Assert.Equal(2, values.Length);
            Assert.Equal("312312432", values[1]);
        }

        [Fact]
        public void Failuer_With_Dic_Sets_Data_To_Null()
        {
            var newApiResponse = ApiResponse.Failure(500, new Dictionary<string, string[]>());

            Assert.Null(newApiResponse.Data);
        }
    }
}
