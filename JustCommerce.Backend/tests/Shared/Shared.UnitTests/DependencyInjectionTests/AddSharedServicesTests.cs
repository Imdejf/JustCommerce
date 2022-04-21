﻿using JustCommerce.Shared.Configurations;
using JustCommerce.Shared.DependencyInjection;
using JustCommerce.Shared.Services.Interfaces;
using JustCommerce.Shared.Services.Interfaces.Base64FileValidator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Shared.UnitTests.DependencyInjectionTests
{
    public sealed class AddSharedServicesTests
    {
        private readonly IServiceCollection _Services;
        private JwtServiceConfig _TestConfig => new JwtServiceConfig
        {
            Audience = "TESTAUDIENCE",
            Issuer = "TESTISSUER",
            ReferralId = "TESTREFERRALID",
            ReferralUrl = "TESTREFERRALURL",
            RsaPrivateKey = @"<RSAKeyValue><Modulus>zH3yR3VM8bLnaE4K1MpLRoNkckxPK8xihXJgaBAOSXEFDn3hpHKWhi+eA89Jfr9FP3vjLGm6fbtnYXu6PA1jq+49jCY2h0Gfg9TpjbF+pQ06y7vG4t69ShSNVvYWnxvELN4WNi6ZqDYaaqGf3Xfdt+SMn4mr2oYBjcmg90/uWSsTUvTCtWGP3mDfrlN9He6tkxuyrvgDvQLzhPj0yi8TyYo9roDrEqpvH6FtYf9UNFvwiurX+XuHOlOXO8+lBAEgRqxebL+rgKtCmGJcHtOCF3Z3eh9KKitmjWtD032p4gw7XQgoIsarZRJrTXbJ+z3qnoH3sADLSglBAIH67rhXKQ==</Modulus><Exponent>AQAB</Exponent><P>5abGtg3PyeRb4Hs64fWOYWF7r4vdteDmQ/T9muMGo5bGfLdEDhiiN3rkbYyTzH4cUcx14KEwp0gH2+CIU600n6KePGKXI6nnl18r6KqIOtJtqPwsEf9fKnFOwBR+aGrzUMkJbc5WLHhAuwNthbC9bXy8EqDZvnGtM4SrEjaunCM=</P><Q>4/QyS92tp5jXjyPKMdPVR0aMnQ4GYZACFkty0CGpXj6iYNR3+kTYAyWkX7RMY5UPDA0pwyh/S7QRseSOnidpSj3kxe+bc6rzBj1daMF6uy9lW32O0SBDtY5/eVHF4JiOXYtUxPMAcFBwDiDq+2OC/b4ycMpBZf2ObeIxm5LHPkM=</Q><DP>oyK9B/h5wgZpSebgJkHEeeLA9SwbPCdeC6pOOSfKwIzLxS5+trDDEzxGZpe1Kk/vmB/xILgAkuR1SLmQvjhNKJVhaK30hY4diQc/btEtYvO2mJNCTyqklMbW1VX5kf1fiOS2wP0RdBeci/zcYVryxYMVKvp+k223RuCYkaCsmxc=</DP><DQ>kKAiORgQUUEbomlmo25u5qXQGOUJD2U6rcJ4uaxhtLWweBbVeCetlXGQdFgEDzpHLbI8SOGswe8hOuhzw8vldYEHYL3AtwZC4jaUyR3YLGLJv95NekkqLEqYffRvwyuHR7pasgoqwReHwK8J5y0fsrW1cvIfxAG3F+hm6PmbB9k=</DQ><InverseQ>BRjbQlkAe0NBkWwcvym8yB1hWNyHs9WaWhqFforz7LxqaAoGNXr7WtJxAJ/+qsx1XYgh6cZz6JuMWfQbObj/pgHOA49ux7exQksC8s+prWu5IpdQCHYqZH2nn/r0h8j0rnA13YpVckc3/Dja0offBc1UuLdw4lAxkfAaW/i5BnI=</InverseQ><D>HYuw/swe8ukTcEmeXQJhf+2qDK2j3sMoFPningZ72fafcWmUuYro3rhwj0Ja7xo5qiN/PkKEdHgoRrh2vwh8NzIz6FT5Ge/MWWLg390eXECeFyOpZ8wg81wm08K4oAKGBKmN8gQnpVsz0+ZIT9pqyZAXFVHx55/nB5JzVGhTGsTRZujUAReZoBbNkxiUNWfkrQZfgHohcRmCvZkwtr1WXbyYxE1IKD+vxhFLyZ1TPgxjlYQ1JRa384m1JlcnZJhkGrytFxT9Lht2SwEf/5gMNXApRIw9KxNwxXNEN2XL7jt8hxzvXEWxhrzAjkpW5DEKP9vlN7MquYBuJ+fvTovdtQ==</D></RSAKeyValue>",
            RsaPublicKey = @"<RSAKeyValue><Exponent>AQAB</Exponent><Modulus>zH3yR3VM8bLnaE4K1MpLRoNkckxPK8xihXJgaBAOSXEFDn3hpHKWhi+eA89Jfr9FP3vjLGm6fbtnYXu6PA1jq+49jCY2h0Gfg9TpjbF+pQ06y7vG4t69ShSNVvYWnxvELN4WNi6ZqDYaaqGf3Xfdt+SMn4mr2oYBjcmg90/uWSsTUvTCtWGP3mDfrlN9He6tkxuyrvgDvQLzhPj0yi8TyYo9roDrEqpvH6FtYf9UNFvwiurX+XuHOlOXO8+lBAEgRqxebL+rgKtCmGJcHtOCF3Z3eh9KKitmjWtD032p4gw7XQgoIsarZRJrTXbJ+z3qnoH3sADLSglBAIH67rhXKQ==</Modulus></RSAKeyValue>",
            TokenLifetimeInMinutes = 10
        };
        public AddSharedServicesTests()
        {
            _Services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            _Services.AddSingleton(_Services);
            _Services.AddJwtAuthorization(_TestConfig);
            _Services.AddSharedServices(new ConfigurationBuilder()
                .AddJsonFile("../appsettings.json", optional: true, reloadOnChange: true)
                .Build());
        }

        [Fact]
        public void ICurrentUserService_Is_Registered()
        {
            Assert.NotNull(_Services.BuildServiceProvider().GetRequiredService<ICurrentUserService>());
        }

        [Fact]
        public void ILoggingTool_Is_Registered()
        {
            Assert.NotNull(_Services.BuildServiceProvider().GetRequiredService<ILoggingTool>());
        }

        [Fact]
        public void IBase64AnyFileValidator_Is_Registered()
        {
            Assert.NotNull(_Services.BuildServiceProvider().GetRequiredService<IBase64AnyFileValidator>());
        }

        [Fact]
        public void IBase64ImageFileValidator_Is_Registered()
        {
            Assert.NotNull(_Services.BuildServiceProvider().GetRequiredService<IBase64ImageFileValidator>());
        }
    }
}
