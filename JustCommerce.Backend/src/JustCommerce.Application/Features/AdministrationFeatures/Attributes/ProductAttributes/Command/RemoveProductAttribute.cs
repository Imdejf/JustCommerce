using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.ProductAttributes.Command
{
    public static class RemoveProductAttribute
    {

        public sealed record Command(Guid ProductAttributeId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!await _unitOfWorkAdministration.ProductAttribute.ExistsAsync(request.ProductAttributeId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Product attribute with id: {request.ProductAttributeId} doesnt exist");
                }

                _unitOfWorkAdministration.ProductAttribute.RemoveById(request.ProductAttributeId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.ProductAttributeId).NotEqual(Guid.Empty);
            }
        }
    }
}
