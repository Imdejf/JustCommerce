using FluentValidation;
using JustCommerce.Application.Common.DTOs.Product.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.AdministrationFeatures.Product.Product.Command
{
    public static class UpdateProduct
    {

        public sealed record Command() : IRequest<ProductDTO>;

        public sealed class Handler : IRequestHandler<Command, ProductDTO>
        {
            public Handler()
            {

            }

            public async Task<ProductDTO> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
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
