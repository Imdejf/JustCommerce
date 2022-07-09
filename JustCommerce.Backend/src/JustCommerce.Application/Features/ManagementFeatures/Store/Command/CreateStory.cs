using FluentValidation;
using JustCommerce.Application.Common.DTOs.Company;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.ManagementFeatures.Store.Command
{
    public static class CreateStory
    {

        public sealed record Command() : IRequest<StoreDTO>;

        public sealed class Handler : IRequestHandler<Command, StoreDTO>
        {
            public Handler()
            {

            }

            public async Task<StoreDTO> Handle(Command request, CancellationToken cancellationToken)
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
