using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product.Attributes.SpecificationAttributes;
using JustCommerce.Domain.Entities.Products.Attributes.SpecificationAttribute;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Attributes.SpecificationAttributes.Commnad
{
    public static class CreateSpecificationGroup
    {

        public sealed record Command(Guid StoreId,string Name, int DisplayOrder) : IRequest<SpecificationAttributeGroupDTO>;

        public sealed class Handler : IRequestHandler<Command, SpecificationAttributeGroupDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<SpecificationAttributeGroupDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var newGroup = new SpecificationAttributeGroupEntity
                {
                    StoreId = request.StoreId,
                    Name = request.Name,
                    DisplayOrder = request.DisplayOrder,
                };

                await _unitOfWorkAdministration.SpecificationAttributeGroup.AddAsync(newGroup, cancellationToken);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                var dto = new SpecificationAttributeGroupDTO
                {
                    Id = newGroup.Id,
                    Name = newGroup.Name,
                    DisplayOrder = newGroup.DisplayOrder
                };

                return dto;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
                RuleFor(c => c.Name).NotEmpty();
            }
        }


    }
}
