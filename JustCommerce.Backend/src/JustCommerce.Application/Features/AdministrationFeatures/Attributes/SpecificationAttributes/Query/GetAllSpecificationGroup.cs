using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Attributes.SpecificationAttributes;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Query
{
    public static class GetAllSpecificationGroup
    {

        public sealed record Query(Guid StoreId) : IRequest<List<SpecificationGroupDTO>>;

        public sealed class Handler : IRequestHandler<Query, List<SpecificationGroupDTO>>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            private readonly IUnitOfWorkManagmenet _unitOfWorkManagmenet;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration, IUnitOfWorkManagmenet unitOfWorkManagmenet)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
                _unitOfWorkManagmenet = unitOfWorkManagmenet;
            }

            public async Task<List<SpecificationGroupDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkManagmenet.Store.ExistsAsync(request.StoreId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Store with id: {request.StoreId} doesnt exist");
                }

                var specicationGroup = await _unitOfWorkAdministration.SpecificationAttributeGroup.GetAllFullyAsync(request.StoreId, cancellationToken);

                return specicationGroup.Select(c => new SpecificationGroupDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    StoreId = c.StoreId,
                    DisplayOrder = c.DisplayOrder,
                    SpecificationAttribute = c.SpecificationAttribute.Select(c => new SpecificationAttributeDTO
                    {
                        Id = c.Id,
                        SpecificationAttributeGroupId = c.SpecificationAttributeGroupId,
                        Name = c.Name,
                        DisplayOrder = c.DisplayOrder,
                    }).ToList()
                }).ToList();
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(c => c.StoreId).NotEqual(Guid.Empty);
            }
        }


    }
}
