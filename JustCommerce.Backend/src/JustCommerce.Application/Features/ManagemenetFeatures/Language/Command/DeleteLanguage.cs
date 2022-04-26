using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Language.Command
{
    public static class DeleteLanguage
    {

        public sealed record Command(Guid LanguageId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var language = await _unitOfWorkManagmenet.Language.GetByIdAsync(request.LanguageId, cancellationToken);

                if (language is null)
                {
                    throw new EntityNotFoundException($"Language with Id : {request.LanguageId} doesn`t exists");
                }

                _unitOfWorkManagmenet.Language.Remove(language);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.LanguageId).NotEqual(Guid.Empty);
            }
        }

    }
}
