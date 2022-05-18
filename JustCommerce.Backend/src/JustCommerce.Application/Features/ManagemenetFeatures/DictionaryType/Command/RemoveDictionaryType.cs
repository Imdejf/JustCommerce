using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.ManagemenetFeatures.DictionaryType.Command
{
    public class RemoveDictionaryType
    {

        public sealed record Command(Guid DictionaryTypeId) : IRequestWrapper<Unit>;

        public sealed class Handler : IRequestHandlerWrapper<Command, Unit>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var dictionaryTypeIdExist = await _unitOfWorkManagmenet.DictionaryType.ExistsAsync(request.DictionaryTypeId, cancellationToken);

                if (!dictionaryTypeIdExist)
                {
                    throw new EntityNotFoundException($"DictionaryType with Id : {request.DictionaryTypeId} doesn`t exists");

                }

                _unitOfWorkManagmenet.DictionaryType.RemoveById(request.DictionaryTypeId);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {

            }
        }

    }
}
