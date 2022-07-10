using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Shared.Exceptions;
using MediatR;

namespace JustCommerce.Application.Features.AdministrationFeatures.Attributes.SpecificationAttributes.Commnad
{
    public static class RemoveSpecificationAttribute
    {

        public sealed record Command(Guid SpecificationAttributeId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkAdministration.SpecificationAttribute.ExistsAsync(request.SpecificationAttributeId))
                {
                    throw new EntityNotFoundException($"Specification attribute with id {request.SpecificationAttributeId} doesnt exist");
                }

                _unitOfWorkAdministration.SpecificationAttribute.RemoveById(request.SpecificationAttributeId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

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
