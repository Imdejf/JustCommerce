using JustCommerce.Shared.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Shared.UnitTests.DependencyInjectionTests
{
    public sealed class AddMediatorTests
    {
        private readonly IServiceCollection _Services;
        public AddMediatorTests()
        {
            _Services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            _Services.AddMediator(Assembly.GetExecutingAssembly());
        }

        [Fact]
        public void MediatR_Is_Registered_Properly()
        {
            Assert.NotNull(_Services.BuildServiceProvider().GetRequiredService<IMediator>());
        }

        [Fact]
        public void LoggingBehaviour_Is_Registered_Properly()
        {
            Assert.NotNull(_Services.Where(c => c.ImplementationType != null && c.ImplementationType.Name.Contains("LoggingBehav")).FirstOrDefault());
        }

        [Fact]
        public void ValidationBehaviour_Is_Registered_Properly()
        {
            Assert.NotNull(_Services.Where(c => c.ImplementationType != null && c.ImplementationType.Name.Contains("ValidationBehav")).FirstOrDefault());

        }
    }
}
