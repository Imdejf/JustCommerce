using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Dictionary;
using JustCommerce.Application.Common.Factories.DtoFactories.Dictionary;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Dictionary;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;

namespace JustCommerce.Application.Features.ManagemenetFeatures.DictionaryType.Command
{
    public class CreateDictionaryType
    {

        public sealed record Command(Guid ShopId, string DictionaryType, string Name, string Description) : IRequestWrapper<DictionaryTypeDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Command, DictionaryTypeDTO>
        {
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            
            public Handler(IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<DictionaryTypeDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                var shopExist = await _unitOfWorkManagmenet.Shop.ExistsAsync(request.ShopId, cancellationToken);

                if (!shopExist)
                {
                    throw new EntityNotFoundException($"Shop with Id : {request.ShopId} doesn`t exists");
                }

                var newDictionaryType = DictionaryTypeEntityFactory.CreateFromProductCommand(request);

                await _unitOfWorkManagmenet.DictionaryType.AddAsync(newDictionaryType, cancellationToken);
                await _unitOfWorkManagmenet.SaveChangesAsync(cancellationToken);

                return DictionaryTypeDtoFactory.CreateFromEntity(newDictionaryType);
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ShopId).NotEqual(Guid.Empty);
            }
        }

    }
}
