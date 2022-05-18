using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Application.Common.Factories.DtoFactories.Dictionary;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Dictionary;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.Dictionary.Command
{
    public class CreateDictionary
    {

        public sealed record Command(Guid DictionaryTypeId, string Name, string Dictionary, List<DictionaryLangDTO> DictionaryLang) : IRequestWrapper<DictionaryDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, DictionaryDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<DictionaryDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var dictionaryTypeExist = await _unitOfWorkManagmenet.DictionaryType.ExistsAsync(request.DictionaryTypeId, cancellationToken);

                if (!dictionaryTypeExist)
                {
                    throw new EntityNotFoundException($"DictionaryType with Id : {request.DictionaryTypeId} doesn`t exists");
                }

                var newDictionary = DictionaryEntityFactory.CreateFromCommand(request);

                await _unitOfWorkManagmenet.Dictionary.AddAsync(newDictionary, cancellationToken);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return DictionaryDtoFactory.CreateFromEntity(newDictionary);
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
