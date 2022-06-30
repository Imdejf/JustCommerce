using FluentValidation;
using JustCommerce.Application.Common.DTOs.Enum;
using JustCommerce.Application.Common.Interfaces;
using JustCommerce.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JustCommerce.Application.Features.AdministrationFeatures.ProductType.Query
{
    public static class GetPropertyTypeProductType
    {

        public sealed record Query() : IRequestWrapper<ICollection<EnumDTO>>;

        public sealed class Handler : IRequestHandlerWrapper<Query, ICollection<EnumDTO>>
        {
            public Handler()
            {
            }

            public Task<ICollection<EnumDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Task.FromResult<ICollection<EnumDTO>>(EnumDTO.CreateForType<PropertyType>());
            }
        }
    }
}
