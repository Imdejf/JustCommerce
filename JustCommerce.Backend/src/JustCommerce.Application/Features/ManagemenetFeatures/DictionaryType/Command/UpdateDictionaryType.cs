using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Application.Common.Factories.DtoFactories.Dictionary;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.ManagemenetFeatures.DictionaryType.Command
{
    public class UpdateDictionaryType
    {

        public sealed record Command(Guid DictionaryTypeId, string DictionaryType, string Name, string Description) : IRequestWrapper<DictionaryTypeDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, DictionaryTypeDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<DictionaryTypeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var dictionaryType = await _unitOfWorkManagmenet.DictionaryType.GetByIdAsync(request.DictionaryTypeId, cancellationToken);

                if(dictionaryType is null)
                {
                    throw new EntityNotFoundException($"DictionaryType with Id : {request.DictionaryTypeId} doesn`t exists");
                }

                dictionaryType.Name = request.Name;
                dictionaryType.DictionaryType = request.DictionaryType;
                dictionaryType.Description = request.Description;

                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return DictionaryTypeDtoFactory.CreateFromEntity(dictionaryType);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.DictionaryTypeId).NotEqual(Guid.Empty);
            }
        }

    }
}
