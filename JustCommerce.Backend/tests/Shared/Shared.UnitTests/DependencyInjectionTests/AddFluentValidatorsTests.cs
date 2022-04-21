using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Shared.UnitTests.DependencyInjectionTests
{
    public sealed class AddFluentValidatorsTests
    {
        [Fact]
        public void FluentValidation_Is_Registered_Properly()
        {
            IServiceCollection services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            services.AddFluentValidation();
            var serviceProvider = services.BuildServiceProvider();

            Assert.NotNull(serviceProvider.GetRequiredService<IValidatorFactory>());
        }
    }
}
