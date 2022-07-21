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

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Category.Command
{
    public static class RemoveCategory
    {

        public sealed record Command(Guid CategoryId) : IRequest<Unit>;

        public sealed class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(!await _unitOfWorkAdministration.Category.ExistsAsync(request.CategoryId, cancellationToken))
                {
                    throw new EntityNotFoundException($"Category with id {request.CategoryId} doesnt exist");
                }

                _unitOfWorkAdministration.Category.RemoveById(request.CategoryId);
                await _unitOfWorkAdministration.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public sealed class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(c => c.CategoryId).NotEqual(Guid.Empty);
            }
        }


    }
}
