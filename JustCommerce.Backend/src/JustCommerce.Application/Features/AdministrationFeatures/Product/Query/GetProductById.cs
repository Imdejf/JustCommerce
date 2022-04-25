using FluentValidation;
using JustCommerce.Application.Common.DataAccess.Repository;
using JustCommerce.Application.Common.DTOs.Product;
using JustCommerce.Application.Common.Factories.EntitiesFactories.Product;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Shared.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Query
{
    public static class GetProductById
    {

        public sealed record Query(Guid ProductId) : IRequestWrapper<ProductDTO>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ProductDTO>
        {
            private readonly IUnitOfWorkAdministration _unitOfWorkAdministration;
            public Handler(IUnitOfWorkAdministration unitOfWorkAdministration)
            {
                _unitOfWorkAdministration = unitOfWorkAdministration;
            }

            public async Task<ProductDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _unitOfWorkAdministration.Product.GetByIdAsync(request.ProductId);

                if(product is null)
                {
                    throw new EntityNotFoundException($"Product with Id: {request.ProductId} doesn't exist");
                }
                throw new Exception();
               // return ProductDtoFactory
            }
        }

        public sealed class Validator : AbstractValidator<Query>
        {
            public Validator()
            {

            }
        }

    }
}
