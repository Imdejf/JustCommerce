using E_Commerce.Application.Common.Interfaces;
using E_Commerce.Application.Common.Interfaces.CommonFeatures;
using E_Commerce.Domain.Entities;

namespace E_Commerce.Application.Features.CommonFeatures.AuthFeatures
{
    public static class Register
    {
        public sealed record Command(string Login, string Email, string Password, string PasswordCopy, string Name, string Surname,
                                     string? CompanyName, string? Nip, string Province, string Street) : IRequestWrapper<User>;

        public sealed class Handler : IRequestHandlerWrapper<Command, User>
        {
            private readonly IUserManager _UserManager;
            private readonly ITokenGenerator _TokenGenerator;
            private readonly IMailSender _EmailSender;

            public Handler(IUserManager userManager, ITokenGenerator tokenGenerator, IMailSender emailSender)
            {
                _UserManager = userManager;
                _TokenGenerator = tokenGenerator;
                _EmailSender = emailSender;
            }

            public Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
