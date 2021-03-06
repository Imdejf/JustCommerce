using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Language;
using JustCommerce.Application.Common.Factories.DtoFactories.Language;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Language.Command
{
    public static class UpdateLanguage
    {

        public sealed record Command(Guid LanguageId, string Name, string IsoCode) : IRequestWrapper<LanguageDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, LanguageDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<LanguageDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var language = await _unitOfWorkManagmenet.Language.GetByIdAsync(request.LanguageId);

                if (language is null)
                {
                    throw new EntityNotFoundException($"Language with Id : {request.LanguageId} doesn`t exists");
                }

                language.Name = request.Name;
                language.IsoCode = request.IsoCode;

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return LanguageDtoFactory.CreateFromEntity(language);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.LanguageId).NotEqual(Guid.Empty);
                RuleFor(c => c.Name).NotEmpty();
                RuleFor(c => c.IsoCode).NotEmpty();
            }
        }

    }
}
